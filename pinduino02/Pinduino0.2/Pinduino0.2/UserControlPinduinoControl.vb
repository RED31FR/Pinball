Imports System.IO

Public Class UserControlPinduinoControl
    Protected Property mTop = 115
    Protected Property mPinduino As CPinduinoBoard

    Public Property PortName As String
        Get
            Return mPinduino.PortName
        End Get
        Set(value As String)
            mPinduino.PortName = value
        End Set
    End Property

    Public Property BaudRate As Integer
        Get
            Return mPinduino.BaudRate
        End Get
        Set(value As Integer)
            mPinduino.BaudRate = value
        End Set
    End Property

    Public Property Pinduino
        Get
            Return mPinduino
        End Get
        Set(value)
            If value IsNot Nothing Then
                mPinduino = value
                AddHandler mPinduino.OnDataReceiveFromBoard, AddressOf OnDataReceiveFromBoard
                Me.PortName = mPinduino.PortName
                Me.BaudRate = mPinduino.BaudRate
            End If
        End Set
    End Property

    Private Sub ButtonOpenClose_Click(sender As Object, e As EventArgs) Handles ButtonOpenClose.Click
        If mPinduino.IsOpen Then
            mPinduino.CloseSerial()
            ButtonOpenClose.Text = "Open"
            ButtonRunMode.Enabled = False
            ButtonSendCommand.Enabled = False
            ButtonSetupMode.Enabled = False
            UserControlPinduinoPortConfig1.Enabled = False
            ButtonLoad.Enabled = False
            ButtonSave.Enabled = False
            RemoteLabels()
            SerialReport.Text = ""
            mTop = 115
        Else
            mPinduino.OpenSerial()
            ButtonOpenClose.Text = "Close"
            System.Threading.Thread.Sleep(200)
            mPinduino.Write("@")
            ButtonRunMode.Enabled = True
            ButtonSendCommand.Enabled = True
            ButtonSetupMode.Enabled = True
            UserControlPinduinoPortConfig1.Enabled = True
            ButtonLoad.Enabled = True
            ButtonSave.Enabled = True
            mPinduino.startTimer()
        End If
    End Sub

    Private Sub RemoteLabels()
        Dim toRemove As New List(Of Control)
        For Each control In Me.Controls
            If TypeOf control Is Label Then
                toRemove.Add(control)
            End If
        Next
        For Each control In toRemove
            Me.Controls.Remove(control)
        Next
        Me.Invalidate()
    End Sub

    Private Sub ButtonSetupMode_Click(sender As Object, e As EventArgs) Handles ButtonSetupMode.Click
        mTop = 115
        SerialReport.Text = ""
        mPinduino.CommandsClear()
        mPinduino.Mode = CPinduinoPortType.SETUP
        RemoteLabels()
        ButtonSendCommand.Enabled = True
        UserControlPinduinoPortConfig1.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ButtonRunMode.Click
        mPinduino.Run()
        ButtonSendCommand.Enabled = False
        UserControlPinduinoPortConfig1.Enabled = False
    End Sub

    Private Sub ButtonSendCommand_Click(sender As Object, e As EventArgs) Handles ButtonSendCommand.Click
        mPinduino.Write(CommandLine.Text)
    End Sub

    Private Sub UserControlPinduinoControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Me.UserControlPinduinoPortConfig1.OnAddPort, AddressOf OnAddPort
    End Sub

    Private Sub OnAddPort(cmd As String, pin As Integer, type As String, code As String)
        If type = "Input" Then
            mPinduino.AddInput(pin, code)
        ElseIf type = "Output" Then
            mPinduino.AddOutput(pin, code)
        End If
    End Sub

    Private Sub OnAddPort(cmd As String, label As String)
        mPinduino.Write(cmd)
        Dim myLabel As New Label
        myLabel.Top = mTop
        mTop += myLabel.Height
        myLabel.Left = 380
        myLabel.Text = label
        myLabel.AutoSize = True
        Me.Controls.Add(myLabel)
        Me.Invalidate()
    End Sub

    Private Sub OnDataReceiveFromBoard(data As String)
        Me.SerialReport.Text &= data
    End Sub


    Private Sub ReloadConfig()
        'mPinduino.Reload()
        If Me.CheckBoxAutoStart.Checked Then
            mPinduino.Run()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        If SerialReport.Text = "Pinduino : Config Mode" & vbLf Then
            'Timer1.Stop()
            ReloadConfig()
        End If
    End Sub

    Private Sub ButtonLoad_Click(sender As Object, e As EventArgs) Handles ButtonLoad.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                mPinduino.LoadFromFile(openFileDialog1.FileName)
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.

            End Try
        End If
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                mPinduino.SaveToFile(openFileDialog1.FileName)
            Catch Ex As Exception
                MessageBox.Show("Cannot write file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.

            End Try
        End If
    End Sub
End Class
