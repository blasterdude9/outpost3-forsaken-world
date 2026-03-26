Imports IrrlichtNETCP

''' <summary>
''' Eden Research Lab — generates research points per tick based on scientist count.
''' Eden labs are more efficient per scientist.
''' </summary>
Public Class ResearchLabEden
    Inherits Building

    Private _ResearchTopic As String = ""

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 15
        _WorkersRequired = 1
        _ScientistsRequired = 6
        _BuildPointsRequired = 2800
        _TubeRequired = True
        _CommonMetalCost = 2000
        _RareMetalCost = 600
        _Position = position
    End Sub

    Public ReadOnly Property ResearchPointsPerTick() As Integer
        Get
            If _Status = BuildingStatus.ACTIVE Then
                Return _Scientists * 5   ' 5 research points per scientist per tick
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
            Return "EdenResearchLab.3ds"
        End Get
    End Property
End Class
