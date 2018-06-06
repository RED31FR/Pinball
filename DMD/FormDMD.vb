Imports System.IO.Ports
Imports Pinball

Public Class FormDMD
    Protected Property mPinballDMD As New CPinballDMD
    Protected Property mKeyPRessed As Boolean = False
    Protected Property mTarget As New CPinballPartTarget
    Protected Property mPinduino As New CPinduino

    Private Sub FormDMD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserControlCPinball1.PinballDMD = mPinballDMD
        Me.Width = UserControlCPinball1.Width + 10
        Me.Height = UserControlCPinball1.Height + 20
        Dim f As New FormPlayField
        AddHandler f.OnAllTargetsDrop, AddressOf Me.OnAllTargetsDropped
        AddHandler f.OnOneTargetDrop, AddressOf Me.OnTargetDrop

        AddHandler f.OnBumperHit, AddressOf OnBumperHit

        AddHandler f.OnBallLeft, AddressOf OnBallLeft

        AddHandler f.OnLaneLeftExitStateChange, AddressOf OnLaneLeftExitStateChange
        AddHandler f.OnLaneRightExitStateChange, AddressOf OnLaneRightExitStateChange
        AddHandler f.OnLaneLeftStateChange, AddressOf OnLaneLeftStateChange
        AddHandler f.OnLaneRightStateChange, AddressOf OnLaneRightStateChange

        AddHandler f.OnSlingShot, AddressOf Me.OnSlingShot

        AddHandler f.OnLanesOneLampOn, AddressOf Me.onLanesOneLampOn
        AddHandler f.OnLanesAllLampOn, AddressOf Me.onLanesAllLampOn

        'UserControlTarget1.Target = mTarget

        f.Show()
        Timer1.Start()
        'SerialPort2.Open()      
        Dim pin As CPinballPartSwitchPinduino

        pin = New CPinballPartSwitchPinduino(CPinduinoPin.SWITCHCODE00, CPinduinoPin.RELAY00, 1000)
        AddHandler pin.SwitchOn, AddressOf Me.OnSwitchPinduinoOn
        AddHandler pin.SwitchOff, AddressOf Me.OnSwitchPinduinoOff
        mPinduino.AddCPinballPartSwitch(pin)

        pin = New CPinballPartSwitchPinduino(CPinduinoPin.SWITCHCODE01, CPinduinoPin.RELAY01, 5000)
        AddHandler pin.SwitchOn, AddressOf Me.OnSwitchPinduinoOn
        AddHandler pin.SwitchOff, AddressOf Me.OnSwitchPinduinoOff
        mPinduino.AddCPinballPartSwitch(pin)

        pin = New CPinballPartSwitchPinduino(CPinduinoPin.SWITCHCODE02, CPinduinoPin.RELAY02, 100000)
        AddHandler pin.SwitchOn, AddressOf Me.OnSwitchPinduinoOn
        AddHandler pin.SwitchOff, AddressOf Me.OnSwitchPinduinoOff
        mPinduino.AddCPinballPartSwitch(pin)

        pin = New CPinballPartSwitchPinduino(CPinduinoPin.SWITCHCODE03, CPinduinoPin.RELAY03, 1000000)
        AddHandler pin.SwitchOn, AddressOf Me.OnSwitchPinduinoOn
        AddHandler pin.SwitchOff, AddressOf Me.OnSwitchPinduinoOff
        mPinduino.AddCPinballPartSwitch(pin)

        Me.Controls.Add(mPinduino)
        mPinduino.PortName = "COM6"
        mPinduino.BaudRate = 115200


    End Sub

    Private Sub OnSwitchPinduinoOff(e As CPinballPart)
        Throw New NotImplementedException()
    End Sub

    Private Sub OnSwitchPinduinoOn(e As CPinballPart)
        Dim obj As CPinballPartSwitchPinduino
        If TypeOf e Is CPinballPartSwitchPinduino Then
            obj = CType(e, CPinballPartSwitchPinduino)
            mPinballDMD.AddScore(obj.IncScore)
        End If
    End Sub

    Private Sub onLanesAllLampOn()
        Me.mPinballDMD.AddScore(50000)
        Me.mPinballDMD.Ramp()
    End Sub

    Private Sub onLanesOneLampOn(index As Integer)
        Dim LaneLampOnAnimation = New CDMDAnimation
        LaneLampOnAnimation.addImage("C:\graphics\sf2\LaneLampOn001.png")
        LaneLampOnAnimation.addImage("C:\graphics\sf2\LaneLampOn002.png")
        LaneLampOnAnimation.Interval = 250
        LaneLampOnAnimation.Duration = 4
        LaneLampOnAnimation.StayOnLastImage = 0
        mPinballDMD.PlayAnimation(LaneLampOnAnimation)
        mPinballDMD.updateDMDInfo()
        Me.mPinballDMD.AddScore(550)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UserControlCPinball1.Invalidate()
    End Sub

    Private Sub FormDMD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Not mKeyPRessed Then
            mKeyPRessed = True
            Select Case e.KeyChar.ToString.ToUpper
                Case Microsoft.VisualBasic.ChrW(Keys.A)
                    mPinballDMD.addCredit()
                Case Microsoft.VisualBasic.ChrW(Keys.B)
                    mPinballDMD.addPlayer()
                Case Microsoft.VisualBasic.ChrW(Keys.C)
                    mPinballDMD.Ramp()
                Case Microsoft.VisualBasic.ChrW(Keys.D)
                    mPinballDMD.TargetHit()
                Case Microsoft.VisualBasic.ChrW(Keys.E)
                    mPinballDMD.PlayAnimation()
                Case Microsoft.VisualBasic.ChrW(Keys.F)
                    Dim ballLeftAnimation = New CDMDAnimation
                    ballLeftAnimation.addImage("C:\graphics\sf2\ballleft001.png", 30)
                    ballLeftAnimation.addImage("C:\graphics\sf2\ballleft002.png", 30, 10)
                    ballLeftAnimation.Interval = 500
                    ballLeftAnimation.Duration = 2
                    ballLeftAnimation.StayOnLastImage = 2
                    mPinballDMD.BallLeft(ballLeftAnimation)
                Case Microsoft.VisualBasic.ChrW(Keys.Space)
                    If Me.FormBorderStyle = FormBorderStyle.None Then
                        Me.FormBorderStyle = FormBorderStyle.Sizable
                    Else
                        Me.FormBorderStyle = FormBorderStyle.None
                    End If
                Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                    Application.Exit()
            End Select
        End If
    End Sub

    Private Sub FormDMD_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        mKeyPRessed = False
    End Sub

    '--------------------------------------------------------------------------------------------------------
    ' Events
    '--------------------------------------------------------------------------------------------------------

    Private Sub OnSlingShot()
        mPinballDMD.AddScore(100)
    End Sub

    Private Sub OnLaneRightStateChange()
        mPinballDMD.AddScore(500)
    End Sub

    Private Sub OnLaneLeftStateChange()
        mPinballDMD.AddScore(500)
    End Sub

    Private Sub OnLaneRightExitStateChange()
        mPinballDMD.AddScore(2500)
    End Sub

    Private Sub OnLaneLeftExitStateChange()
        mPinballDMD.AddScore(2500)
    End Sub

    Private Sub OnBallLeft()
        Dim ballLeftAnimation = New CDMDAnimation
        ballLeftAnimation.addImage("C:\graphics\sf2\ballleft001.png", 30)
        ballLeftAnimation.addImage("C:\graphics\sf2\ballleft002.png", 30, 10)
        ballLeftAnimation.Interval = 500
        ballLeftAnimation.Duration = 2
        ballLeftAnimation.StayOnLastImage = 2
        mPinballDMD.BallLeft(ballLeftAnimation)
        mPinballDMD.updateDMDInfo()
        'Timer1.Start()
    End Sub

    Private Sub OnBumperHit(id As Integer)
        mPinballDMD.AddScore(5000)
        Select Case id
            Case 1
                mPinduino.Write("a")
            Case 2
                mPinduino.Write("z")
            Case 3
                mPinduino.Write("e")
        End Select

    End Sub

    Private Sub OnAllTargetsDropped()
        mPinballDMD.AddScore(10000)
        mPinduino.Write("rt")
    End Sub

    Private Sub OnTargetDrop(index As Integer)
        mPinballDMD.TargetHit()
        'mPinballDMD.AddScore(10000)

        Dim targetHitAnimation = New CDMDAnimation
        targetHitAnimation.addImage("C:\graphics\sf2\TargetHit001.png", 15)
        targetHitAnimation.addImage("C:\graphics\sf2\TargetHit002.png", 15)
        targetHitAnimation.addImage("C:\graphics\sf2\TargetHit003.png", 15)
        targetHitAnimation.Interval = 150
        targetHitAnimation.Duration = 3
        targetHitAnimation.StayOnLastImage = 0
        mPinballDMD.PlayAnimation(targetHitAnimation)
    End Sub

    Private Sub Receiver(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        'Do
        'Data = SerialPort2.ReadByte()
        'If Data <> 13 And Data <> 10 Then
        'addr = Data.ToString
        'End If
        'Loop Until (SerialPort2.BytesToRead() = 0)
        'Me.Invoke(New MethodInvoker(AddressOf Display)) 'Start "Display" on the UI thread
    End Sub

    Private Sub Display()
        'numero_table = Chr(addr)   
        ''Select Case Chr(addr)
        'Case "q"
        'SerialPort2.Write("a")
        'mTarget.State = Not mTarget.State
        'Case "s"
        'SerialPort2.Write("z")
        'Case "d"
        'SerialPort2.Write("e")
        'Case "f"
        'SerialPort2.Write("r")
        'Case "g"
        'SerialPort2.Write("t")
        'Case "h"
        'SerialPort2.Write("y")
        'Case "j"
        'SerialPort2.Write("u")
        'Case "k"
        'SerialPort2.Write("i")
        'End Select
        'S'erialPort1.Write(numero_table)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If mPinduino.IsOpen Then
            mPinduino.CloseSerial()
        End If
        mPinduino.OpenSerial()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#O22a")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#O23z")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#O24e")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#O25r")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#O26t")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#O27y")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#O28u")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#O29i")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#I30a")
        System.Threading.Thread.Sleep(100)
        mPinduino.Write("#I31b")
        System.Threading.Thread.Sleep(100)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        mPinduino.Write("&")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If mPinduino.IsOpen Then
            mPinduino.Write("@")
            'mPinduino.CloseSerial()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mPinduino.Write(TextBox1.Text)
    End Sub
End Class