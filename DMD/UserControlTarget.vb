Imports Pinball

Public Class UserControlTarget
    Protected Property mTarget As CPinballPartTarget

    Public Property Target As CPinballPartTarget
        Get
            Return mTarget
        End Get
        Set(value As CPinballPartTarget)
            mTarget = value
            If mTarget IsNot Nothing Then
                AddHandler mTarget.SwitchOn, AddressOf Me.OnTargetUp
                AddHandler mTarget.SwitchOff, AddressOf Me.OnTargetDown
            End If
        End Set
    End Property

    Public Sub TargetDown()
        'mTarget.State = False
        Me.BackgroundImage = Bitmap.FromFile("C:\graphics\pinballpart\TargetOFF001.png")
    End Sub

    Public Sub TargetUp()
        'mTarget.State = True
        Me.BackgroundImage = Bitmap.FromFile("C:\graphics\pinballpart\TargetON001.png")
    End Sub

    Private Sub OnTargetDown()
        Me.BackgroundImage = Bitmap.FromFile("C:\graphics\pinballpart\TargetOFF001.png")
    End Sub

    Private Sub OnTargetUp(e As CPinballPart)
        Me.BackgroundImage = Bitmap.FromFile("C:\graphics\pinballpart\TargetON001.png")
    End Sub

End Class
