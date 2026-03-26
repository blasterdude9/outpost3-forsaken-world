Imports IrrlichtNETCP
''' <summary>Eden Basic Lab. Entry-level research facility. Unlocks tier-1 technologies.</summary>
Public Class BasicLabEden
    Inherits Building
    Implements IResearchFacility

    Private _topic As String = "General"

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 10
        _WorkersRequired = 1
        _ScientistsRequired = 2
        _BuildPointsRequired = 1200
        _CommonMetalCost = 1200
        _RareMetalCost = 200
        _TubeRequired = True
        _ResourceWeight = 400
        _Position = position
    End Sub

    Public Function ResearchOutput() As Integer Implements IResearchFacility.ResearchOutput
        Return 10
    End Function
    Public ReadOnly Property ResearchTopic() As String Implements IResearchFacility.ResearchTopic
        Get
            Return _topic
        End Get
    End Property
    Public Sub SetTopic(ByVal topic As String)
        _topic = topic
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenBasicLab.3ds"
        End Get
    End Property
End Class
