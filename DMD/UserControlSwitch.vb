Public Class UserControlSwitch
    Protected Property mSwitch As CPinballPartSwitch

    Public Property Switch As CPinballPartSwitch
        Get
            Return mSwitch
        End Get
        Set(value As CPinballPartSwitch)
            mSwitch = value
        End Set
    End Property

    Private Sub UserControlSwitch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Me.ButtonSwitch.Width
        Me.Height = Me.ButtonSwitch.Height
    End Sub

    Private Sub ButtonSwitch_Click(sender As Object, e As EventArgs) Handles ButtonSwitch.Click
        mSwitch.State = True
    End Sub
End Class
