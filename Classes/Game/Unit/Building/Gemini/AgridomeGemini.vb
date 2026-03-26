Imports IrrlichtNETCP

Public Class AgridomeGemini
    Inherits FoodBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 10
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 1400
        _TubeRequired = True
        _CommonMetalCost = 950
        _RareMetalCost = 0
        _FoodOutput = 22
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiAgridome.3ds"
        End Get
    End Property
End Class
