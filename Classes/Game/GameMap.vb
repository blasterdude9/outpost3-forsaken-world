Imports IrrlichtNETCP

''' <summary>
''' Represents the game world: terrain heightmap, tube network graph, ore deposit sites,
''' and blight spread state. Loaded from a map file at game start.
''' </summary>
Public Class GameMap

    Public Enum TileType As Integer
        DIRT = 0
        ROCK = 1
        LAVA = 2
        IMPASSABLE = 3
        TUBE = 4
        BLIGHT = 5
    End Enum

    Private _width As Integer
    Private _height As Integer
    Private _tiles() As TileType
    Private _oreDeposits As List(Of OreDeposit)
    Private _tubeNetwork As TubeNetwork
    Private _blightCells As List(Of Point2D)
    Private _blightTickRate As Integer = 8  ' marks between blight spreads

    Public ReadOnly Property Width() As Integer
        Get
            Return _width
        End Get
    End Property

    Public ReadOnly Property Height() As Integer
        Get
            Return _height
        End Get
    End Property

    Public ReadOnly Property OreDeposits() As List(Of OreDeposit)
        Get
            Return _oreDeposits
        End Get
    End Property

    Public ReadOnly Property TubeNetwork() As TubeNetwork
        Get
            Return _tubeNetwork
        End Get
    End Property

    Public Sub New(ByVal width As Integer, ByVal height As Integer)
        _width = width
        _height = height
        ReDim _tiles(width * height - 1)
        _oreDeposits = New List(Of OreDeposit)
        _tubeNetwork = New TubeNetwork()
        _blightCells = New List(Of Point2D)
    End Sub

    Public Function GetTile(ByVal x As Integer, ByVal y As Integer) As TileType
        If x < 0 Or x >= _width Or y < 0 Or y >= _height Then Return TileType.IMPASSABLE
        Return _tiles(y * _width + x)
    End Function

    Public Sub SetTile(ByVal x As Integer, ByVal y As Integer, ByVal t As TileType)
        If x < 0 Or x >= _width Or y < 0 Or y >= _height Then Return
        _tiles(y * _width + x) = t
    End Sub

    Public Function IsPassable(ByVal x As Integer, ByVal y As Integer) As Boolean
        Dim t As TileType = GetTile(x, y)
        Return t <> TileType.IMPASSABLE And t <> TileType.LAVA
    End Function

    ''' <summary>
    ''' Spread blight one step in random cardinal direction from each existing cell.
    ''' Blight destroys any building or tube on the infected cell.
    ''' </summary>
    Public Sub SpreadBlight()
        Dim rng As New System.Random()
        Dim newCells As New List(Of Point2D)

        For Each cell As Point2D In _blightCells
            Dim dirs() As Point2D = {
                New Point2D(cell.X + 1, cell.Y),
                New Point2D(cell.X - 1, cell.Y),
                New Point2D(cell.X, cell.Y + 1),
                New Point2D(cell.X, cell.Y - 1)
            }
            Dim target As Point2D = dirs(rng.Next(0, 4))
            If IsPassable(target.X, target.Y) And GetTile(target.X, target.Y) <> TileType.BLIGHT Then
                SetTile(target.X, target.Y, TileType.BLIGHT)
                newCells.Add(target)
            End If
        Next

        _blightCells.AddRange(newCells)
    End Sub

    ''' <summary>
    ''' Seed an initial blight origin point (usually from a Microbe building or event).
    ''' </summary>
    Public Sub SeedBlight(ByVal x As Integer, ByVal y As Integer)
        Dim p As New Point2D(x, y)
        SetTile(x, y, TileType.BLIGHT)
        If Not _blightCells.Contains(p) Then
            _blightCells.Add(p)
        End If
    End Sub

    Public ReadOnly Property BlightCellCount() As Integer
        Get
            Return _blightCells.Count
        End Get
    End Property

End Class

' ---------------------------------------------------------------------------
'  Supporting value types
' ---------------------------------------------------------------------------

Public Structure Point2D
    Public X As Integer
    Public Y As Integer
    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        Me.X = x
        Me.Y = y
    End Sub
End Structure

''' <summary>
''' An ore deposit on the map. Has a position, common/rare ore yield, and depletion state.
''' </summary>
Public Class OreDeposit
    Public Position As Point2D
    Public CommonOreRemaining As Integer
    Public RareOreRemaining As Integer
    Public CommonYieldPerMark As Integer
    Public RareYieldPerMark As Integer
    Public IsRare As Boolean

    Public Sub New(ByVal pos As Point2D, ByVal common As Integer, ByVal rare As Integer,
                   ByVal commonYield As Integer, ByVal rareYield As Integer, ByVal isRare As Boolean)
        Position = pos
        CommonOreRemaining = common
        RareOreRemaining = rare
        CommonYieldPerMark = commonYield
        RareYieldPerMark = rareYield
        Me.IsRare = isRare
    End Sub

    Public ReadOnly Property IsDepleted() As Boolean
        Get
            Return CommonOreRemaining <= 0 And RareOreRemaining <= 0
        End Get
    End Property

    ''' <summary>Extract ore this mark. Returns common ore extracted; sets rareExtracted via ByRef.</summary>
    Public Function Extract(ByRef rareExtracted As Integer) As Integer
        Dim c As Integer = Math.Min(CommonYieldPerMark, CommonOreRemaining)
        Dim r As Integer = Math.Min(RareYieldPerMark, RareOreRemaining)
        CommonOreRemaining -= c
        RareOreRemaining -= r
        rareExtracted = r
        Return c
    End Function
End Class

''' <summary>
''' Tracks which map cells are connected by tubes for each player.
''' Buildings not connected to the command center's tube network are disabled.
''' </summary>
Public Class TubeNetwork
    Private _connections As New Dictionary(Of String, Boolean)

    Public Sub AddTube(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        Dim key As String = MakeKey(x1, y1, x2, y2)
        _connections(key) = True
    End Sub

    Public Function HasTube(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Boolean
        Return _connections.ContainsKey(MakeKey(x1, y1, x2, y2))
    End Function

    Private Shared Function MakeKey(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As String
        ' Canonical order so A->B == B->A
        If x1 > x2 OrElse (x1 = x2 AndAlso y1 > y2) Then
            Return $"{x2},{y2}-{x1},{y1}"
        End If
        Return $"{x1},{y1}-{x2},{y2}"
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return _connections.Count
        End Get
    End Property
End Class
