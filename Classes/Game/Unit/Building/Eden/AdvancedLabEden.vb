Imports IrrlichtNETCP
''' <summary>Eden Advanced Lab. Top-tier research. Enables Starflare / Thor's Hammer.</summary>
Public Class AdvancedLabEden
    Inherits Building
    Implements IResearchFacility

    Private _topic As String = "General"

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 20
        _WorkersRequired = 3
        _ScientistsRequired = 8
        _BuildPointsRequired = 3200
        _CommonMetalCost = 3000
        _RareMetalCost = 1000
        _TubeRequired = True
        _ResourceWeight = 600
        _Position = position
    End Sub

    Public Function ResearchOutput() As Integer Implements IResearchFacility.ResearchOutput
        Return 50
    End Function
    Public ReadOnly Property ResearchTopic() As String Implements IResearchFacility.ResearchTopic
        Get
            Return _topic
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenAdvancedLab.3ds"
        End Get
    End Property
End Class
