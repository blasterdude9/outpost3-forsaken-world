Imports IrrlichtNETCP
''' <summary>Plymouth Common Ore Smelter. Higher yield than Eden but costs more rare metal.</summary>
Public Class CommonOreSmelterPlymouth
    Inherits Building
    Implements IOreProducer

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 12
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 1000
        _CommonMetalCost = 900
        _RareMetalCost = 100
        _TubeRequired = True
        _ResourceWeight = 200
        _Position = position
    End Sub

    Public Function CommonOreOutput() As Integer Implements IOreProducer.CommonOreOutput
        Return 20
    End Function
    Public Function RareOreOutput() As Integer Implements IOreProducer.RareOreOutput
        Return 0
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthCommonOreSmelter.3ds"
        End Get
    End Property
End Class
