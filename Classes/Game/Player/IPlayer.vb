Public Interface IPlayer
    ReadOnly Property Name() As String
    ReadOnly Property CommonMultiplier() As Double
    ReadOnly Property CommonOre() As Integer
    ReadOnly Property RareMultipler() As Double
    ReadOnly Property RareOre() As Integer
    ReadOnly Property HasCommandCenter() As Boolean
    ReadOnly Property Morale() As Integer
    ReadOnly Property Workers() As Integer
    ReadOnly Property Scientists() As Integer
    ReadOnly Property Children() As Integer
    ReadOnly Property Buildings() As BuildingCollection
    ReadOnly Property PowerPlants() As IPowerFactoryCollection
End Interface
