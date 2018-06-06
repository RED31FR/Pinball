Imports Pinduino0._2

Public Class Form1
    Protected Property mPinduino As New CPinduinoBoard
    Protected Property mTargets As New CPinballTargets(3, "def", "a", "b", "c")
    Protected Property mScore As Integer = 0
    Protected Property mGameController As New CGameController

    Public Property Score As Integer
        Get
            Return mScore
        End Get
        Set(value As Integer)
            mScore = value
            Label1.Text = "SCORE : " & mScore.ToString
        End Set
    End Property


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mPinduino.PortName = "COM6"
        mPinduino.BaudRate = 115200
        Me.Controls.Add(mPinduino)

        AddHandler mGameController.OnScoreChange, AddressOf mGameController_OnScoreChange

        mGameController.Pinduino = mPinduino
        mPinduino.OpenSerial()
        mPinduino.LoadFromFile("c:\temp\pinduino.txt")
        mPinduino.Run()
        'AddHandler mPinduino.OnCommandSend, AddressOf OnCommandSend
        'AddHandler mPinduino.OnPinduinoClose, AddressOf OnPinduinoClose
        'AddHandler mPinduino.OnPinduinoOpen, AddressOf OnPinduinoOpen
        'AddHandler mPinduino.OnRunMode, AddressOf OnRunMode
        'AddHandler mPinduino.OnSetupMode, AddressOf OnSetupMode
        'AddHandler mPinduino.OnSwitchOn, AddressOf OnSwitchOn
        'AddHandler mPinduino.OnLoadFile, AddressOf OnLoadFile
        'AddHandler mPinduino.OnSaveFile, AddressOf OnSaveFile
        'AddHandler mPinduino.OnDataReceiveFromBoard, AddressOf OnDataReceiveFromBoard

        'AddHandler mTargets.OnTargetsUp, AddressOf OnTargetsUp
        'AddHandler mTargets.OnTargetDown, AddressOf OnTargetDown
        'AddHandler mTargets.OnAllTargetsDown, AddressOf OnAllTargetsDown
        'AddHandler mTargets.OnDownHalfTargetsWithSolenoid, AddressOf OnDownHalfTargetsWithSolenoid


        'mPinduino.OpenSerial()
        'mPinduino.LoadFromFile("c:\temp\pinduino.txt")
        'mPinduino.Run()

        'me.UserControlPinduinoControl1.Pinduino = mPinduino
    End Sub

    Private Sub mGameController_OnScoreChange()
        Label1.Text = "SCORE : " & mGameController.Score.ToString
    End Sub

    Private Sub OnDownHalfTargetsWithSolenoid(code As Char)
        mPinduino.Write(code.ToString)
    End Sub

    Private Sub OnAllTargetsDown()
        'MsgBox("all targets down")
        Score += 1000
    End Sub

    Private Sub OnTargetDown(obj As CPinballPartSwitch)
        'MsgBox("target with code " & obj.Code & " was down")
        Score += 100
    End Sub

    Private Sub OnTargetsUp(code As String)
        mPinduino.Write(code)
        ' MsgBox("targets up")
    End Sub

    Private Sub OnDataReceiveFromBoard(data As String)
        mTargets.Action(data)
    End Sub

    Private Sub OnSaveFile(path As String)
        ToolStripStatusLabel1.Text = "Pinduino Config Saved to file " & path
    End Sub

    Private Sub OnLoadFile(path As String)
        ToolStripStatusLabel1.Text = "Pinduino Config Loaded from file " & path
    End Sub

    Private Sub OnSwitchOn(charCode As String)
        ToolStripStatusLabel1.Text = "The switch " & charCode(0) & " was enable"
        mPinduino.Write(charCode)
    End Sub

    Private Sub OnSetupMode()
        ToolStripStatusLabel1.Text = "Pinduino in Setup Mode"
    End Sub

    Private Sub OnRunMode()
        ToolStripStatusLabel1.Text = "Pinduino in Run Mode"
    End Sub

    Private Sub OnPinduinoOpen()
        ToolStripStatusLabel1.Text = "Pinduino is open"
    End Sub

    Private Sub OnPinduinoClose()
        ToolStripStatusLabel1.Text = "Pinduino is close"
    End Sub

    Private Sub OnCommandSend(cmd As String, label As String)
        ToolStripStatusLabel1.Text = "this command was execute " & label
    End Sub


End Class
