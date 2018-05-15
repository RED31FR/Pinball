Public Class UserControlCPinball
    Protected Property mPinballDMD As CPinballDMD
    Public Property PinballDMD As CPinballDMD
        Get
            Return mPinballDMD
        End Get
        Set(value As CPinballDMD)
            mPinballDMD = value
            If mPinballDMD IsNot Nothing Then
                Me.UserControlDMDScore.DMD = mPinballDMD.DMDScore
                Me.UserControlDMDInfo.DMD = mPinballDMD.DMDInfo
                Me.UserControlDMDInfo.Top = Me.UserControlDMDScore.Top + Me.UserControlDMDScore.Height
                Me.Height = UserControlDMDScore.Height + UserControlDMDInfo.Height + 20
                Me.Width = UserControlDMDScore.Width + 5
            End If
        End Set
    End Property

    Private Sub UserControlCPinball_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        UserControlDMDInfo.Invalidate()
        UserControlDMDScore.Invalidate()
    End Sub

End Class
