Imports Pinball

Public Class FormPlayField
    Protected Property mLanes As New CPinballPartLanes(4)
    Protected Property mTargets As New CPinballPartTargets(9)
    Protected Property mBumper1 As New CPinballPartBumper
    Protected Property mBumper2 As New CPinballPartBumper
    Protected Property mBumper3 As New CPinballPartBumper
    Protected Property mSwitchBallOut As New CPinballPartSwitch
    Protected Property mSwitchSlingshotLeft As New CPinballPartSwitch
    Protected Property mSwitchSlingshotRight As New CPinballPartSwitch
    Protected Property mLaneLeft As New CPinballPartLane
    Protected Property mLaneLeftExit As New CPinballPartLane
    Protected Property mLaneRight As New CPinballPartLane
    Protected Property mLaneRightExit As New CPinballPartLane

    Public Event OnBallLeft()

    Public Event OnLaneLeftStateChange()
    Public Event OnLaneLeftExitStateChange()

    Public Event OnLaneRightStateChange()
    Public Event OnLaneRightExitStateChange()

    Public Event OnOneTargetDrop(index As Integer)
    Public Event OnAllTargetsDrop()

    Public Event OnBumperHit()

    Public Event OnSlingShot()

    Public Event OnLanesOneLampOn(index As Integer)
    Public Event OnLanesAllLampOn()

    Private Sub FormPlayField_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserControlLanes1.Lanes = mLanes
        UserControlTargets1.Targets = mTargets
        UserControlBumper1.Bumper = mBumper1
        UserControlBumper2.Bumper = mBumper2
        UserControlBumper3.Bumper = mBumper3
        UserControlSwitchBallExit.Switch = mSwitchBallOut
        UserControlSwitchSlingshotLeft.Switch = mSwitchSlingshotLeft
        UserControlSwitchSlingshotRight.Switch = mSwitchSlingshotRight
        UserControlLaneLeft.Lane = mLaneLeft
        UserControlLaneRight.Lane = mLaneRight
        UserControlLaneLeftExit.Lane = mLaneLeftExit
        UserControlLaneRightExit.Lane = mLaneRightExit

        AddHandler Me.mSwitchBallOut.SwitchOn, AddressOf Me.On_BallLeft

        AddHandler Me.mLaneLeft.OnSwitchChange, AddressOf Me.On_LaneLeftStateChange
        AddHandler Me.mLaneLeftExit.OnSwitchChange, AddressOf Me.On_LaneLeftExitStateChange

        AddHandler Me.mLaneRight.OnSwitchChange, AddressOf Me.On_LaneRightStateChange
        AddHandler Me.mLaneRightExit.OnSwitchChange, AddressOf Me.On_LaneRightExitStateChange

        AddHandler Me.mTargets.OnTargetDrop, AddressOf Me.On_OneTargetDrop
        AddHandler Me.mTargets.OnAllTargetsDropped, AddressOf Me.On_AllTargetsDrop

        AddHandler Me.mBumper1.OnHit, AddressOf Me.On_BumperHit
        AddHandler Me.mBumper2.OnHit, AddressOf Me.On_BumperHit
        AddHandler Me.mBumper3.OnHit, AddressOf Me.On_BumperHit

        AddHandler Me.mSwitchSlingshotLeft.SwitchOn, AddressOf Me.On_SlingShot
        AddHandler Me.mSwitchSlingshotRight.SwitchOn, AddressOf Me.On_SlingShot

        AddHandler Me.mLanes.OnLampOn, AddressOf Me.On_LanesOneLampOn
        AddHandler Me.mLanes.OnAllLampOn, AddressOf Me.On_LanesAllLampOn

    End Sub

    Private Sub On_LanesAllLampOn()
        RaiseEvent OnLanesAllLampOn()
    End Sub

    Private Sub On_LanesOneLampOn(index As Integer)
        If mLanes.Lanes.ElementAt(index).State Then
            RaiseEvent OnLanesOneLampOn(index)
        End If
    End Sub

    Private Sub On_SlingShot(e As CPinballPart)
        RaiseEvent OnSlingShot()
    End Sub

    Private Sub On_BumperHit()
        RaiseEvent OnBumperHit()
    End Sub

    Private Sub On_AllTargetsDrop()
        RaiseEvent OnAllTargetsDrop()
    End Sub

    Private Sub On_OneTargetDrop(index As Integer)
        RaiseEvent OnOneTargetDrop(index)
    End Sub

    Private Sub On_LaneRightExitStateChange(e As CPinballPart, state As Boolean)
        RaiseEvent OnLaneRightExitStateChange()
    End Sub

    Private Sub On_LaneRightStateChange(e As CPinballPart, state As Boolean)
        If (state) Then
            RaiseEvent OnLaneRightStateChange()
        End If
    End Sub

    Private Sub On_LaneLeftExitStateChange(e As CPinballPart, state As Boolean)
        RaiseEvent OnLaneLeftExitStateChange()
    End Sub

    Private Sub On_LaneLeftStateChange(e As CPinballPart, state As Boolean)
        If (state) Then
            RaiseEvent OnLaneLeftStateChange()
        End If
    End Sub

    Private Sub On_BallLeft(e As CPinballPart)
        mLanes.reset()
        mTargets.reset()
        mLaneLeft.reset()
        mLaneLeftExit.reset()
        mLaneRight.reset()
        mLaneRightExit.reset()
        RaiseEvent OnBallLeft()
    End Sub

End Class