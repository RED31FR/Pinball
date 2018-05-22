Public Class UserControlTargets
    Protected Property mTargets As CPinballPartTargets
    'Protected Property mButtons As New List(Of Button)
    Protected Property mButtons As New List(Of UserControlTarget)

    Public Property Targets As CPinballPartTargets
        Get
            Return mTargets
        End Get
        Set(value As CPinballPartTargets)
            mTargets = value
            Dim x As Integer = 0
            Dim y As Integer = 0
            Me.Controls.Clear()
            Me.mButtons.Clear()

            If mTargets IsNot Nothing Then
                For Each target In mTargets.Targets
                    'Dim control As New Button
                    Dim control As New UserControlTarget
                    control.Top = 0
                    control.Left = x
                    'control.Width = 20
                    'control.Height = 20
                    x += control.Width + 2
                    control.BackColor = Color.Red
                    AddHandler control.Click, AddressOf Me.TargetHit
                    Me.Controls.Add(control)
                    Me.mButtons.Add(control)
                Next
                Me.Width = x - 2
                Me.Height = Me.mButtons.ElementAt(0).Height
                'Me.BackColor = Color.White
                AddHandler mTargets.OnTargetsUp, AddressOf Me.OnTargetsUp
            End If
        End Set
    End Property

    Private Sub TargetHit(sender As Object, e As EventArgs)
        If TypeOf sender Is UserControlTarget Then
            Dim obj As UserControlTarget = CType(sender, UserControlTarget)
            obj.TargetDown()
        End If

        'sender.BackColor = Color.Black
        mTargets.DropTarget(mButtons.IndexOf(sender))
    End Sub

    Private Sub OnTargetsUp()
        For Each button In mButtons
            'button.BackColor = Color.Red
            If TypeOf button Is UserControlTarget Then
                Dim obj As UserControlTarget = CType(button, UserControlTarget)
                obj.TargetUp()
            End If
        Next
    End Sub
End Class
