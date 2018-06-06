Imports System.IO
Imports System.IO.Ports

Public Class CPinduinoPortType
    Public Const INPUT As Integer = 1
    Public Const OUTPUT As Integer = 2
    Public Const SETUP As Integer = 1
    Public Const RUN As Integer = 2
End Class

Public Class CPinduinoPort
    Protected Property mType As Integer
    Protected Property mCode As Char
    Protected Property mPin As Integer

    Public Sub New(pin As Integer, type As Integer, code As Char)
        Me.mCode = code
        Me.mType = type
        Me.mPin = pin
    End Sub
End Class

Public Class CPinduinoBoard
    Inherits Control

    Shared addr, data As Int16
    Shared CodeSerial As String = ""
    Shared OldCodeSerial As String = ""

    Protected Property mTimer As New Timer
    Protected Property mSerial As New SerialPort
    Protected Property mPorts As New List(Of CPinduinoPort)
    Protected Property mMode As Integer = CPinduinoPortType.SETUP
    Protected Property mCommands As New List(Of PinduinoCommand)

    Public Event OnDataReceiveFromBoard(data As String)
    Public Event OnPinduinoOpen()
    Public Event OnPinduinoClose()
    Public Event OnRunMode()
    Public Event OnSetupMode()
    Public Event OnCommandSend(cmd As String, label As String)
    Public Event OnSwitchOn(charCode As String)
    Public Event OnLoadFile(path As String)
    Public Event OnSaveFile(path As String)

    Public Property PortName As String
        Get
            Return mSerial.PortName
        End Get
        Set(value As String)
            mSerial.PortName = value
        End Set
    End Property
    Public Property BaudRate As Integer
        Get
            Return mSerial.BaudRate
        End Get
        Set(value As Integer)
            mSerial.BaudRate = value
        End Set
    End Property
    Public ReadOnly Property IsOpen
        Get
            Return mSerial.IsOpen
        End Get
    End Property
    Public Property Mode As Integer
        Get
            Return mMode
        End Get
        Set(value As Integer)
            If value = CPinduinoPortType.SETUP Or value = CPinduinoPortType.RUN Then
                mMode = value
                If mMode = CPinduinoPortType.SETUP Then
                    Me.reboot()
                Else
                    Me.Run()
                End If
            End If
        End Set
    End Property

    Public Sub reboot()
        Me.Write("@")
        mTimer.Start()
        RaiseEvent OnSetupMode()
    End Sub

    Public Sub startTimer()
        mTimer.Start()
    End Sub

    Public Sub New()
        AddHandler mSerial.DataReceived, AddressOf Me.DataReceive
        AddHandler mTimer.Tick, AddressOf Me.mTimer_Tick
    End Sub

    Private Sub DataReceive(sender As Object, e As SerialDataReceivedEventArgs)
        Do
            OldCodeSerial = CodeSerial
            CodeSerial = mSerial.ReadLine
            Me.Invoke(New MethodInvoker(AddressOf DoActions))
        Loop Until (mSerial.BytesToRead() = 0)
    End Sub

    Friend Sub CommandsClear()
        mCommands.Clear()
    End Sub

    Private Sub DoActions()
        If InStr(CodeSerial, "ODE>SETUP") Then 'CodeSerial = "Pinduino : Config Mode" & vbCr Then
            RaiseEvent OnSetupMode()
        ElseIf InStr(CodeSerial, "ODE>RUN") Then 'CodeSerial = "Pinduino : Running Mode" & vbCr Then
            RaiseEvent OnRunMode()
        ElseIf CodeSerial.Count = 2 Then
            RaiseEvent OnSwitchOn(CodeSerial)
            RaiseEvent OnDataReceiveFromBoard(CodeSerial)
        ElseIf InStr(CodeSerial, "NFO>") Then
            RaiseEvent OnDataReceiveFromBoard(CodeSerial)
        Else
            'Me.reboot()
        End If
    End Sub

    Private Sub Do_Actions()
        If (CodeSerial <> OldCodeSerial Or CodeSerial.Count = 2) Then

            If (CodeSerial.Count = 2) Then
                RaiseEvent OnDataReceiveFromBoard(CodeSerial)
                RaiseEvent OnSwitchOn(CodeSerial)
            Else
                If (mMode = CPinduinoPortType.SETUP And CodeSerial = "Pinduino : Config Mode" & vbCr) Then
                    RaiseEvent OnDataReceiveFromBoard(CodeSerial)
                    mMode = CPinduinoPortType.RUN
                Else
                    If mMode = CPinduinoPortType.SETUP Then
                        Me.Write("@")
                        RaiseEvent OnSetupMode()
                    Else
                        RaiseEvent OnDataReceiveFromBoard(CodeSerial)
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub OpenSerial()
        If Not mSerial.IsOpen Then
            mSerial.Open()
            System.Threading.Thread.Sleep(1000)
            Me.reboot()
            System.Threading.Thread.Sleep(1000)
            RaiseEvent OnPinduinoOpen()
        End If
    End Sub

    Public Sub CloseSerial()
        If mSerial.IsOpen Then
            mSerial.Close()
            Me.Mode = CPinduinoPortType.SETUP
            RaiseEvent OnPinduinoClose()
        End If
    End Sub

    Public Sub Write(data As String)
        If Me.IsOpen Then
            Me.mSerial.Write(data)
            RaiseEvent OnCommandSend(data, "command")
        End If
    End Sub

    Public Sub AddInput(pin As Integer, code As Char)
        mPorts.Add(New CPinduinoPort(pin, CPinduinoPortType.INPUT, code))
        mSerial.Write("#I" & pin.ToString & code)
        Dim command As New PinduinoCommand
        command.CharCode = code
        command.Pin = pin
        command.Type = CPinduinoPortType.INPUT
        command.Cmd = "#I" & pin.ToString & code
        mCommands.Add(command)
        RaiseEvent OnCommandSend(command.Cmd, command.Label)
    End Sub

    Public Sub AddOutput(pin As Integer, code As Char)
        mPorts.Add(New CPinduinoPort(pin, CPinduinoPortType.OUTPUT, code))
        mSerial.Write("#O" & pin.ToString & code)
        Dim command As New PinduinoCommand
        command.CharCode = code
        command.Pin = pin
        command.Type = CPinduinoPortType.OUTPUT
        command.Cmd = "#O" & pin.ToString & code
        mCommands.Add(command)
        RaiseEvent OnCommandSend(command.Cmd, command.Label)
    End Sub

    Public Sub Run()
        Me.Write("&")
        RaiseEvent OnRunMode()
    End Sub

    Public Sub Reload()
        For Each item In mCommands
            'If item.Type = CPinduinoPortType.INPUT Then
            'Me.AddInput(item.Pin, item.CharCode)
            'ElseIf item.Type = CPinduinoPortType.OUTPUT Then
            'Me.AddOutput(item.Pin, item.CharCode)
            'End If
            mSerial.Write(item.Cmd)
            RaiseEvent OnCommandSend(item.Cmd, item.Label)
        Next
    End Sub

    Public Sub LoadFromFile(path As String)
        If mSerial.IsOpen Then
            Dim reader = File.OpenText(path)
            Dim line As String = Nothing
            Dim code As String
            Dim pin As Integer
            Dim tmp As Char
            While (reader.Peek() <> -1)
                line = reader.ReadLine()
                code = line(line.Count - 1)
                tmp = line(1)
                If Char.IsDigit(tmp) Then
                    pin = Convert.ToInt16(tmp) - 48
                End If
                tmp = line(2)
                If Char.IsDigit(tmp) Then
                    pin *= 10
                    pin += Convert.ToInt32(tmp) - 48
                End If

                If line(0) = "I" Then
                    Me.AddInput(pin, code)
                ElseIf line(0) = "O" Then
                    Me.AddOutput(pin, code)
                End If
                System.Threading.Thread.Sleep(100)
            End While
            RaiseEvent OnLoadFile(path)
        End If
    End Sub

    Public Sub SaveToFile(path As String, Optional append As Boolean = False)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(path, append)
        For Each item In mCommands
            If item.Type = CPinduinoPortType.INPUT Then
                file.WriteLine("I" & item.Pin.ToString & item.CharCode)
            ElseIf item.Type = CPinduinoPortType.OUTPUT Then
                file.WriteLine("O" & item.Pin.ToString & item.CharCode)
            End If
        Next
        file.Close()
        RaiseEvent OnSaveFile(path)
    End Sub

    Private Sub mTimer_Tick(sender As Object, e As EventArgs)
        If CodeSerial = "Pinduino : Config Mode" & vbCr Then
            mTimer.Stop()
            Me.Reload()
        End If
    End Sub
End Class
