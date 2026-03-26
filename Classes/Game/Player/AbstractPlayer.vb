Public MustInherit Class AbstractPlayer
    Implements IPlayer

    Protected _Name As String = ""
    Protected _CommonMultiplier As Double = 1.0
    Protected _CommonOre As Integer = 0
    Protected _RareMultipler As Double = 1.0
    Protected _RareOre As Integer = 0
    Protected _HasCommandCenter As Boolean
    Protected _Morale As Integer = 50
    Protected _Workers As Integer = 4
    Protected _Scientists As Integer = 1
    Protected _Children As Integer = 0
    Protected _Buildings As BuildingCollection
    Protected _Vehicles As VehicleCollection
    Protected _PowerFactories As IPowerFactoryCollection
    Protected _BuildQueue As BuildQueue
    Protected _AvailablePower As Integer = 0
    Protected _PowerDemand As Integer = 0

    Public Sub New()
        _Buildings = New BuildingCollection()
        _Vehicles = New VehicleCollection()
        _PowerFactories = New IPowerFactoryCollection()
        _BuildQueue = New BuildQueue(Me)
    End Sub

    ' ---- IPlayer interface ----
    Public ReadOnly Property Name() As String Implements IPlayer.Name
        Get : Return _Name : End Get
    End Property
    Public ReadOnly Property Buildings() As BuildingCollection Implements IPlayer.Buildings
        Get : Return _Buildings : End Get
    End Property
    Public ReadOnly Property Children() As Integer Implements IPlayer.Children
        Get : Return _Children : End Get
    End Property
    Public ReadOnly Property CommonMultiplier() As Double Implements IPlayer.CommonMultiplier
        Get : Return _CommonMultiplier : End Get
    End Property
    Public ReadOnly Property CommonOre() As Integer Implements IPlayer.CommonOre
        Get : Return _CommonOre : End Get
    End Property
    Public ReadOnly Property HasCommandCenter() As Boolean Implements IPlayer.HasCommandCenter
        Get : Return _HasCommandCenter : End Get
    End Property
    Public ReadOnly Property Morale() As Integer Implements IPlayer.Morale
        Get : Return _Morale : End Get
    End Property
    Public ReadOnly Property PowerPlants() As IPowerFactoryCollection Implements IPlayer.PowerPlants
        Get : Return _PowerFactories : End Get
    End Property
    Public ReadOnly Property RareMultipler() As Double Implements IPlayer.RareMultipler
        Get : Return _RareMultipler : End Get
    End Property
    Public ReadOnly Property RareOre() As Integer Implements IPlayer.RareOre
        Get : Return _RareOre : End Get
    End Property
    Public ReadOnly Property Scientists() As Integer Implements IPlayer.Scientists
        Get : Return _Scientists : End Get
    End Property
    Public ReadOnly Property Workers() As Integer Implements IPlayer.Workers
        Get : Return _Workers : End Get
    End Property

    ' ---- Extended properties ----
    Public ReadOnly Property Vehicles() As VehicleCollection
        Get : Return _Vehicles : End Get
    End Property
    Public ReadOnly Property BuildQueue() As BuildQueue
        Get : Return _BuildQueue : End Get
    End Property
    Public ReadOnly Property AvailablePower() As Integer
        Get : Return _AvailablePower : End Get
    End Property
    Public ReadOnly Property PowerDemand() As Integer
        Get : Return _PowerDemand : End Get
    End Property

    ' ---- Mutation methods (called by ResourceManager / BuildQueue) ----
    Public Sub AddCommonOre(ByVal amount As Integer)
        _CommonOre += amount
    End Sub
    Public Sub AddRareOre(ByVal amount As Integer)
        _RareOre += amount
    End Sub
    Public Sub SpendCommonOre(ByVal amount As Integer)
        _CommonOre = Math.Max(0, _CommonOre - amount)
    End Sub
    Public Sub SpendRareOre(ByVal amount As Integer)
        _RareOre = Math.Max(0, _RareOre - amount)
    End Sub
    Public Sub AddChildren(ByVal n As Integer)
        _Children += n
    End Sub
    Public Sub SetMorale(ByVal m As Integer)
        _Morale = Math.Max(0, Math.Min(100, m))
    End Sub
    Public Sub SetAvailablePower(ByVal p As Integer)
        _AvailablePower = p
    End Sub
    Public Sub SetPowerDemand(ByVal d As Integer)
        _PowerDemand = d
    End Sub
    Public Sub AddWorkers(ByVal n As Integer)
        _Workers += n
    End Sub
    Public Sub AddScientists(ByVal n As Integer)
        _Scientists += n
    End Sub
    Public Sub PromoteChildToWorker()
        If _Children > 0 Then
            _Children -= 1
            _Workers += 1
        End If
    End Sub

End Class
