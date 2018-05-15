Public Class CPinballEvent
    Protected Property mDMD As CDMD = Nothing

    Public Property DMD As CDMD
        Get
            Return mDMD
        End Get
        Set(value As CDMD)
            mDMD = value
        End Set
    End Property

    Public Overridable Sub action(myDMDScreen As CDMDScreen)
        If mDMD IsNot Nothing Then
            myDMDScreen.addItem(mDMD)
        End If
    End Sub
End Class

Public Class CPinballEventScoreUp
    Inherits CPinballEvent

End Class

Public Class CPinballEventBumperHit
    Inherits CPinballEvent

End Class

Public Class CPinballEventRamp
    Inherits CPinballEvent

End Class

Public Class CPinballEventBallLock
    Inherits CPinballEvent

End Class

Public Class CPinballEventBallLoose
    Inherits CPinballEvent

End Class

Public Class CPinballEventBallLaunch
    Inherits CPinballEvent

End Class

Public Class CPinballEventQueue
    Protected Property mCDMDScreen As CDMDScreen
    Protected Property mQueue As New List(Of CPinballEvent)
    Protected Property mTimer As New Timer
    Protected Property mInterval As Integer

    Public Property Interval As Integer
        Get
            Return mTimer.Interval
        End Get
        Set(value As Integer)
            mTimer.Interval = value
        End Set
    End Property

    Public Sub New(myCDMDScreen As CDMDScreen)
        mCDMDScreen = myCDMDScreen
        AddHandler mTimer.Tick, AddressOf Me.Tick
    End Sub

    Private Sub Tick(sender As Object, e As EventArgs)
        If mQueue.Count > 0 Then
            Dim FirstEvent As CPinballEvent = mQueue.ElementAt(0)
            mQueue.Remove(FirstEvent)
            FirstEvent.action(mCDMDScreen)
        End If
    End Sub

    Public Sub startTimer()
        mTimer.Start()
    End Sub

    Public Sub stopTimer()
        mTimer.Stop()
    End Sub

    Public Sub addEvent(e As CPinballEvent)
        mQueue.Add(e)
    End Sub

    Public Sub clear()
        While mQueue.Count > 0
            'waiting taht the queue will be empty
        End While
    End Sub
End Class