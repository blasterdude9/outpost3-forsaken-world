Imports IrrlichtNETCP
''' <summary>Eden Rare Ore Smelter. Produces rare metal used in advanced buildings and weapons.</summary>
Public Class RareOreSmelterEden
    Inherits Building
    Implements IOreProducer

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 15
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 1200
        _CommonMetalCost = 1000
        _RareMetalCost = 200
        _TubeRequired = True
        _ResourceWeight = 300
        _Position = position
    End Sub

    Public Function CommonOreOutput() As Integer Implements IOreProducer.CommonOreOutput
        Return 0
    End Function
    Public Function RareOreOutput() As Integer Implements IOreProducer.RareOreOutput
        Return 8
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenRareOreSmelter.3ds"
        End Get
    End Property
End Class
