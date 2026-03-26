Imports IrrlichtNETCP
''' <summary>Plymouth Nursery. Accelerates child production. Unique to Plymouth.</summary>
Public Class NurseryPlymouth
    Inherits Building
    Implements IResidential
    Implements IPopulationProducer

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 6
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 900
        _CommonMetalCost = 900
        _RareMetalCost = 0
        _TubeRequired = True
        _ResourceWeight = 250
        _Position = position
    End Sub

    Public Function HousingCapacity() As Integer Implements IResidential.HousingCapacity
        Return 30
    End Function
    Public Function WorkerOutput() As Integer Implements IPopulationProducer.WorkerOutput
        Return 3   ' Nursery matures children to workers faster
    End Function
    Public Function ScientistOutput() As Integer Implements IPopulationProducer.ScientistOutput
        Return 0
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthNursery.3ds"
        End Get
    End Property
End Class
