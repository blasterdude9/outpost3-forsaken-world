Imports IrrlichtNETCP

''' <summary>
''' Plymouth Research Lab — less efficient per scientist than Eden's,
''' but Plymouth can staff more of them by conscripting workers.
''' </summary>
Public Class ResearchLabPlymouth
    Inherits Building

    Private _ResearchTopic As String = ""

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 18
        _WorkersRequired = 2
        _ScientistsRequired = 4
        _BuildPointsRequired = 2500
        _TubeRequired = True
        _CommonMetalCost = 1800
        _RareMetalCost = 500
        _Position = position
    End Sub

    Public ReadOnly Property ResearchPointsPerTick() As Integer
        Get
            If _Status = BuildingStatus.ACTIVE Then
                Return _Scientists * 4   ' 4 points per scientist (vs Eden's 5)
            End If
            Return 0
        End Get
    End Property

    Public Property ResearchTopic() As String
        Get
            Return _ResearchTopic
        End Get
        Set(ByVal value As String)
            _ResearchTopic = value
        End Set
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthResearchLab.3ds"
        End Get
    End Property
End Class
