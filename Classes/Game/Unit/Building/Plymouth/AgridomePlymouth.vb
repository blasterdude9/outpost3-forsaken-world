Imports IrrlichtNETCP

Public Class AgridomePlymouth
    Inherits FoodBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 12
        _WorkersRequired = 3
        _ScientistsRequired = 0
        _BuildPointsRequired = 1200
        _TubeRequired = True
        _CommonMetalCost = 900
        _RareMetalCost = 0
        _FoodOutput = 20   ' Less efficient than Eden — Plymouth focuses on war
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthAgridome.3ds"
        End Get
    End Property
End Class
