Public Class UserControlDMD
    Private Property mDMD As CDMDScreen

    Public Property Interval As Integer
        Get
            Return Timer1.Interval
        End Get
        Set(value As Integer)
            Timer1.Interval = value
        End Set
    End Property


    Public Property DMD As CDMDScreen
        Get
            Return mDMD
        End Get
        Set(value As CDMDScreen)
            mDMD = value
            If mDMD IsNot Nothing Then
                '(x) * Me.PixelSize + x * Me.Space
                'Me.Width = 128 * 10
                'Me.Height = 40 * 10
                Me.Width = (mDMD.NBCols) * mDMD.PixelSize + mDMD.NBCols * mDMD.Space - mDMD.Space
                Me.Height = (mDMD.NBRows) * mDMD.PixelSize + mDMD.NBRows * mDMD.Space - mDMD.Space
            End If
            Me.Invalidate()
        End Set
    End Property

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        If mDMD IsNot Nothing Then
            mDMD.draw(e.Graphics)
        End If
    End Sub

    Private Sub UserControlDMD_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.PictureBox1.Invalidate()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Me.mDMD.update()
        'Me.Invalidate()
    End Sub

    Public Sub startTimer()
        Timer1.Start()
    End Sub

    Public Sub stopTimer()
        Timer1.Stop()
    End Sub
End Class
