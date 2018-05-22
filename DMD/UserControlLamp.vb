Imports Pinball

Public Class UserControlLamp
    Protected Property mLamp As CPinballPartLamp

    Public Property Lamp As CPinballPartLamp
        Get
            Return mLamp
        End Get
        Set(value As CPinballPartLamp)
            mLamp = value
            If mLamp IsNot Nothing Then
                AddHandler mLamp.SwitchOn, AddressOf Me.OnLampOn
                AddHandler mLamp.SwitchOff, AddressOf Me.OnLampOff
            End If
        End Set
    End Property

    Private Sub OnLampOff()
        'PictureBox1.BackColor = Color.Gray
        PictureBox1.BackgroundImage = Bitmap.FromFile("C:\graphics\pinballpart\lampOff001.png")
    End Sub

    Private Sub OnLampOn(e As CPinballPart)
        'PictureBox1.BackColor = Color.Green
        PictureBox1.BackgroundImage = Bitmap.FromFile("C:\graphics\pinballpart\lampOn001.png")
    End Sub

    Public Property State As Boolean
        Get
            Return mLamp.State
        End Get
        Set(value As Boolean)
            mLamp.State = State
            If mLamp.State Then
                PictureBox1.BackgroundImage = Bitmap.FromFile("C:\graphics\pinballpart\lampOn001.png")
                'PictureBox1.BackColor = Color.Green
            Else
                'PictureBox1.BackColor = Color.Gray
                PictureBox1.BackgroundImage = Bitmap.FromFile("C:\graphics\pinballpart\lampOff001.png")
            End If
        End Set
    End Property

    Private Sub UserControlLamp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PictureBox1.BackColor = Color.Gray
    End Sub
End Class
