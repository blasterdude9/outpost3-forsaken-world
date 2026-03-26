Imports IrrlichtNETCP
''' <summary>Plymouth University. Converts workers into scientists and conducts research.</summary>
Public Class UniversityPlymouth
    Inherits Building
    Implements IResearchFacility
    Implements IPopulationProducer

    Private _topic As String = "General"

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 12
        _WorkersRequired = 2
        _ScientistsRequired = 4
        _BuildPointsRequired = 1800
        _CommonMetalCost = 1800
        _RareMetalCost = 300
        _TubeRequired = True
        _ResourceWeight = 500
        _Position = position
    End Sub

    Public Function ResearchOutput() As Integer Implements IResearchFacility.ResearchOutput
        Return 30
    End Function
    Public ReadOnly Property ResearchTopic() As String Implements IResearchFacility.ResearchTopic
        Get
            Return _topic
        End Get
    End Property
    Public Function WorkerOutput() As Integer Implements IPopulationProducer.WorkerOutput
        Return -1   ' Consumes 1 worker per cycle, converts to scientist
    End Function
    Public Function ScientistOutput() As Integer Implements IPopulationProducer.ScientistOutput
        Return 1
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthUniversity.3ds"
        End Get
    End Property
End Class
