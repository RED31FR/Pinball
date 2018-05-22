Imports System.IO
Imports Pinball


Public Class CDMDPixel
    Private Property mSize As Integer
    Private Property mColor As Color
    Private Property mX As Integer
    Private Property mY As Integer

    Public Property Size As Integer
        Get
            Return mSize
        End Get
        Set(value As Integer)
            mSize = value
        End Set
    End Property

    Public Property Color As Color
        Get
            Return mColor
        End Get
        Set(value As Color)
            mColor = value
        End Set
    End Property

    Public Property X As Integer
        Get
            Return mX
        End Get
        Set(value As Integer)
            mX = value
        End Set
    End Property

    Public Property Y As Integer
        Get
            Return mY
        End Get
        Set(value As Integer)
            mY = value
        End Set
    End Property

    Public Sub New(size As Integer, color As Color, x As Integer, y As Integer)
        mSize = size
        mColor = color
        mX = x
        mY = y
    End Sub

    Public Sub drawAt(ByVal g As Graphics, x As Integer, y As Integer)
        ' Create pen.
        Dim myPen As New Pen(mColor)

        ' Create rectangle.
        Dim rect As New Rectangle(x, y, mSize, mSize)

        ' Draw rectangle to screen.
        'g.DrawRectangle(myPen, rect)
        g.DrawEllipse(myPen, rect)
    End Sub

    Public Sub draw(ByVal g As Graphics, Optional x As Integer = 0, Optional y As Integer = 0)
        ' Create rectangle.
        Dim rect As New Rectangle(mX + x, mY + y, mSize, mSize)

        ' Create pen.
        'Dim myPen As New Pen(mColor)        

        ' Draw rectangle to screen.
        'g.DrawRectangle(myPen, rect)

        Dim myBrush = New SolidBrush(mColor)

        'g.FillRectangle(myBrush, rect)
        g.FillEllipse(myBrush, rect)
    End Sub

End Class

Public Class CDMD
    Protected Property mCols As Integer
    Protected Property mRows As Integer
    Protected Property mSpace As Integer
    Protected Property mPixelSize As Integer
    Protected Property mPixels As New List(Of CDMDPixel)
    Protected Property mX As Integer = 0
    Protected Property mY As Integer = 0
    Protected Property mNbUpdate As Integer
    Protected Property mCanBeDisable As Boolean = False
    Protected Property mEnable As Boolean = True
    Protected Property mVisible As Boolean = True

    Public Property Visible As Boolean
        Get
            Return mVisible
        End Get
        Set(value As Boolean)
            mVisible = value
        End Set
    End Property

    Public Property Enable As Boolean
        Get
            Return mEnable
        End Get
        Set(value As Boolean)
            mEnable = value
        End Set
    End Property

    Public Property Duration As Integer
        Get
            Return mNbUpdate
        End Get
        Set(value As Integer)
            mCanBeDisable = True
            mNbUpdate = value
        End Set
    End Property

    Public Property PixelSize As Integer
        Get
            Return mPixelSize
        End Get
        Set(value As Integer)
            mPixelSize = value
        End Set
    End Property

    Public Property NBCols As Integer
        Get
            Return mCols
        End Get
        Set(value As Integer)
            mCols = value
        End Set
    End Property

    Public Property NBRows As Integer
        Get
            Return mRows
        End Get
        Set(value As Integer)
            mRows = value
        End Set
    End Property

    Public Property Space As Integer
        Get
            Return mSpace
        End Get
        Set(value As Integer)
            mSpace = value
        End Set
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return mPixels.Count
        End Get
    End Property

    Public Sub addPixel(p As CDMDPixel)
        If True Then ' (p.X < NBCols And p.Y < NBRows) Then
            mPixels.Add(New CDMDPixel(p.Size, p.Color, (p.X) * Me.PixelSize + p.X * Me.Space, (p.Y) * Me.PixelSize + p.Y * Me.Space))
        End If
    End Sub

    Public Sub addPixel(color As Color, x As Integer, y As Integer)
        If True Then '(x < NBCols And y < NBRows) Then
            mPixels.Add(New CDMDPixel(Me.mPixelSize, color, (x) * Me.PixelSize + x * Me.Space, (y) * Me.PixelSize + y * Me.Space))
        End If
    End Sub

    Public Sub clear()
        mPixels.Clear()
    End Sub

    Public Sub draw(g As Graphics, Optional x As Integer = 0, Optional y As Integer = 0)
        If Me.Enable And Me.Visible Then
            For Each pixel In mPixels
                If True Then 'pixel.X >= 0 And pixel.X < (Me.NBCols) * Me.PixelSize + Me.NBCols * Me.Space And pixel.Y >= 0 And pixel.Y < (Me.NBRows) * Me.PixelSize + Me.NBRows * Me.Space Then
                    pixel.draw(g, x, y)
                Else
                    Dim i = 0
                End If
            Next
        End If
    End Sub

    Protected Function LoadFile(ImageFilePath As String) As Bitmap
        Dim fs As IO.FileStream
        ' Specify a valid picture file path on your computer.
        fs = New System.IO.FileStream(ImageFilePath, FileMode.Open, FileAccess.Read)
        Dim img As Bitmap = System.Drawing.Image.FromStream(fs)
        fs.Close()
        Return img
    End Function

    Public Sub addFromFileTo(File As String, x As Integer, y As Integer)
        Dim img As Bitmap
        'Dim brush As SolidBrush
        img = Me.LoadFile(File)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                'brush = New SolidBrush(img.GetPixel(i, j))
                Me.addPixel(img.GetPixel(i, j), i + x, j + y)
            Next
        Next
    End Sub

    Public Sub loadFromFile(file As String, Optional x As Integer = 0, Optional y As Integer = 0)
        mPixels.Clear()
        Dim img As Bitmap
        'Dim brush As SolidBrush
        img = Me.LoadFile(file)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                'brush = New SolidBrush(img.GetPixel(i, j))
                Me.addPixel(img.GetPixel(i, j), i + x, j + y)
            Next

        Next
    End Sub

    Public Sub moveToRight(value As Integer)
        Dim tmp As New List(Of CDMDPixel)
        For Each pixel In mPixels
            pixel.X += value * Me.mPixelSize
            '(x) * Me.PixelSize + x * Me.Space
            If pixel.X > Me.NBCols * Me.mPixelSize + Me.NBCols * Me.Space Then
                'tmp.Add(pixel)
            End If
        Next
        For Each pixel In tmp
            mPixels.Remove(pixel)
        Next
    End Sub

    Public Sub moveToLeft(value As Integer)
        Dim tmp As New List(Of CDMDPixel)
        For Each pixel In mPixels
            pixel.X -= value * Me.mPixelSize
            If pixel.X < 0 Then
                'tmp.Add(pixel)
            End If
        Next
        For Each pixel In tmp
            mPixels.Remove(pixel)
        Next
    End Sub

    Public Sub AddCaracterAt(C As CDMDCaracter, Optional x As Integer = 0, Optional y As Integer = 0)
        For Each pixel In C.mPixels
            Me.addPixel(pixel.Color, pixel.X + x, pixel.Y + y)
            'mPixels.Add(New CDMDPixel(pixel.Size, pixel.Color, pixel.X + x, pixel.Y + y))
        Next
    End Sub

    Public Sub AddStringAt(s As CDMDString, Optional x As Integer = 0, Optional y As Integer = 0)
        For Each pixel In s.mPixels
            Me.addPixel(pixel.Color, pixel.X + x, pixel.Y + y)
            'mPixels.Add(New CDMDPixel(pixel.Size, pixel.Color, pixel.X + x, pixel.Y + y))
        Next
    End Sub

    Public Sub addImageAt(i As CDMDImage, Optional x As Integer = 0, Optional y As Integer = 0)
        For Each pixel In i.mPixels
            Me.addPixel(pixel.Color, pixel.X + x, pixel.Y + y)
            'mPixels.Add(New CDMDPixel(pixel.Size, pixel.Color, pixel.X + x, pixel.Y + y))
        Next
    End Sub

    Public Overridable Sub update()
        mNbUpdate -= 1
        If mNbUpdate < 0 And mCanBeDisable Then
            Me.Enable = False
        End If
    End Sub
End Class

Public Class CDMDImage
    Inherits CDMDCaracter

    Public Sub New(pixelSize As Integer)
        MyBase.New
        Me.PixelSize = pixelSize
    End Sub

    Public Sub New(file As String, Optional x As Integer = 0, Optional y As Integer = 0)
        MyBase.New(file, x, y)
    End Sub
End Class

Public Class CDMDCaracter
    Inherits CDMD

    Public Sub New()

    End Sub

    Public Sub New(file As String, Optional x As Integer = 0, Optional y As Integer = 0)
        Me.LoadCaracterFromImage(file, x, y)
    End Sub

    Public Sub LoadCaracterFromImage(file As String, Optional x As Integer = 0, Optional y As Integer = 0)
        Me.Space = 0
        Me.PixelSize = 1
        mPixels.Clear()

        Dim img As Bitmap
        'Dim brush As SolidBrush
        img = MyBase.LoadFile(file)
        Me.NBCols = img.Width
        Me.NBRows = img.Height
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                'brush = New SolidBrush(img.GetPixel(i, j))
                Me.addPixel(img.GetPixel(i, j), i + x, j + y)
            Next
        Next
    End Sub
End Class

Public Class CDMDString
    Inherits CDMD

    Protected Property mPosition As Integer = 0
    Protected Property mLetters As New List(Of CDMDCaracter)
    Protected Property mNBCaracters As Integer = 0
    Protected Property mNBColsForString As Integer = 0

    Public ReadOnly Property NBCharacters As Integer
        Get
            Return mNBCaracters
        End Get
    End Property

    Public ReadOnly Property NBColsForString As Integer
        Get
            Return mNBColsForString
        End Get
    End Property

    Public Sub New(fontPath As String, pixelSize As Integer, Optional space As Integer = 1)
        Dim letters(65) As String
        Dim pos As Integer = 0
        Me.Space = 1
        letters(pos) = "al.png"
        pos = pos + 1
        letters(pos) = "bl.png"
        pos = pos + 1
        letters(pos) = "cl.png"
        pos = pos + 1
        letters(pos) = "dl.png"
        pos = pos + 1
        letters(pos) = "el.png"
        pos = pos + 1
        letters(pos) = "fl.png"
        pos = pos + 1
        letters(pos) = "gl.png"
        pos = pos + 1
        letters(pos) = "hl.png"
        pos = pos + 1
        letters(pos) = "il.png"
        pos = pos + 1
        letters(pos) = "jl.png"
        pos = pos + 1
        letters(pos) = "kl.png"
        pos = pos + 1
        letters(pos) = "ll.png"
        pos = pos + 1
        letters(pos) = "ml.png"
        pos = pos + 1
        letters(pos) = "nl.png"
        pos = pos + 1
        letters(pos) = "ol.png"
        pos = pos + 1
        letters(pos) = "pl.png"
        pos = pos + 1
        letters(pos) = "ql.png"
        pos = pos + 1
        letters(pos) = "rl.png"
        pos = pos + 1
        letters(pos) = "sl.png"
        pos = pos + 1
        letters(pos) = "tl.png"
        pos = pos + 1
        letters(pos) = "ul.png"
        pos = pos + 1
        letters(pos) = "vl.png"
        pos = pos + 1
        letters(pos) = "wl.png"
        pos = pos + 1
        letters(pos) = "xl.png"
        pos = pos + 1
        letters(pos) = "yl.png"
        pos = pos + 1
        letters(pos) = "zl.png"
        pos = pos + 1
        letters(pos) = "0.png"
        pos = pos + 1
        letters(pos) = "1.png"
        pos = pos + 1
        letters(pos) = "2.png"
        pos = pos + 1
        letters(pos) = "3.png"
        pos = pos + 1
        letters(pos) = "4.png"
        pos = pos + 1
        letters(pos) = "5.png"
        pos = pos + 1
        letters(pos) = "6.png"
        pos = pos + 1
        letters(pos) = "7.png"
        pos = pos + 1
        letters(pos) = "8.png"
        pos = pos + 1
        letters(pos) = "9.png"
        pos = pos + 1
        letters(pos) = "space.png"
        pos = pos + 1
        letters(pos) = "dot.png"
        pos = pos + 1
        letters(pos) = "au.png"
        pos = pos + 1
        letters(pos) = "bu.png"
        pos = pos + 1
        letters(pos) = "cu.png"
        pos = pos + 1
        letters(pos) = "du.png"
        pos = pos + 1
        letters(pos) = "eu.png"
        pos = pos + 1
        letters(pos) = "fu.png"
        pos = pos + 1
        letters(pos) = "gu.png"
        pos = pos + 1
        letters(pos) = "hu.png"
        pos = pos + 1
        letters(pos) = "iu.png"
        pos = pos + 1
        letters(pos) = "ju.png"
        pos = pos + 1
        letters(pos) = "ku.png"
        pos = pos + 1
        letters(pos) = "lu.png"
        pos = pos + 1
        letters(pos) = "mu.png"
        pos = pos + 1
        letters(pos) = "nu.png"
        pos = pos + 1
        letters(pos) = "ou.png"
        pos = pos + 1
        letters(pos) = "pu.png"
        pos = pos + 1
        letters(pos) = "qu.png"
        pos = pos + 1
        letters(pos) = "ru.png"
        pos = pos + 1
        letters(pos) = "su.png"
        pos = pos + 1
        letters(pos) = "tu.png"
        pos = pos + 1
        letters(pos) = "uu.png"
        pos = pos + 1
        letters(pos) = "vu.png"
        pos = pos + 1
        letters(pos) = "wu.png"
        pos = pos + 1
        letters(pos) = "xu.png"
        pos = pos + 1
        letters(pos) = "yu.png"
        pos = pos + 1
        letters(pos) = "zu.png"
        pos = pos + 1
        letters(pos) = "slash.png"
        pos = pos + 1
        Me.Space = 0
        Me.PixelSize = 1
        clearString()
        If (Directory.Exists(fontPath)) Then
            For Each letter In letters
                If File.Exists(fontPath + "\" + letter) Then
                    Dim DMDLetter As New CDMDCaracter
                    DMDLetter.LoadCaracterFromImage(fontPath + "\" + letter)
                    mLetters.Add(DMDLetter)
                End If

            Next
        End If
        Me.PixelSize = pixelSize
    End Sub

    Public Sub AddCaracter(c As CDMDCaracter, Optional x As Integer = 0, Optional y As Integer = 0)
        Me.NBCols += c.NBCols + 1
        Me.NBRows = c.NBRows
        Me.AddCaracterAt(c, mPosition + x, 0 + y)
        mPosition += c.NBCols + 1
        mNBCaracters += 1
        mNBColsForString += c.NBCols + 1
    End Sub

    Public Sub AddCaracter(index As Integer)
        If index < mLetters.Count Then
            AddCaracter(mLetters.ElementAt(index))
        End If
    End Sub

    Public Sub AddCaracter(c As String, Optional x As Integer = 0, Optional y As Integer = 0)
        Select Case c
            Case "a"
                AddCaracter(mLetters.ElementAt(0), x, y)
            Case "b"
                AddCaracter(mLetters.ElementAt(1), x, y)
            Case "c"
                AddCaracter(mLetters.ElementAt(2), x, y)
            Case "d"
                AddCaracter(mLetters.ElementAt(3), x, y)
            Case "e"
                AddCaracter(mLetters.ElementAt(4), x, y)
            Case "f"
                AddCaracter(mLetters.ElementAt(5), x, y)
            Case "g"
                AddCaracter(mLetters.ElementAt(6), x, y)
            Case "h"
                AddCaracter(mLetters.ElementAt(7), x, y)
            Case "i"
                AddCaracter(mLetters.ElementAt(8), x, y)
            Case "j"
                AddCaracter(mLetters.ElementAt(9), x, y)
            Case "k"
                AddCaracter(mLetters.ElementAt(10), x, y)
            Case "l"
                AddCaracter(mLetters.ElementAt(11), x, y)
            Case "m"
                AddCaracter(mLetters.ElementAt(12), x, y)
            Case "n"
                AddCaracter(mLetters.ElementAt(13), x, y)
            Case "o"
                AddCaracter(mLetters.ElementAt(14), x, y)
            Case "p"
                AddCaracter(mLetters.ElementAt(15), x, y)
            Case "q"
                AddCaracter(mLetters.ElementAt(16), x, y)
            Case "r"
                AddCaracter(mLetters.ElementAt(17), x, y)
            Case "s"
                AddCaracter(mLetters.ElementAt(18), x, y)
            Case "t"
                AddCaracter(mLetters.ElementAt(19), x, y)
            Case "u"
                AddCaracter(mLetters.ElementAt(20), x, y)
            Case "v"
                AddCaracter(mLetters.ElementAt(21), x, y)
            Case "w"
                AddCaracter(mLetters.ElementAt(22), x, y)
            Case "x"
                AddCaracter(mLetters.ElementAt(23), x, y)
            Case "y"
                AddCaracter(mLetters.ElementAt(24), x, y)
            Case "z"
                AddCaracter(mLetters.ElementAt(25), x, y)
            Case "0"
                AddCaracter(mLetters.ElementAt(26), x, y)
            Case "1"
                AddCaracter(mLetters.ElementAt(27), x, y)
            Case "2"
                AddCaracter(mLetters.ElementAt(28), x, y)
            Case "3"
                AddCaracter(mLetters.ElementAt(29), x, y)
            Case "4"
                AddCaracter(mLetters.ElementAt(30), x, y)
            Case "5"
                AddCaracter(mLetters.ElementAt(31), x, y)
            Case "6"
                AddCaracter(mLetters.ElementAt(32), x, y)
            Case "7"
                AddCaracter(mLetters.ElementAt(33), x, y)
            Case "8"
                AddCaracter(mLetters.ElementAt(34), x, y)
            Case "9"
                AddCaracter(mLetters.ElementAt(35), x, y)
            Case " "
                AddCaracter(mLetters.ElementAt(36), x, y)
            Case "."
                AddCaracter(mLetters.ElementAt(37), x, y)
            Case "A"
                AddCaracter(mLetters.ElementAt(38), x, y)
            Case "B"
                AddCaracter(mLetters.ElementAt(39), x, y)
            Case "C"
                AddCaracter(mLetters.ElementAt(40), x, y)
            Case "D"
                AddCaracter(mLetters.ElementAt(41), x, y)
            Case "E"
                AddCaracter(mLetters.ElementAt(42), x, y)
            Case "F"
                AddCaracter(mLetters.ElementAt(43), x, y)
            Case "G"
                AddCaracter(mLetters.ElementAt(44), x, y)
            Case "H"
                AddCaracter(mLetters.ElementAt(45), x, y)
            Case "I"
                AddCaracter(mLetters.ElementAt(46), x, y)
            Case "J"
                AddCaracter(mLetters.ElementAt(47), x, y)
            Case "K"
                AddCaracter(mLetters.ElementAt(48), x, y)
            Case "L"
                AddCaracter(mLetters.ElementAt(49), x, y)
            Case "M"
                AddCaracter(mLetters.ElementAt(50), x, y)
            Case "N"
                AddCaracter(mLetters.ElementAt(51), x, y)
            Case "O"
                AddCaracter(mLetters.ElementAt(52), x, y)
            Case "P"
                AddCaracter(mLetters.ElementAt(53), x, y)
            Case "Q"
                AddCaracter(mLetters.ElementAt(54), x, y)
            Case "R"
                AddCaracter(mLetters.ElementAt(55), x, y)
            Case "S"
                AddCaracter(mLetters.ElementAt(56), x, y)
            Case "T"
                AddCaracter(mLetters.ElementAt(57), x, y)
            Case "U"
                AddCaracter(mLetters.ElementAt(58), x, y)
            Case "V"
                AddCaracter(mLetters.ElementAt(59), x, y)
            Case "W"
                AddCaracter(mLetters.ElementAt(60), x, y)
            Case "X"
                AddCaracter(mLetters.ElementAt(61), x, y)
            Case "Y"
                AddCaracter(mLetters.ElementAt(62), x, y)
            Case "Z"
                AddCaracter(mLetters.ElementAt(63), x, y)
            Case "/"
                AddCaracter(mLetters.ElementAt(64), x, y)
        End Select
    End Sub

    Public Sub addStringJustifie(s As String, size As Integer)
        Dim mString As New CDMDString("C:\graphics\font", Me.mPixelSize)
        mString.addString(s)
        addString(s, (size - mString.NBColsForString) / 2)
        mString = Nothing
    End Sub

    Public Sub addString(s As String, Optional x As Integer = 0, Optional y As Integer = 0)
        If x < 0 Then x = 0
        For Each c In s
            AddCaracter(c, x, y)
        Next
    End Sub

    Public Sub clearString()
        mPixels.Clear()
        mNBCaracters = 0
        mPosition = 0
    End Sub
End Class

Public Class CDMDAnimation
    Inherits CDMD
    Protected Property mImages As New List(Of CDMDImage)
    Protected Property mPos As Integer = 0
    Protected Property mDuration As Integer
    Protected Property mTimer As New Timer
    Protected Property mStayOnLAstImage As Integer

    Public Event OnEndAnimation()

    Public Property StayOnLastImage As Integer
        Get
            Return mStayOnLAstImage
        End Get
        Set(value As Integer)
            mStayOnLAstImage = value
        End Set
    End Property

    Public Property Interval As Integer
        Get
            Return mTimer.Interval
        End Get
        Set(value As Integer)
            mTimer.Interval = value
        End Set
    End Property

    Public Sub New()
        MyBase.New
        AddHandler mTimer.Tick, AddressOf Me.tick
        Me.Interval = 500
        mTimer.Start()
    End Sub

    Private Sub tick(sender As Object, e As EventArgs)
        Me.update()
        If Not Me.Enable Then
            mTimer.Stop()
        End If
    End Sub

    Public Sub clearAnimation()
        mImages.Clear()
        mPos = 0
    End Sub

    Public Sub addImage(img As CDMDImage)
        mImages.Add(img)
    End Sub

    Public Sub addImage(img As String, Optional x As Integer = 0, Optional y As Integer = 0)
        mImages.Add(New CDMDImage(img, x, y))
    End Sub

    Public Overrides Sub update()
        'MyBase.update()
        mNbUpdate -= 1
        If mNbUpdate < 0 And mStayOnLAstImage < 0 And mCanBeDisable Then
            Me.Enable = False
        End If
        If mNbUpdate < 0 Then
            mStayOnLAstImage -= 1
        Else
            Me.mPixels.Clear()
            Me.addImageAt(mImages.ElementAt(mPos))
            mPos += 1
            If mPos > mImages.Count - 1 Then
                mPos = 0
            End If
        End If
        If Not Me.Enable Then
            RaiseEvent OnEndAnimation()
        End If

    End Sub
End Class

Public Class CDMDScreen
    Protected Property mItems As New List(Of CDMD)
    Protected Property mScoreDMD As CDMDString
    Protected Property mCols As Integer
    Protected Property mRows As Integer
    Protected Property mSpace As Integer
    Protected Property mPixelSize As Integer
    Protected Property mX As Integer
    Protected Property mY As Integer

    Public Property Score As Integer
        Get
            Return 0
        End Get
        Set(value As Integer)
            mScoreDMD.clearString()
            mScoreDMD.addString(value.ToString)
        End Set
    End Property

    Public Property ScoreDMD As CDMDString
        Get
            Return mScoreDMD
        End Get
        Set(value As CDMDString)
            mItems.Remove(mScoreDMD)
            mScoreDMD = value
            mItems.Add(mScoreDMD)
        End Set
    End Property

    Public Property PixelSize As Integer
        Get
            Return mPixelSize
        End Get
        Set(value As Integer)
            mPixelSize = value
        End Set
    End Property

    Public Property NBCols As Integer
        Get
            Return mCols
        End Get
        Set(value As Integer)
            mCols = value
        End Set
    End Property

    Public Property NBRows As Integer
        Get
            Return mRows
        End Get
        Set(value As Integer)
            mRows = value
        End Set
    End Property

    Public Property Space As Integer
        Get
            Return mSpace
        End Get
        Set(value As Integer)
            mSpace = value
        End Set
    End Property

    Public Sub New(nbcols As Integer, nbrows As Integer, pixelSize As Integer, space As Integer, Optional x As Integer = 0, Optional y As Integer = 0)
        Me.mCols = nbcols
        Me.mRows = nbrows
        Me.mPixelSize = pixelSize
        Me.mSpace = space
        Me.mX = x
        Me.mY = y
        'mScoreDMD = New CDMDString("C:\graphics\font", mPixelSize)
        'mScoreDMD.addString("0", 70, 0)
        'mItems.Add(mScoreDMD)
    End Sub

    Public Sub HideItems()
        For Each items In mItems
            items.Visible = False
        Next
    End Sub

    Public Sub ShowItems()
        For Each items In mItems
            items.Visible = True
        Next
    End Sub

    Public Sub addItem(item As CDMD)

        item.NBCols = Me.mCols
        item.NBRows = Me.mRows
        item.PixelSize = Me.mPixelSize
        item.Space = Me.mSpace
        mItems.Add(item)
    End Sub

    Public Sub clear()
        mItems.Clear()
    End Sub

    Public Sub update()
        Dim toRemove As New List(Of CDMD)
        For Each item In mItems
            If item.Enable Then
                item.update()
            Else
                toRemove.Add(item)
            End If
        Next
        For Each item In toRemove
            mItems.Remove(item)
        Next
    End Sub

    Public Sub draw(ByVal g As Graphics)
        g.Clear(Color.Black)
        For Each item In mItems
            item.draw(g, mX, mY)
        Next
    End Sub

End Class

Public Class CPinballPlayer
    Protected Property mScore As Integer = 0
    Protected Property mBallInGame As Integer = 1
    Protected Property mLockedBalls As Integer = 0
    Protected Property mExtraBall As Integer = 0
    Protected Property mIndex As Integer

    Public ReadOnly Property Index As Integer
        Get
            Return mIndex
        End Get
    End Property

    Public Property Score As Integer
        Get
            Return mScore
        End Get
        Set(value As Integer)
            mScore = value
        End Set
    End Property

    Public Property BallInGame As Integer
        Get
            Return mBallInGame
        End Get
        Set(value As Integer)
            mBallInGame = value
        End Set
    End Property

    Public Property LockedBalls As Integer
        Get
            Return mLockedBalls
        End Get
        Set(value As Integer)
            mLockedBalls = value
        End Set
    End Property

    Public Property ExtaBalls As Integer
        Get
            Return mExtraBall
        End Get
        Set(value As Integer)
            mExtraBall = value
        End Set
    End Property

    Public Sub New(index As Integer)
        Me.mIndex = index
    End Sub

End Class

Public Class CPinballDMD
    Protected Property mDMDScore As CDMDScreen
    Protected Property mDMDInfo As CDMDScreen
    Protected Property mStringScore As CDMDString
    Protected Property mStringInfo As CDMDString
    Protected Property mScore As Integer = 0
    Protected Property mCredit As Integer = 0
    Protected Property mPlayers As New List(Of CPinballPlayer)
    Protected Property mCurentPlayer As CPinballPlayer = Nothing
    Protected Property mAnimationInProgress As Boolean = False

    Public ReadOnly Property AnimationInProgress As Boolean
        Get
            Return Me.mAnimationInProgress
        End Get
    End Property

    Public Property DMDScore As CDMDScreen
        Get
            Return mDMDScore
        End Get
        Set(value As CDMDScreen)
            mDMDScore = value
        End Set
    End Property

    Public Property DMDInfo As CDMDScreen
        Get
            Return mDMDInfo
        End Get
        Set(value As CDMDScreen)
            mDMDInfo = value
        End Set
    End Property

    Public Property Score As Integer
        Get
            Return mScore
        End Get
        Set(value As Integer)
            mScore = value
            mStringScore.clearString()
            mStringScore.addStringJustifie(mScore.ToString, mDMDScore.NBCols)
        End Set
    End Property

    Public Property Credit As Integer
        Get
            Return mCredit
        End Get
        Set(value As Integer)
            mCredit = value
            Me.updateDMDInfo
        End Set
    End Property

    Public Sub updateDMDInfo()
        mStringInfo.clearString()
        If mCurentPlayer IsNot Nothing Then
            mStringInfo.addStringJustifie("Player " + mCurentPlayer.Index.ToString + " / " + mPlayers.Count.ToString + "   ball " + mCurentPlayer.BallInGame.ToString + "    credits " + mCredit.ToString, mDMDInfo.NBCols)
        Else
            mStringInfo.addStringJustifie("add a Player            credits " + mCredit.ToString, mDMDInfo.NBCols)
        End If
    End Sub

    Public Sub New()
        mDMDScore = New CDMDScreen(128, 40, 10, 1)
        mDMDInfo = New CDMDScreen(350, 20, 3, 1)
        mStringScore = New CDMDString("C:\graphics\font", mDMDScore.PixelSize)
        mStringInfo = New CDMDString("C:\graphics\font", mDMDInfo.PixelSize)

        mDMDScore.addItem(mStringScore)
        mDMDInfo.addItem(mStringInfo)

        Me.Credit = 0
        Me.Score = 0
    End Sub

    Public Sub update()
        mDMDInfo.update()
        mDMDScore.update()
    End Sub

    Public Sub AddScore(Value As Integer)
        If mCurentPlayer IsNot Nothing Then
            Me.Score += Value
        End If
    End Sub

    Public Sub addCredit()
        Me.Credit += 1
    End Sub

    Public Sub addPlayer()
        If mPlayers.Count < 4 And mCredit > 0 Then
            mPlayers.Add(New CPinballPlayer(mPlayers.Count + 1))
            If mCurentPlayer Is Nothing Then
                mCurentPlayer = mPlayers.First()
            End If
            Me.Credit -= 1
        End If
    End Sub

    Public Sub Ramp()
        AddScore(500000)
        PlayAnimationBall()
    End Sub

    Public Sub Bumper()
        AddScore(10000)
    End Sub

    Public Sub TargetHit()
        AddScore(1000)
    End Sub

    Public Sub PutBallInGame()
        'activate the solenoid to put ball in game.       
    End Sub

    Public Sub GameOver()
        mStringInfo.clearString()
        mStringInfo.addStringJustifie("GAME OVER", mDMDInfo.NBCols)
        mPlayers.Remove(mCurentPlayer)
        mCurentPlayer = Nothing
    End Sub

    Public Sub BallLeft(animation As CDMDAnimation)
        If mCurentPlayer IsNot Nothing Then
            If mCurentPlayer.BallInGame < 3 Then
                Me.mCurentPlayer.BallInGame += 1

                Me.PlayAnimation(animation)
                'RemoveHandler animation.OnEndAnimation, AddressOf Me.OnEndAnimation
                AddHandler animation.OnEndAnimation, AddressOf Me.OnBallLeftAnimationEnd
            Else
                GameOver()
            End If
            If mPlayers.Count > 1 Then
                Dim position = mPlayers.IndexOf(mCurentPlayer) + 1
                If position = mPlayers.Count Then
                    position = 0
                End If
                mCurentPlayer = mPlayers.ElementAt(position)
                Me.updateDMDInfo()
            End If
        End If
    End Sub

    Public Sub PlayAnimationBall()
        If Not Me.AnimationInProgress Then
            Dim animation As New CDMDAnimation()
            'AddHandler animation.OnEndAnimation, AddressOf Me.OnEndAnimationBall
            animation.addImage("C:\graphics\balls\ball01.png")
            animation.addImage("C:\graphics\balls\ball01.png", 5, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 10, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 15, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 20, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 25, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 30, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 35, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 40, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 45, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 50, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 55, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 60, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 65, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 70, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 75, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 80, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 85, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 90, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 95, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 100, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 105, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 110, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 115, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 120, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 125, 0)
            animation.addImage("C:\graphics\balls\ball01.png", 130, 0)
            animation.Duration = 27
            animation.Interval = 10
            'Me.mDMDScore.HideItems()
            Me.PlayAnimation(animation)
        End If
    End Sub

    Public Sub PlayAnimation(animation As CDMDAnimation)
        If mCurentPlayer IsNot Nothing And Not Me.mAnimationInProgress Then
            Me.mAnimationInProgress = True
            AddHandler animation.OnEndAnimation, AddressOf Me.OnEndAnimation
            Me.mDMDScore.HideItems()
            Me.mDMDScore.addItem(animation)
            animation.update()
        End If
    End Sub

    Private Sub OnEndAnimation()
        Me.mDMDScore.ShowItems()
        Me.mDMDScore.update()
        Me.mAnimationInProgress = False
    End Sub

    Private Sub OnBallLeftAnimationEnd()
        'Me.mDMDScore.ShowItems()
        'Me.mDMDScore.update()
        'Me.mAnimationInProgress = False
        PutBallInGame()
    End Sub

    'Private Sub OnEndAnimationBall()
    'Me.mDMDScore.ShowItems()
    'Me.mAnimationInProgress = False
    'End Sub

    Public Sub PlayAnimation()
        If Not Me.AnimationInProgress Then
            Dim animation As New CDMDAnimation()
            animation.addImage("C:\graphics\sf2\ken001.png")
            animation.addImage("C:\graphics\sf2\ken002.png")
            animation.addImage("C:\graphics\sf2\ken003.png")
            animation.addImage("C:\graphics\sf2\ken004.png")
            animation.addImage("C:\graphics\sf2\ken005.png")
            animation.addImage("C:\graphics\sf2\ken006.png")
            animation.addImage("C:\graphics\sf2\ken007.png")
            animation.addImage("C:\graphics\sf2\ken008.png")
            animation.addImage("C:\graphics\sf2\ken009.png")
            animation.addImage("C:\graphics\sf2\ken010.png")
            animation.addImage("C:\graphics\sf2\ken011.png")
            animation.addImage("C:\graphics\sf2\ken012.png")
            animation.addImage("C:\graphics\sf2\ken013.png")
            animation.addImage("C:\graphics\sf2\ken014.png")
            animation.addImage("C:\graphics\sf2\ken015.png")
            animation.addImage("C:\graphics\sf2\ken016.png")
            animation.Duration = 16
            animation.Interval = 70
            Me.PlayAnimation(animation)
        End If
        Me.Score += 500
    End Sub

    'Private Sub OnEndAnimationBumper()
    'Me.mDMDScore.ShowItems()
    'Me.mAnimationInProgress = False
    'End Sub
End Class