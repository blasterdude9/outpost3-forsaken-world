Imports IrrlichtNETCP
''' <summary>
''' Microbe Blight Lab. Unique Microbe research building. Researches biological weapons
''' and blight spread vectors. Required to unlock Blight Projector weapon.
''' </summary>
Public Class BlightLabMicrobe
    Inherits Building
    Implements IResearchFacility

    Private _topic As String = "Blight"

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 18
        _WorkersRequired = 2
        _ScientistsRequired = 5
        _BuildPointsRequired = 2400
        _CommonMetalCost = 2000
        _RareMetalCost = 800
        _TubeRequired = True
        _ResourceWeight = 600
        _SpontaneouslyExplodes = True   ' If this goes blight it's very bad
        _Position = position
    End Sub

    Public Function ResearchOutput() As Integer Implements IResearchFacility.ResearchOutput
        Return 35
    End Function
    Public ReadOnly Property ResearchTopic() As String Implements IResearchFacility.ResearchTopic
        Get
            Return _topic
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeBlightLab.3ds"
        End Get
    End Property
End Class
