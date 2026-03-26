Imports IrrlichtNETCP

Module Main

    Private _config As ConfigurationObj
    Private _irrlicht As IrrlichtObj

    Sub Main()
        ' Load configuration
        _config = New ConfigurationObj()

        ' Initialize Irrlicht rendering engine
        _irrlicht = InitializeEngine()

        ' Build player roster
        Dim players As New IPlayerCollection()

        ' Human player — Eden faction, starts with a command center and a ConVec
        Dim human As New Player("Garrett")
        Dim humanCC As New CommandCenterEden(
            New IrrlichtNETCP.Vector3D(10, 0, 10), human)
        humanCC.SetStatus(Building.BuildingStatus.ACTIVE)
        human.Buildings.Add(humanCC)
        human.PowerPlants.Add(humanCC)
        human.AddCommonOre(2000)
        human.AddWorkers(4)
        human.AddScientists(1)
        Dim humanConVec As New ConVecEden(human)
        humanConVec.Position = New IrrlichtNETCP.Vector3D(12, 0, 10)
        human.Vehicles.Add(humanConVec)
        players.Add(human)

        ' AI opponent — Plymouth faction (Mean AI), starts at the other end of the map
        Dim aiOpponent As New PlayerAIMean()
        Dim aiCC As New CommandCenterPlymouth(
            New IrrlichtNETCP.Vector3D(90, 0, 90), DirectCast(aiOpponent, Player))
        aiCC.SetStatus(Building.BuildingStatus.ACTIVE)
        aiOpponent.Buildings.Add(aiCC)
        aiOpponent.PowerPlants.Add(aiCC)
        aiOpponent.AddCommonOre(2000)
        aiOpponent.AddWorkers(4)
        aiOpponent.AddScientists(1)
        players.Add(aiOpponent)

        ' Build a default map (100x100 tiles)
        Dim map As New GameMap(100, 100)
        SeedDefaultMap(map)

        ' Hand off to the game loop
        Dim gameLoop As New GameLoop(_irrlicht, players, map)
        gameLoop.Run()

        System.Console.WriteLine("Thanks for playing Outpost 3: Forsaken World!")
    End Sub

    ''' <summary>
    ''' Populate the map with ore deposits, blight seeds, and impassable terrain.
    ''' Replace with file-based map loading when ready.
    ''' </summary>
    Private Sub SeedDefaultMap(ByRef map As GameMap)
        ' Central common ore deposits
        map.OreDeposits.Add(New OreDeposit(
            New Point2D(20, 20), 50000, 0, 15, 0, False))
        map.OreDeposits.Add(New OreDeposit(
            New Point2D(80, 80), 50000, 0, 15, 0, False))

        ' Rare ore deposit — contested center
        map.OreDeposits.Add(New OreDeposit(
            New Point2D(50, 50), 20000, 10000, 8, 4, True))

        ' Lava fields — impassable belt across the middle
        For x As Integer = 40 To 60
            map.SetTile(x, 48, GameMap.TileType.LAVA)
            map.SetTile(x, 49, GameMap.TileType.LAVA)
            map.SetTile(x, 50, GameMap.TileType.LAVA)
        Next

        ' Seed a small blight patch in the northeast — nobody starts near it, but it grows
        map.SeedBlight(70, 30)
        map.SeedBlight(71, 30)
    End Sub

    ' -------------------------------------------------------------------------
    '  ENGINE INIT
    ' -------------------------------------------------------------------------
    Private Function InitializeEngine() As IrrlichtObj
        Dim device As IrrlichtDevice = CreateDevice()
        Dim driver As VideoDriver = device.VideoDriver()
        Dim scene As SceneManager = device.SceneManager()
        ' Add a default camera so the scene renders
        scene.AddCameraSceneNode(Nothing, _
            New Vector3D(50, 80, -20), _
            New Vector3D(50, 0, 50))
        device.SetWindowCaption("Outpost 3: Forsaken World")
        Return New IrrlichtObj(device, driver, scene)
    End Function

    Private Function CreateDevice() As IrrlichtDevice
        Dim device As New IrrlichtDevice(
            _config.DriverType,
            _config.Resolution,
            _config.ColorDepth,
            _config.FullScreen,
            False,
            _config.VSync,
            _config.AntiAlias)
        device.FileSystem.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory()
        Return device
    End Function

End Module
