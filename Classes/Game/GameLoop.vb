Imports IrrlichtNETCP

''' <summary>
''' Core game loop. Drives the simulation: processes input, runs AI, ticks resources,
''' resolves combat, checks win conditions, and renders the scene each frame.
''' </summary>
Public Class GameLoop

    Private _irrlicht As IrrlichtObj
    Private _players As IPlayerCollection
    Private _map As GameMap
    Private _markTimer As Double = 0.0
    Private _markElapsed As Integer = 0
    Private _running As Boolean = False
    Private _winner As IPlayer = Nothing

    ''' <summary>Seconds of real time per game mark (~2s)</summary>
    Public Const MARK_DURATION As Double = 2.0

    Public Sub New(ByRef irrlicht As IrrlichtObj, ByRef players As IPlayerCollection, ByRef map As GameMap)
        _irrlicht = irrlicht
        _players = players
        _map = map
    End Sub

    ''' <summary>
    ''' Begins the game loop. Blocks until the game ends or the window is closed.
    ''' </summary>
    Public Sub Run()
        _running = True
        Dim lastTime As Double = _irrlicht.device.Timer.Time / 1000.0

        Do While _irrlicht.device.Run() And _running

            Dim now As Double = _irrlicht.device.Timer.Time / 1000.0
            Dim dt As Double = now - lastTime
            lastTime = now

            ProcessInput()
            _markTimer += dt

            ' Fire a game mark tick every MARK_DURATION seconds
            If _markTimer >= MARK_DURATION Then
                _markTimer -= MARK_DURATION
                _markElapsed += 1
                OnMark()
            End If

            Render()
            CheckWinConditions()

        Loop

        _running = False
    End Sub

    ' -------------------------------------------------------------------------
    '  MARK TICK  (all simulation logic goes here)
    ' -------------------------------------------------------------------------
    Private Sub OnMark()
        ' 1. Resource tick for all players
        For i As Integer = 0 To _players.Count - 1
            ResourceManager.Tick(DirectCast(_players(i), AbstractPlayer))
        Next

        ' 2. Run AI for computer players
        For i As Integer = 0 To _players.Count - 1
            If TypeOf _players(i) Is PlayerAI Then
                DirectCast(_players(i), PlayerAI).RunAI()
            End If
        Next

        ' 3. Advance build queues
        For i As Integer = 0 To _players.Count - 1
            Dim ap As AbstractPlayer = DirectCast(_players(i), AbstractPlayer)
            ap.BuildQueue.Tick()
        Next

        ' 4. Tick active vehicles (movement, combat orders)
        For i As Integer = 0 To _players.Count - 1
            Dim ap As AbstractPlayer = DirectCast(_players(i), AbstractPlayer)
            For v As Integer = 0 To ap.Vehicles.Count - 1
                ap.Vehicles(v).Tick(MARK_DURATION)
            Next
        Next
    End Sub

    ' -------------------------------------------------------------------------
    '  INPUT
    ' -------------------------------------------------------------------------
    Private Sub ProcessInput()
        ' Placeholder - real input handling will poll IrrlichtNETCP events
        ' e.g., mouse clicks on terrain -> issue move/build orders
        ' keyboard shortcuts for build menu
    End Sub

    ' -------------------------------------------------------------------------
    '  RENDER
    ' -------------------------------------------------------------------------
    Private Sub Render()
        _irrlicht.driver.BeginScene(True, True, New Color(255, 20, 40, 80))
        _irrlicht.scene.DrawAll()
        _irrlicht.driver.EndScene()
    End Sub

    ' -------------------------------------------------------------------------
    '  WIN CONDITIONS
    ' -------------------------------------------------------------------------
    Private Sub CheckWinConditions()
        Dim activePlayers As Integer = 0
        Dim lastActive As IPlayer = Nothing

        For i As Integer = 0 To _players.Count - 1
            Dim ap As AbstractPlayer = DirectCast(_players(i), AbstractPlayer)
            ' A player is alive if they have at least one active command center
            Dim alive As Boolean = False
            For b As Integer = 0 To ap.Buildings.Count - 1
                If ap.Buildings(b).IsActiveCommandCenter Then
                    alive = True
                    Exit For
                End If
            Next
            If alive Then
                activePlayers += 1
                lastActive = _players(i)
            End If
        Next

        If activePlayers = 1 Then
            _winner = lastActive
            _running = False
            OnGameOver(_winner)
        ElseIf activePlayers = 0 Then
            _running = False
            OnGameOver(Nothing)  ' Draw
        End If
    End Sub

    Private Sub OnGameOver(ByVal winner As IPlayer)
        If winner IsNot Nothing Then
            System.Console.WriteLine("GAME OVER: " & winner.Name & " wins after " & _markElapsed & " marks!")
        Else
            System.Console.WriteLine("GAME OVER: Draw after " & _markElapsed & " marks!")
        End If
    End Sub

    Public ReadOnly Property Winner() As IPlayer
        Get
            Return _winner
        End Get
    End Property

    Public ReadOnly Property MarksElapsed() As Integer
        Get
            Return _markElapsed
        End Get
    End Property

End Class
