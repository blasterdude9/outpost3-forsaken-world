Imports IrrlichtNETCP
''' <summary>Eden Standard Lab. Mid-tier research. Requires Basic Lab first.</summary>
Public Class StandardLabEden
    Inherits Building
    Implements IResearchFacility

    Private _topic As String = "General"

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 15
        _WorkersRequired = 2
        _ScientistsRequired = 4
        _BuildPointsRequired = 2000
        _CommonMetalCost = 2000
        _RareMetalCost = 400
        _TubeRequired = True
        _ResourceWeight = 500
        _Position = position
    End Sub

    Public Function ResearchOutput() As Integer Implements IResearchFacility.ResearchOutput
        Return 25
    End Function
    Public ReadOnly Property ResearchTopic() As String Implements IResearchFacility.ResearchTopic
        Get
            Return _topic
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenStandardLab.3ds"
        End Get
    End Property
End Class
