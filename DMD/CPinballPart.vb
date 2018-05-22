Imports Pinball

Public Class CPinballPart
    Public Overridable Sub reset()

    End Sub
End Class

Public Class CPinballPartBoolean
    Inherits CPinballPart
    Protected Property mState As Boolean = False

    Public Property State As Boolean
        Get
            Return mState
        End Get
        Set(value As Boolean)
            mState = value
            If mState Then
                RaiseEvent SwitchOn(Me)
            Else
                RaiseEvent SwitchOff()
            End If
        End Set
    End Property

    Public Event SwitchOn(e As CPinballPart)
    Public Event SwitchOff()

    Public Overrides Sub reset()
        MyBase.reset()
        Me.State = False
    End Sub
End Class

Public Class CPinballPartSwitch
    Inherits CPinballPartBoolean

    Public Sub New()

    End Sub
End Class

Public Class CPinballPartLamp
    Inherits CPinballPartBoolean

End Class

Public Class CPinballPartTarget
    Inherits CPinballPartBoolean

End Class

Public Class CpinballPartCoil
    Inherits CPinballPart

    Public Sub activate()

    End Sub
End Class

Public Class CPinballPartTargets
    Inherits CPinballPart

    Protected Property mTargets As New List(Of CPinballPartTarget)
    Protected Property mCoilLeftTargetsUp As CpinballPartCoil
    Protected Property mCoilRightTargetsUp As CpinballPartCoil
    Protected Property mCoilTargetsDown As CpinballPartCoil

    Public ReadOnly Property Targets As List(Of CPinballPartTarget)
        Get
            Return mTargets
        End Get
    End Property

    Public Event OnTargetDrop(index As Integer)
    Public Event OnTargetsUp()
    Public Event OnAllTargetsDropped()

    Public Sub New(nbTargets As Integer)
        For i = 0 To nbTargets - 1
            Dim mTarget As New CPinballPartTarget
            AddHandler mTarget.SwitchOn, AddressOf Me.targetDrop
            mTargets.Add(mTarget)
        Next
        mCoilLeftTargetsUp = New CpinballPartCoil
        mCoilRightTargetsUp = New CpinballPartCoil
        mCoilTargetsDown = New CpinballPartCoil
    End Sub

    Private Sub targetDrop(e As CPinballPart)
        RaiseEvent OnTargetDrop(mTargets.IndexOf(e))
        If Me.AllTargetsDown Then
            RaiseEvent OnAllTargetsDropped()
            Me.TargetsUp()
        End If
    End Sub

    Public Sub TargetsUp()
        mCoilLeftTargetsUp.activate()
        mCoilRightTargetsUp.activate()
        RaiseEvent OnTargetsUp()
        For Each target In mTargets
            target.State = False
        Next
    End Sub

    Public Function AllTargetsDown() As Boolean
        Dim state As Boolean = True
        For Each target In mTargets
            If Not target.State Then
                state = False
            End If
        Next
        Return state
    End Function

    Public Sub DropTarget(index As Integer)
        If index < mTargets.Count Then
            If (Not mTargets.ElementAt(index).State) Then
                mTargets.ElementAt(index).State = True
            End If
        End If
    End Sub

    Public Overrides Sub reset()
        MyBase.reset()
        For Each target In mTargets
            target.reset()
        Next
        TargetsUp()
    End Sub
End Class

Public Class CPinballPartLane
    Inherits CPinballPart

    Protected Property mSwitch As New CPinballPartSwitch
    Protected Property mLamp As New CPinballPartLamp

    Public ReadOnly Property Lamp As CPinballPartLamp
        Get
            Return mLamp
        End Get
    End Property

    Public Property State As Boolean
        Get
            Return mSwitch.State
        End Get
        Set(value As Boolean)
            mSwitch.State = value
            mLamp.State = mSwitch.State
        End Set
    End Property

    Public Event OnSwitchChange(e As CPinballPart, state As Boolean)

    Public Sub New()
        AddHandler mSwitch.SwitchOn, AddressOf Me.OnSwitchOn
        AddHandler mSwitch.SwitchOff, AddressOf Me.OnSwitchOff
    End Sub

    Private Sub OnSwitchOff()
        mLamp.State = False
        RaiseEvent OnSwitchChange(Me, False)
    End Sub

    Private Sub OnSwitchOn(e As CPinballPart)
        mLamp.State = True
        RaiseEvent OnSwitchChange(Me, True)
    End Sub

    Public Overrides Sub reset()
        MyBase.reset()
        mSwitch.reset()
        mLamp.reset()
    End Sub

End Class

Public Class CPinballPartLanes
    Inherits CPinballPart

    Protected Property mLanes As New List(Of CPinballPartLane)
    Protected Property mLamps As New List(Of CPinballPartLamp)
    Protected Property mBonus As Integer = 0

    Public Event OnLampOn(index As Integer)
    Public Event OnAllLampOn()

    Public ReadOnly Property Bonus As Integer
        Get
            Return mBonus * 2
        End Get
    End Property

    Public ReadOnly Property Lanes As List(Of CPinballPartLane)
        Get
            Return mLanes
        End Get
    End Property

    Public ReadOnly Property Lamps As List(Of CPinballPartLamp)
        Get
            Return mLamps
        End Get
    End Property

    Public Sub New(nb As Integer)
        For i = 0 To nb - 1
            Dim lane As New CPinballPartLane
            AddHandler lane.OnSwitchChange, AddressOf Me.OnLaneStateChanged

            mLanes.Add(lane)
        Next
        mLamps.Add(New CPinballPartLamp)
        mLamps.Add(New CPinballPartLamp)
        mLamps.Add(New CPinballPartLamp)
        mLamps.Add(New CPinballPartLamp)
        mLamps.Add(New CPinballPartLamp)
    End Sub

    Private Sub OnLaneStateChanged(e As CPinballPart, state As Boolean)
        Dim all As Boolean = True
        RaiseEvent OnLampOn(mLanes.IndexOf(e))
        For Each Lane In mLanes
            If Not Lane.State Then
                all = False
            End If
        Next
        If all Then
            RaiseEvent OnAllLampOn()
            If mBonus < mLamps.Count Then
                mLamps.ElementAt(mBonus).State = True
                mBonus += 1
            End If
            For Each lane In mLanes
                lane.State = False
            Next
        End If
    End Sub

    Public Sub SwitchLeft()
        Dim values(mLanes.Count + 1) As Boolean
        Dim pos As Integer = 1
        For Each lane In mLanes
            values(pos) = lane.State
            pos += 1
        Next
        For i = 1 To values.Count - 1
            values(i - 1) = values(i)
        Next
        For Each Lane In mLanes
            Lane.State = False
        Next
        For i = 1 To values.Count - 2
            mLanes.ElementAt(i - 1).State = values(i)
        Next
        mLanes.ElementAt(mLanes.Count - 1).State = values(0)
    End Sub

    Public Sub SwitchRight()
        Dim values(mLanes.Count + 1) As Boolean
        Dim pos As Integer = 1
        For Each lane In mLanes
            values(pos) = lane.State
            pos += 1
        Next
        For i = values.Count - 1 To 1 Step -1
            values(i) = values(i - 1)
        Next
        For Each Lane In mLanes
            Lane.State = False
        Next
        For i = 1 To values.Count - 2
            mLanes.ElementAt(i - 1).State = values(i)
        Next
        mLanes.ElementAt(0).State = values(values.Count - 1)
    End Sub

    Public Overrides Sub reset()
        MyBase.reset()
        For Each lane In mLanes
            lane.reset()
        Next
        For Each lamp In Me.mLamps
            lamp.reset()
        Next
    End Sub
End Class

Public Class CPinballPartBumper
    Inherits CPinballPartBoolean

    Protected Property mSwitch As New CPinballPartSwitch

    Public ReadOnly Property Switch As CPinballPartSwitch
        Get
            Return mSwitch
        End Get
    End Property

    Public Event OnHit()

    Public Sub New()
        AddHandler mSwitch.SwitchOn, AddressOf BumperSwitchOn
        AddHandler mSwitch.SwitchOff, AddressOf BumperSwitchOff
    End Sub

    Private Sub BumperSwitchOff()

    End Sub

    Private Sub BumperSwitchOn(e As CPinballPart)
        Hit()
    End Sub

    Public Sub Hit()
        mSwitch.State = False
        Me.State = mSwitch.State
        RaiseEvent OnHit()
    End Sub
End Class