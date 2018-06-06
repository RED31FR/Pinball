Public Class UserControlPinduinoPortConfig
    Public Event OnAddPort(cmd As String, pin As Integer, type As String, code As String)

    Private Sub CharCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CharCode.KeyPress
        Me.CharCode.Text = ""
        If Char.IsNumber(e.KeyChar) Then e.KeyChar = "a"
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim cmd As String = ""
        Dim type As String = ""
        If Input.Checked Then
            cmd &= "#I"
            type = "Input"
        End If
        If Output.Checked Then
            cmd &= "#O"
            type = "Output"
        End If
        cmd &= (PortNumber.SelectedIndex + 2).ToString & CharCode.Text
        RaiseEvent OnAddPort(cmd, PortNumber.SelectedIndex + 2, type, CharCode.Text)
    End Sub

    Private Sub UserControlPinduinoPortConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PortNumber.SelectedIndex = 0
    End Sub

End Class
