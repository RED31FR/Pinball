Public Class FormDMD
    Protected Property mPinballDMD As New CPinballDMD

    Private Sub FormDMD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserControlCPinball1.PinballDMD = mPinballDMD
        Me.Width = UserControlCPinball1.Width + 10
        Me.Height = UserControlCPinball1.Height + 20
        Timer1.Start()
    End Sub

    Private Sub FormDMD_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.A
                mPinballDMD.addCredit()
            Case Keys.B
                mPinballDMD.addPlayer()
            Case Keys.C
                mPinballDMD.Ramp()
            Case Keys.D
                mPinballDMD.TargetHit()
            Case Keys.E
                mPinballDMD.PlayAnimation()
            Case Keys.Space
                If Me.FormBorderStyle = FormBorderStyle.None Then
                    Me.FormBorderStyle = FormBorderStyle.Sizable
                Else
                    Me.FormBorderStyle = FormBorderStyle.None
                End If
            Case Keys.Escape
                Application.Exit()
        End Select
        UserControlCPinball1.Invalidate()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'mPinballDMD.update()
        UserControlCPinball1.Invalidate()
    End Sub
End Class