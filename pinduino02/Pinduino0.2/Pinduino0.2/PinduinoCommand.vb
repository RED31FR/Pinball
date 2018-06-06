Public Class PinduinoCommand
    Public Property Cmd As String
    Public Property Pin As Integer
    Public Property Type As Integer
    Public Property CharCode As Char
    Public ReadOnly Property Label As String
        Get
            If Type = CPinduinoPortType.INPUT Then
                Return "Pin " & Pin.ToString & " is configure as Input port with code " & CharCode
            Else
                Return "Pin " & Pin.ToString & " is configure as Output port with code " & CharCode
            End If
        End Get
    End Property
End Class
