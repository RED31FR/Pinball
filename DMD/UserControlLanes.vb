Public Class UserControlLanes
    Protected Property mLanes As CPinballPartLanes
    Protected Property mLamps As New List(Of CPinballPartLamp)

    Public Property Lanes As CPinballPartLanes
        Get
            Return mLanes
        End Get
        Set(value As CPinballPartLanes)
            mLanes = value

            Dim height As Integer = 0
            Dim x As Integer = 20
            Dim y As Integer = 0
            If mLanes IsNot Nothing Then
                Dim widthBonusLamp = mLanes.Lamps.Count * 30 + 10
                Dim widthNbLanes As Integer = 0
                For Each lane In mLanes.Lanes
                    Dim control As New UserControlLane()
                    control.Top = 0
                    control.Left = 0 + x
                    x += control.Width + 10
                    control.Lane = lane
                    Me.Controls.Add(control)
                    y = control.Top + 10 + control.Height
                    height = control.Height
                    widthNbLanes += control.Width + 10
                Next
                x = 0
                mLamps = mLanes.Lamps
                For Each lamp In Me.mLamps
                    Dim control As New UserControlLamp()
                    control.Top = 0 + y
                    control.Left = 0 + x
                    x += control.Width + 10
                    control.Lamp = lamp
                    Me.Controls.Add(control)
                Next
                If widthBonusLamp > widthNbLanes Then
                    Me.Width = widthBonusLamp
                Else
                    Me.Width = widthNbLanes
                End If
                Me.Width += 40
                height += 30 + 10
            End If
            Me.ButtonRight.Left = Me.Width - 5 - Me.ButtonRight.Width
            Me.Height = height
        End Set
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonRight.Click
        mLanes.SwitchRight()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonLeft.Click
        mLanes.SwitchLeft()
    End Sub
End Class
