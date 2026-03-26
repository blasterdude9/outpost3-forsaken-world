Imports IrrlichtNETCP
''' <summary>Eden Common Ore Smelter. Processes common ore deposits into usable metal.</summary>
Public Class CommonOreSmelterEden
    Inherits Building
    Implements IOreProducer

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 10
        _WorkersRequired = 2
        _ScientistsRequired = 0
        _BuildPointsRequired = 800
        _CommonMetalCost = 800
        _RareMetalCost = 0
        _TubeRequired = True
        _ResourceWeight = 200
        _Position = position
    End Sub

    Public Function CommonOreOutput() As Integer Implements IOreProducer.CommonOreOutput
        Return 15
    End Function
    Public Function RareOreOutput() As Integer Implements IOreProducer.RareOreOutput
        Return 0
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenCommonOreSmelter.3ds"
        End Get
    End Property
End Class
