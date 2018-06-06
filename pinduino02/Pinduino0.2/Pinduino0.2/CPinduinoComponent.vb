Public Class CPinduinoComponent

End Class

Public Class CPinduinoSwitch
    Inherits CPinduinoComponent

    Protected Property mCode As Char
    Protected Property mPin As Integer

    Public Property Pin As Integer
        Get
            Return mPin
        End Get
        Set(value As Integer)
            mPin = value
        End Set
    End Property

    Public Property Code As String
        Get
            Return mCode
        End Get
        Set(value As String)
            mCode = value
        End Set
    End Property

    Public ReadOnly Property Cmd4SetupPinduinoBoard As String
        Get
            Return "#I" & mPin.ToString & mCode
        End Get
    End Property

    Public Event DoAction()

    Public Sub New(pin As Integer, code As Char)
        mCode = code
        mPin = pin
    End Sub

    Public Sub Action(c As Char)
        If mCode = c Then
            'do something
            RaiseEvent DoAction()
        End If
    End Sub


End Class
