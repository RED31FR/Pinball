Imports Pinball

Public Class UserControlLane
    Protected Property mLane As CPinballPartLane

    Public Property Lane As CPinballPartLane
        Get
            Return mLane
        End Get
        Set(value As CPinballPartLane)
            mLane = value
            If mLane IsNot Nothing Then
                AddHandler mLane.OnSwitchChange, AddressOf OnChangeSate
                Me.UserControlLamp1.Lamp = mLane.Lamp
            End If
        End Set
    End Property

    Private Sub UserControlLamp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = UserControlLamp1.Width
        Me.Height = UserControlLamp1.Height + 10 + Switch.Height
        If Me.mLane IsNot Nothing Then
            UserControlLamp1.Lamp = mLane.Lamp
        End If
    End Sub

    Private Sub OnChangeSate(e As CPinballPart, state As Boolean)
        If state Then
            mLane.Lamp.State = True
        Else
            mLane.Lamp.State = False
        End If
    End Sub

    Private Sub Switch_Click(sender As Object, e As EventArgs) Handles Switch.Click
        mLane.State = Not mLane.State
    End Sub

End Class
