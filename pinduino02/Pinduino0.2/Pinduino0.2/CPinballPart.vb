Imports Pinduino0._2

Public Class CPinballPart

End Class

Public Class CPinballPartSwitch
    Inherits CPinballPart

    Public Event OnSwitchOn(obj As CPinballPartSwitch)

    Protected Property mCode As Char
    Protected Property mState As Boolean = False
    Public Property Code As Char
        Get
            Return mCode
        End Get
        Set(value As Char)
            mCode = value
        End Set
    End Property
    Public Property State As Boolean
        Get
            Return mState
        End Get
        Set(value As Boolean)
            mState = value
        End Set
    End Property

    Public Sub New(code As Char)
        mCode = code
    End Sub

    Public Sub Action(code As Char)
        If Me.Code = code Then
            Me.State = True
            RaiseEvent OnSwitchOn(Me)
        End If
    End Sub
End Class

Public Class CPinballPartSolenoid
    Inherits CPinballPart

    Protected Property mCode As Char
    Public ReadOnly Property Code As Char
        Get
            Return mCode
        End Get
    End Property

    Public Sub New(code As Char)
        mCode = code
    End Sub

End Class

Public Class CPinballTargets
    Inherits CPinballPart

    Protected Property mSwitchs As New List(Of CPinballPartSwitch)
    Protected Property mSolenoidLeft As CPinballPartSolenoid
    Protected Property mSolenoidRight As CPinballPartSolenoid
    Protected Property mSolenoidDownHalf As CPinballPartSolenoid

    Public ReadOnly Property IsAllTargetsDown
        Get
            Dim state As Boolean = True
            For Each item In mSwitchs
                If item.State = False Then
                    state = False
                End If
            Next
            Return state
        End Get
    End Property

    Public Event OnTargetsUp(code As String)
    Public Event OnTargetDown(obj As CPinballPartSwitch)
    Public Event OnAllTargetsDown()
    Public Event OnDownHalfTargetsWithSolenoid(code As Char)

    Public Sub New(nbTargets As Integer, actionCodeTargets As String, codeSolenoidLeft As Char, codeSolenoidRight As Char, codeSolenoidDownHalf As Char)
        If (actionCodeTargets.Count = nbTargets) Then
            For i = 0 To nbTargets - 1
                Dim switch As New CPinballPartSwitch(actionCodeTargets(i))
                AddHandler switch.OnSwitchOn, AddressOf Me.OnSwitchOn
                mSwitchs.Add(switch)
            Next
            mSolenoidLeft = New CPinballPartSolenoid(codeSolenoidLeft)
            mSolenoidRight = New CPinballPartSolenoid(codeSolenoidRight)
            mSolenoidDownHalf = New CPinballPartSolenoid(codeSolenoidDownHalf)
        End If
    End Sub

    Private Sub OnSwitchOn(obj As CPinballPartSwitch)
        Dim index As Integer
        index = mSwitchs.IndexOf(obj)
        If True Then ' Not obj.State Then
            'obj.State = True
            RaiseEvent OnTargetDown(obj)
            If Me.IsAllTargetsDown Then
                RaiseEvent OnAllTargetsDown()
                TargetsUp()
            End If
        End If
    End Sub

    Public Sub Action(code As Char)
        For Each item In mSwitchs
            item.Action(code)
        Next
    End Sub

    Public Sub TargetsUp()
        For Each item In mSwitchs
            item.State = False
        Next
        RaiseEvent OnTargetsUp(mSolenoidLeft.Code & mSolenoidRight.Code)
    End Sub

    Public Sub DownHalfTargetsWithSolenoid()
        RaiseEvent OnDownHalfTargetsWithSolenoid(mSolenoidDownHalf.Code)
    End Sub
End Class

Public Class CpinballPartLane
    Inherits CPinballPart

    Protected Property mSwitch As CPinballPartSwitch
    Protected Property mLightState As Boolean
    Public Property LightState As Boolean
        Get
            Return mLightState
        End Get
        Set(value As Boolean)
            mLightState = value
        End Set
    End Property

    Public Event OnLaneActivate(obj As CpinballPartLane)

    Public Sub New(code As Char)
        mSwitch = New CPinballPartSwitch(code)
        mLightState = False
        AddHandler mSwitch.OnSwitchOn, AddressOf mSwitch_OnSwitchOn
    End Sub

    Private Sub mSwitch_OnSwitchOn(obj As CPinballPartSwitch)
        'If Not mLightState Then
        mLightState = Not mLightState
        RaiseEvent OnLaneActivate(Me)
        'End If
    End Sub

    Public Sub Action(code As Char)
        mSwitch.Action(code)
    End Sub
End Class

Public Class CPinballPartLanes
    Inherits CPinballPart

    Protected Property mLanesSwitch As New List(Of CpinballPartLane)

    Public ReadOnly Property AllLightsOn
        Get
            Dim allOn As Boolean = True
            For Each item In mLanesSwitch
                If Not item.LightState Then
                    allOn = False
                End If
            Next
            Return allOn
        End Get
    End Property

    Public Event OnAllLightsActivate()
    Public Event OnLaneActivate()

    Public Sub New(nbLanes As Integer, codes As String)
        If codes.Count = nbLanes Then
            For i = 0 To nbLanes - 1
                Dim lane As New CpinballPartLane(codes(i))
                AddHandler lane.OnLaneActivate, AddressOf Lanes_OnLaneActivate
                mLanesSwitch.Add(lane)
            Next
        End If
    End Sub

    Private Sub Lanes_OnLaneActivate(obj As CpinballPartLane)
        RaiseEvent OnLaneActivate()
        If AllLightsOn Then
            AllLightsActivate()
        End If
    End Sub

    Private Sub AllLightsActivate()
        DesactivateAllLights()
        RaiseEvent OnAllLightsActivate()
    End Sub

    Public Sub DesactivateAllLights()
        For Each item In mLanesSwitch
            item.LightState = False
        Next
    End Sub

    Public Sub LightMoveLeft()
        If mLanesSwitch.Count > 1 Then
            Dim firstLigth As Boolean = mLanesSwitch.ElementAt(0).LightState
            For i = 0 To mLanesSwitch.Count - 2
                mLanesSwitch.ElementAt(i).LightState = mLanesSwitch.ElementAt(i + 1).LightState
            Next
            mLanesSwitch.ElementAt(mLanesSwitch.Count - 1).LightState = firstLigth
        End If
    End Sub

    Public Sub LightMoveRight()
        If mLanesSwitch.Count > 1 Then
            Dim lastLigth As Boolean = mLanesSwitch.ElementAt(mLanesSwitch.Count - 1).LightState
            For i = mLanesSwitch.Count - 1 To 1 Step -1
                mLanesSwitch.ElementAt(i).LightState = mLanesSwitch.ElementAt(i - 1).LightState
            Next
            mLanesSwitch.ElementAt(0).LightState = lastLigth
        End If
    End Sub

    Public Sub action(code As String)
        For Each item In mLanesSwitch
            item.Action(code)
        Next
    End Sub

End Class