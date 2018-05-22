Imports Pinball

Public Class FormDMD
    Protected Property mPinballDMD As New CPinballDMD
    Protected Property mKeyPRessed As Boolean = False
    Protected Property mTarget As New CPinballPartTarget


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


        f.Show()
        Timer1.Start()
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

    Private Sub OnBumperHit()
        mPinballDMD.AddScore(5000)
    End Sub

    Private Sub OnAllTargetsDropped()
        mPinballDMD.AddScore(10000)
        'mPinballDMD.Ramp()
    End Sub

    Private Sub OnTargetDrop(index As Integer)
        mPinballDMD.TargetHit()
        mPinballDMD.AddScore(10000)

        Dim targetHitAnimation = New CDMDAnimation
        targetHitAnimation.addImage("C:\graphics\sf2\TargetHit001.png", 15)
        targetHitAnimation.addImage("C:\graphics\sf2\TargetHit002.png", 15)
        targetHitAnimation.addImage("C:\graphics\sf2\TargetHit003.png", 15)
        targetHitAnimation.Interval = 150
        targetHitAnimation.Duration = 3
        targetHitAnimation.StayOnLastImage = 0
        mPinballDMD.PlayAnimation(targetHitAnimation)
    End Sub

End Class