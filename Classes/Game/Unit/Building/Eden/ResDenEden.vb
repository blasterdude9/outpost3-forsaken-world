Imports IrrlichtNETCP
''' <summary>Eden ResDen. Combined residential and nursery. Larger than Residence, grows population faster.</summary>
Public Class ResDenEden
    Inherits Building
    Implements IResidential
    Implements IPopulationProducer

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 8
        _WorkersRequired = 2
        _ScientistsRequired = 0
        _BuildPointsRequired = 1000
        _CommonMetalCost = 1000
        _RareMetalCost = 100
        _TubeRequired = True
        _ResourceWeight = 200
        _Position = position
    End Sub

    Public Function HousingCapacity() As Integer Implements IResidential.HousingCapacity
        Return 40
    End Function
    Public Function WorkerOutput() As Integer Implements IPopulationProducer.WorkerOutput
        Return 2
    End Function
    Public Function ScientistOutput() As Integer Implements IPopulationProducer.ScientistOutput
        Return 0
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenResDen.3ds"
        End Get
    End Property
End Class
