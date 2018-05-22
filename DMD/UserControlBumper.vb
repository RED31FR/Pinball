Public Class UserControlBumper
    Protected Property mBumper As CPinballPartBumper

    Public Property Bumper As CPinballPartBumper
        Get
            Return mBumper
        End Get
        Set(value As CPinballPartBumper)
            mBumper = value
            If mBumper IsNot Nothing Then
                AddHandler mBumper.OnHit, AddressOf OnHit
            End If
        End Set
    End Property

    Private Sub OnHit()
        If Me.BumperPicture.BackColor = Color.Yellow Then
            Me.BumperPicture.BackColor = Color.Blue
        Else
            Me.BumperPicture.BackColor = Color.Yellow
        End If

        Dim rnd As New Random
        Me.BumperPicture.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))
    End Sub

    Private Sub UserControlBumper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Me.BumperPicture.Width
        Me.Height = Me.BumperPicture.Height
        AddHandler Me.BumperPicture.Click, AddressOf OnBumperHit
    End Sub

    Private Sub OnBumperHit(sender As Object, e As EventArgs)
        mBumper.Switch.State = True
    End Sub

    Private Sub BumperPicture_Click(sender As Object, e As EventArgs) Handles BumperPicture.Click

    End Sub

End Class
