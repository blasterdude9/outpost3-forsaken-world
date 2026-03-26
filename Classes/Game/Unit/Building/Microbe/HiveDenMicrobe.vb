Imports IrrlichtNETCP
''' <summary>
''' Microbe Hive Den. Housing and breeding facility. Grows population fast.
''' Has the highest housing capacity of any faction but requires rare metal.
''' </summary>
Public Class HiveDenMicrobe
    Inherits Building
    Implements IResidential
    Implements IPopulationProducer

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 6
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 800
        _CommonMetalCost = 600
        _RareMetalCost = 300
        _TubeRequired = True
        _ResourceWeight = 200
        _SpontaneouslyExplodes = False
        _Position = position
    End Sub

    Public Function HousingCapacity() As Integer Implements IResidential.HousingCapacity
        Return 50   ' Highest capacity, very cramped
    End Function
    Public Function WorkerOutput() As Integer Implements IPopulationProducer.WorkerOutput
        Return 3
    End Function
    Public Function ScientistOutput() As Integer Implements IPopulationProducer.ScientistOutput
        Return 1
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeHiveDen.3ds"
        End Get
    End Property
End Class
