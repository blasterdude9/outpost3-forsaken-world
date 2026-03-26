''' <summary>
''' Implemented by buildings that produce common or rare ore each mark.
''' (e.g. Common Ore Smelter, Rare Ore Smelter, Rare Ore Mine)
''' </summary>
Public Interface IOreProducer
    Function CommonOreOutput() As Integer
    Function RareOreOutput() As Integer
End Interface

''' <summary>
''' Implemented by buildings that provide housing capacity for population growth.
''' (e.g. Residence, ResDen, GORF)
''' </summary>
Public Interface IResidential
    Function HousingCapacity() As Integer
End Interface

''' <summary>
''' Implemented by buildings that produce workers each cycle.
''' (e.g. GORF, Nursery, ResDen)
''' </summary>
Public Interface IPopulationProducer
    Function WorkerOutput() As Integer
    Function ScientistOutput() As Integer
End Interface

''' <summary>
''' Implemented by buildings that conduct research, improving multipliers.
''' (e.g. University, Basic Lab, Standard Lab, Advanced Lab)
''' </summary>
Public Interface IResearchFacility
    Function ResearchOutput() As Integer
    ReadOnly Property ResearchTopic() As String
End Interface

''' <summary>
''' Implemented by buildings that can train or spawn vehicles.
''' (e.g. Vehicle Factory, Arachnid Factory)
''' </summary>
Public Interface IVehicleFactory
    Function CanProduceVehicle(ByVal vehicleType As String) As Boolean
    Function GetBuildTime(ByVal vehicleType As String) As Integer
End Interface
