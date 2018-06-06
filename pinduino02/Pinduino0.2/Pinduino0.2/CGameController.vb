Imports Pinduino0._2

Public Class CGameController
    Protected Property mPinduino As New CPinduinoBoard
    Protected Property mTargets As New CPinballTargets(9, "abcdefghi", "A", "B", "C") 'pin 2 à 10 pour les inputs, pin 27 a 29 pour les outputs
    Protected Property mSwitchBallLost As New CPinballPartSwitch("j") 'pin 11
    Protected Property mBumperOne As New CPinballPartSwitch("k") 'pin 12
    Protected Property mBumperTwo As New CPinballPartSwitch("l") 'pin 13
    Protected Property mBumperThree As New CPinballPartSwitch("m") 'pin 14
    Protected Property mSlingshotLeft As New CPinballPartSwitch("n") 'pin 15
    Protected Property mSlingshotRight As New CPinballPartSwitch("o") 'pin 16
    Protected Property mInLaneLeft As New CPinballPartSwitch("p") 'pin 17
    Protected Property mInLaneRight As New CPinballPartSwitch("q") 'pin 18
    Protected Property mOutLaneLeft As New CPinballPartSwitch("r") 'pin 19
    Protected Property mOutLaneRight As New CPinballPartSwitch("s") 'pin 20
    Protected Property mBonusLanes As New CPinballPartLanes(4, "tuvw") 'pin 21 a 24
    Protected Property mLeftFlip As New CPinballPartSwitch("x") 'pin 25
    Protected Property mRightFlip As New CPinballPartSwitch("y") 'pin 26
    Protected Property mScore As Integer = 0
    Protected Property mSolenoidBallInGame As New CPinballPartSolenoid("D") 'pin 30
    Public Event OnScoreChange()

    Public Sub action(code As String)
        mTargets.Action(code)
        mSwitchBallLost.Action(code)
        mBumperOne.Action(code)
        mBumperTwo.Action(code)
        mBumperThree.Action(code)
        mSlingshotLeft.Action(code)
        mSlingshotRight.Action(code)
        mInLaneLeft.Action(code)
        mInLaneRight.Action(code)
        mOutLaneLeft.Action(code)
        mOutLaneRight.Action(code)
        mBonusLanes.action(code)
        mLeftFlip.Action(code)
        mRightFlip.Action(code)
    End Sub

    Public Property Score As Integer
        Get
            Return mScore
        End Get
        Set(value As Integer)
            mScore = value
            RaiseEvent OnScoreChange()
        End Set
    End Property
    Public Property Pinduino As CPinduinoBoard
        Get
            Return mPinduino
        End Get
        Set(value As CPinduinoBoard)
            mPinduino = value
            'AddHandler mPinduino.OnCommandSend, AddressOf mPinduino_OnCommandSend
            'AddHandler mPinduino.OnPinduinoClose, AddressOf mPinduino_OnPinduinoClose
            'AddHandler mPinduino.OnPinduinoOpen, AddressOf mPinduino_OnPinduinoOpen
            'AddHandler mPinduino.OnRunMode, AddressOf mPinduino_OnRunMode
            'AddHandler mPinduino.OnSetupMode, AddressOf mPinduino_OnSetupMode
            AddHandler mPinduino.OnSwitchOn, AddressOf mPinduino_OnSwitchOn
            'AddHandler mPinduino.OnLoadFile, AddressOf mPinduino_OnLoadFile
            'AddHandler mPinduino.OnSaveFile, AddressOf mPinduino_OnSaveFile
            'AddHandler mPinduino.OnDataReceiveFromBoard, AddressOf mPinduino_OnDataReceiveFromBoard
        End Set
    End Property

    Public Sub New()
        'handlers for Switch ball lost
        AddHandler mSwitchBallLost.OnSwitchOn, AddressOf mSwitchBallLoft_OnSwitchOn

        'handlers for Targets
        AddHandler mTargets.OnAllTargetsDown, AddressOf mTargets_OnAllTargetsDown
        AddHandler mTargets.OnDownHalfTargetsWithSolenoid, AddressOf mTargets_OnDownHalfTargetsWithSolenoid
        AddHandler mTargets.OnTargetDown, AddressOf mTargets_OnTargetDown
        AddHandler mTargets.OnTargetsUp, AddressOf mTargets_OnTargetsUp

        'handlers for Bumpers
        AddHandler mBumperOne.OnSwitchOn, AddressOf Bumpers_OnHit
        AddHandler mBumperTwo.OnSwitchOn, AddressOf Bumpers_OnHit
        AddHandler mBumperThree.OnSwitchOn, AddressOf Bumpers_OnHit

        'handlers for Slignshots
        AddHandler mSlingshotLeft.OnSwitchOn, AddressOf Slingshot_OnHit
        AddHandler mSlingshotRight.OnSwitchOn, AddressOf Slingshot_OnHit

        'handlers for InLanes
        AddHandler mInLaneLeft.OnSwitchOn, AddressOf InLane_OnSwitchOn
        AddHandler mInLaneRight.OnSwitchOn, AddressOf InLane_OnSwitchOn

        'handlers for OutLanes
        AddHandler mOutLaneLeft.OnSwitchOn, AddressOf OutLane_OnSwitchOn
        AddHandler mOutLaneRight.OnSwitchOn, AddressOf OutLane_OnSwitchOn

        'handlers for light Lanes
        AddHandler mBonusLanes.OnLaneActivate, AddressOf mLightLanes_OnLaneActivate
        AddHandler mBonusLanes.OnAllLightsActivate, AddressOf mLightLanes_OnAllLightsActivate

        'handlers fro Flippers
        AddHandler mLeftFlip.OnSwitchOn, AddressOf Flipper_OnSwitchOn
        AddHandler mRightFlip.OnSwitchOn, AddressOf Flipper_OnSwitchOn

    End Sub

    Private Sub Flipper_OnSwitchOn(obj As CPinballPartSwitch)
        If obj.Equals(mLeftFlip) Then
            mBonusLanes.LightMoveLeft()
        ElseIf obj.Equals(mRightFlip) Then
            mBonusLanes.LightMoveRight()
        End If
    End Sub

    Private Sub mLightLanes_OnAllLightsActivate()
        Score = 1
    End Sub

    Private Sub mLightLanes_OnLaneActivate()
        Score = 2
    End Sub

    Private Sub OutLane_OnSwitchOn(obj As CPinballPartSwitch)

        Score = 3
    End Sub

    Private Sub InLane_OnSwitchOn(obj As CPinballPartSwitch)

        Score = 4
    End Sub

    Private Sub Slingshot_OnHit(obj As CPinballPartSwitch)
        Score = 5
    End Sub

    Private Sub Bumpers_OnHit(obj As CPinballPartSwitch)
        Score = 6
    End Sub

    Private Sub mTargets_OnTargetsUp(code As String)
        mPinduino.Write(code)
    End Sub

    Private Sub mTargets_OnTargetDown(obj As CPinballPartSwitch)

        Score = 7
    End Sub

    Private Sub mTargets_OnDownHalfTargetsWithSolenoid(code As Char)

    End Sub

    Private Sub mTargets_OnAllTargetsDown()
        Score = 8
    End Sub

    Private Sub mPinduino_OnDataReceiveFromBoard(data As String)

    End Sub

    Private Sub mPinduino_OnSaveFile(path As String)

    End Sub

    Private Sub mPinduino_OnLoadFile(path As String)

    End Sub

    Private Sub mPinduino_OnSwitchOn(charCode As String)
        Me.action(charCode)
    End Sub

    Private Sub mPinduino_OnSetupMode()

    End Sub

    Private Sub mPinduino_OnRunMode()

    End Sub

    Private Sub mPinduino_OnPinduinoOpen()

    End Sub

    Private Sub mPinduino_OnPinduinoClose()

    End Sub

    Private Sub mPinduino_OnCommandSend(cmd As String, label As String)

    End Sub

    Private Sub mSwitchBallLoft_OnSwitchOn(obj As CPinballPartSwitch)
        If True Then 'test si il reste des billes et si pas extra ball
            mPinduino.Write(mSolenoidBallInGame.Code)
        End If
    End Sub

End Class
