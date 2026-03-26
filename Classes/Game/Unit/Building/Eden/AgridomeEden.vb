Imports IrrlichtNETCP

''' <summary>
''' Eden Agridome — food production facility.
''' Eden design is more efficient and requires fewer workers.
''' </summary>
Public Class AgridomeEden
    Inherits FoodBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 10
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 1500
        _TubeRequired = True
        _CommonMetalCost = 1000
        _RareMetalCost = 0
        _FoodOutput = 25
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenAgridome.3ds"
        End Get
    End Property
End Class
