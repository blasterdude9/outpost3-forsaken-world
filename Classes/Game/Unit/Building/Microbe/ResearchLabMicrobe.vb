Imports IrrlichtNETCP

''' <summary>
''' Microbe Research Lab — most efficient lab in the game per scientist.
''' Microbe biology mastery translates directly to research dominance.
''' </summary>
Public Class ResearchLabMicrobe
    Inherits Building
    Private _ResearchTopic As String = ""

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 12
        _WorkersRequired = 1
        _ScientistsRequired = 4
        _BuildPointsRequired = 2200
        _TubeRequired = True
        _CommonMetalCost = 1200
        _RareMetalCost = 800
        _Position = position
    End Sub

    Public ReadOnly Property ResearchPointsPerTick() As Integer
        Get
            If _Status = BuildingStatus.ACTIVE Then Return _Scientists * 6  ' Best ratio
            Return 0
        End Get
    End Property

    Public Property ResearchTopic() As String
        Get : Return _ResearchTopic : End Get
        Set(ByVal v As String) : _ResearchTopic = v : End Set
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get : Return "MicrobeResearchLab.3ds" : End Get
    End Property
End Class
