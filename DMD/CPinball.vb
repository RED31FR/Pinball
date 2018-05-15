Public Class CPinball_Player
    Protected Property mScore As Integer = 0
    Protected Property mBalls As Integer = 3

    Public Property Balls As Integer
        Get
            Return mBalls
        End Get
        Set(value As Integer)
            mBalls = value
        End Set
    End Property

    Public Property Score As Integer
        Get
            Return mScore
        End Get
        Set(value As Integer)
            mScore = value
        End Set
    End Property

    Public Sub ExtraBall()
        Me.Balls = Me.Balls + 1
    End Sub

    Public Sub BallLoose()
        Me.Balls -= 1
    End Sub

    Public Sub increaseScore(value As Integer)
        Me.Score += value
    End Sub

End Class

Public Class CPinball
    Protected Property mNbPlayer As Integer = 0
    Protected Property mPlayers As New List(Of CPinballPlayer)
    Protected Property mDMDScreen As New CDMDScreen(256, 40, 5, 1, 0, 0)
    Protected Property mDMDScreenInfo As New CDMDScreen(256, 40, 2, 1, 0, 200)
    Protected Property mQueue As New CPinballEventQueue(mDMDScreen)
    Protected Property mCurentPlayer As CPinballPlayer
    Protected Property mCurentPlayerIndex As Integer = 0
    Protected Property mXScore As Integer = 100
    Protected Property mYScore As Integer = 0

    Public ReadOnly Property CurrentPlayer As CPinballPlayer
        Get
            Return mCurentPlayer
        End Get
    End Property

    Public ReadOnly Property DMDScreen As CDMDScreen
        Get
            Return mDMDScreen
        End Get
    End Property

    Public ReadOnly Property DMDScreenInfo As CDMDScreen
        Get
            Return mDMDScreenInfo
        End Get
    End Property

    Public Sub New()
        Dim mScore As New CDMDString("C:\graphics\font", mDMDScreen.PixelSize)
        mScore.addString("0", mXScore, mYScore)
        mDMDScreen.ScoreDMD = mScore
        Dim mString As New CDMDString("C:\graphics\font", mDMDScreenInfo.PixelSize)
        mString.addString("Player 1")
        mDMDScreenInfo.addItem(mString)

        Dim myImage As New CDMDImage(mDMDScreen.PixelSize)
        myImage.loadFromFile("C:\graphics\1942\image020.png", 40, 20)
        'mDMDScreen.addItem(myImage)        
    End Sub

    Public Sub addPlayer()
        If mNbPlayer < 4 Then
            mCurentPlayer = New CPinballPlayer(0)
            mPlayers.Add(mCurentPlayer)
            mNbPlayer += 1
        End If
    End Sub

    Public Sub SetCurrentPlayer(index As Integer)
        If index < mNbPlayer Then
            mCurentPlayerIndex = index
            mCurentPlayer = mPlayers.ElementAt(mCurentPlayerIndex)
        End If
    End Sub

    Public Sub NextPlayer()
        mCurentPlayerIndex += 1
        If mCurentPlayerIndex > mNbPlayer Then
            mCurentPlayerIndex = 0
        End If
        mQueue.clear()
    End Sub

    Public Sub BumperHit()
        Dim myDMDAni As New CDMDAnimation
        myDMDAni.addImage("C:\graphics\1942\image010.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image011.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image012.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image013.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image014.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image015.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image016.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image017.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image018.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image019.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image020.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image021.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image022.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image023.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image024.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image025.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image026.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image027.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image028.png", 70, 20)
        myDMDAni.addImage("C:\graphics\1942\image029.png", 70, 20)
        myDMDAni.Duration = 5
        mDMDScreen.addItem(myDMDAni)
        'mCurentPlayer.increaseScore(1000)
        mQueue.addEvent(New CPinballEventBumperHit())
        mDMDScreen.ScoreDMD.clearString()
        mDMDScreen.ScoreDMD.addString(mCurentPlayer.Score.ToString, mXScore, mYScore)
    End Sub

    Public Sub BallLaunch()
        mQueue.addEvent(New CPinballEventBallLaunch)
    End Sub

    Public Sub BallLoose()
        mQueue.addEvent(New CPinballEventBallLoose)
        'mCurentPlayer.BallLoose()
        Me.NextPlayer()
    End Sub

    Public Sub TargetHit()

    End Sub

    Public Sub SensorHit()

    End Sub

    Public Sub draw(ByVal g As Graphics)
        g.Clear(Color.Black)
        mDMDScreen.draw(g)
        mDMDScreenInfo.draw(g)
    End Sub
End Class
