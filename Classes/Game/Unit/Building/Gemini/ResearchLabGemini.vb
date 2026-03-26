Imports IrrlichtNETCP
''' <summary>Gemini Research Lab. Combined basic+standard tier, unique Gemini approach.</summary>
Public Class ResearchLabGemini
    Inherits Building
    Implements IResearchFacility

    Private _topic As String = "General"

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 14
        _WorkersRequired = 2
        _ScientistsRequired = 3
        _BuildPointsRequired = 1600
        _CommonMetalCost = 1600
        _RareMetalCost = 300
        _TubeRequired = True
        _ResourceWeight = 450
        _Position = position
    End Sub

    Public Function ResearchOutput() As Integer Implements IResearchFacility.ResearchOutput
        Return 20
    End Function
    Public ReadOnly Property ResearchTopic() As String Implements IResearchFacility.ResearchTopic
        Get
            Return _topic
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiResearchLab.3ds"
        End Get
    End Property
End Class
