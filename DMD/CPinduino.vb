Imports System.IO.Ports
Imports Pinball

Public Class CPinduinoPin
    Public Const SWITCH00 As Integer = 22
    Public Const SWITCH01 As Integer = 23
    Public Const SWITCH02 As Integer = 24
    Public Const SWITCH03 As Integer = 25
    Public Const SWITCH04 As Integer = 26
    Public Const SWITCH05 As Integer = 27
    Public Const SWITCH06 As Integer = 28
    Public Const SWITCH07 As Integer = 29
    Public Const SWITCH08 As Integer = 30
    Public Const SWITCH09 As Integer = 31
    Public Const SWITCH10 As Integer = 32
    Public Const SWITCH11 As Integer = 33
    Public Const SWITCH12 As Integer = 34
    Public Const SWITCH13 As Integer = 35
    Public Const SWITCH14 As Integer = 36
    Public Const SWITCH15 As Integer = 37
    Public Const SWITCH16 As Integer = 38
    Public Const SWITCH17 As Integer = 39
    Public Const SWITCH18 As Integer = 40
    Public Const SWITCH19 As Integer = 41
    Public Const SWITCH20 As Integer = 42
    Public Const SWITCH21 As Integer = 43
    Public Const SWITCH22 As Integer = 44
    Public Const SWITCH23 As Integer = 45
    Public Const SWITCH24 As Integer = 46
    Public Const SWITCH25 As Integer = 47
    Public Const SWITCH26 As Integer = 48
    Public Const SWITCH27 As Integer = 49
    Public Const SWITCH28 As Integer = 50
    Public Const SWITCH29 As Integer = 51
    Public Const SWITCH30 As Integer = 52
    Public Const SWITCH31 As Integer = 53

    Public Const RELAY00 As Integer = 2
    Public Const RELAY01 As Integer = 3
    Public Const RELAY02 As Integer = 4
    Public Const RELAY03 As Integer = 5
    Public Const RELAY04 As Integer = 6
    Public Const RELAY05 As Integer = 7
    Public Const RELAY06 As Integer = 8
    Public Const RELAY07 As Integer = 9

    Public Const SWITCHCODE00 As Char = "a"
    Public Const SWITCHCODE01 As Char = "b"
    Public Const SWITCHCODE02 As Char = "c"
    Public Const SWITCHCODE03 As Char = "d"
    Public Const SWITCHCODE04 As Char = "e"
    Public Const SWITCHCODE05 As Char = "f"
    Public Const SWITCHCODE06 As Char = "g"
    Public Const SWITCHCODE07 As Char = "h"
    Public Const SWITCHCODE08 As Char = "i"
    Public Const SWITCHCODE09 As Char = "j"
    Public Const SWITCHCODE10 As Char = "k"
    Public Const SWITCHCODE11 As Char = "l"
    Public Const SWITCHCODE12 As Char = "m"
    Public Const SWITCHCODE13 As Char = "n"
    Public Const SWITCHCODE14 As Char = "o"
    Public Const SWITCHCODE15 As Char = "p"
    Public Const SWITCHCODE16 As Char = "q"
    Public Const SWITCHCODE17 As Char = "r"
    Public Const SWITCHCODE18 As Char = "s"
    Public Const SWITCHCODE19 As Char = "t"
    Public Const SWITCHCODE20 As Char = "u"
    Public Const SWITCHCODE21 As Char = "v"
    Public Const SWITCHCODE22 As Char = "w"
    Public Const SWITCHCODE23 As Char = "x"
    Public Const SWITCHCODE24 As Char = "y"
    Public Const SWITCHCODE25 As Char = "z"
    Public Const SWITCHCODE26 As Char = "0"
    Public Const SWITCHCODE27 As Char = "1"
    Public Const SWITCHCODE28 As Char = "2"
    Public Const SWITCHCODE29 As Char = "3"
    Public Const SWITCHCODE30 As Char = "4"
    Public Const SWITCHCODE31 As Char = "5"

    Public Const RELAYCODE00 As Char = "a"
    Public Const RELAYCODE01 As Char = "b"
    Public Const RELAYCODE02 As Char = "c"
    Public Const RELAYCODE03 As Char = "d"
    Public Const RELAYCODE04 As Char = "e"
    Public Const RELAYCODE05 As Char = "f"
    Public Const RELAYCODE06 As Char = "g"
    Public Const RELAYCODE07 As Char = "h"
End Class


Public Class CPinduino
    Inherits Control

    Protected Property mSerial As New SerialPort
    Protected Property mBumpers As New List(Of CPinballPartBumper)
    Protected Property mTargetsGroups As New List(Of CPinballPartTargets)
    Protected Property mLanesGroups As New List(Of CPinballPartLanes)
    Protected Property mLanes As New List(Of CPinballPartLane)
    Protected Property mLamps As New List(Of CPinballPartLamp)
    Protected Property mSwitchs As New List(Of CPinballPartSwitchPinduino)

    Shared addr, data As Int16
    Shared CodeSerial As String

    Public Event On_SwitchOn(e As CPinballPartSwitchPinduino)
    Public Event On_SwitchOff(e As CPinballPartSwitchPinduino)

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

    Public ReadOnly Property IsOpen As Boolean
        Get
            Return mSerial.IsOpen
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub AddCPinballPartSwitch(part As CPinballPartSwitchPinduino)
        mSwitchs.Add(part)
        AddHandler part.SwitchOn, AddressOf Me.OnSwitchOn
        AddHandler part.SwitchOff, AddressOf Me.OnSwitchOff
    End Sub

    Private Sub OnSwitchOff(e As CPinballPart)
        Dim obj As CPinballPartSwitchPinduino
        If TypeOf e Is CPinballPartSwitchPinduino Then
            obj = CType(e, CPinballPartSwitchPinduino)
            RaiseEvent On_SwitchOff(obj)
        End If

    End Sub

    Private Sub OnSwitchOn(e As CPinballPart)

        RaiseEvent On_SwitchOn(e)

    End Sub

    Private Sub DataReceive(sender As Object, e As SerialDataReceivedEventArgs)
        Do
            data = mSerial.ReadByte()
            If data <> 13 And data <> 10 Then
                addr = data.ToString
            End If
        Loop Until (mSerial.BytesToRead() = 0)
        Me.Invoke(New MethodInvoker(AddressOf DoActions)) 'Start "Display" on the UI thread
    End Sub

    Private Sub DoActions()
        CodeSerial = Chr(addr)
        For Each switch In mSwitchs
            If switch.Code = CodeSerial Then
                switch.State = True
                mSerial.Write(switch.Action)
            End If
        Next
        'Me.TXT_EVENTS.Text = numero_table
        'If numero_table = "1" Then SerialPort1.Write("a")
        'Select Case Chr(addr)
        'Case "q"
        'mSerial.Write("a")
        'mTarget.State = Not mTarget.State
        'Case "s"
        'mSerial.Write("z")
        'Case "d"
        'mSerial.Write("e")
        'Case "f"
        'mSerial.Write("r")
        'Case "g"
        'mSerial.Write("t")
        'Case "h"
        'mSerial.Write("y")
        'Case "j"
        'mSerial.Write("u")
        'Case "k"
        'mSerial.Write("i")
        'End Select
        'mSerial.Write(numero_table)
    End Sub

    Public Sub Write(data As String)
        If mSerial.IsOpen Then
            mSerial.Write(data)
        End If
    End Sub

    Public Sub OpenSerial()
        mSerial.Open()
    End Sub

    Public Sub CloseSerial()
        mSerial.Close()
    End Sub
End Class
