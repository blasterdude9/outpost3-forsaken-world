Imports IrrlichtNETCP

''' <summary>
''' Microbe Agridome — grows food using engineered organisms.
''' Highest food output of all factions, but needs more scientists.
''' </summary>
Public Class AgridomeMicrobe
    Inherits FoodBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 8
        _WorkersRequired = 1
        _ScientistsRequired = 3
        _BuildPointsRequired = 1600
        _TubeRequired = True
        _CommonMetalCost = 600
        _RareMetalCost = 200
        _FoodOutput = 30   ' Best food output — Microbe excels at biology
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeAgridome.3ds"
        End Get
    End Property
End Class
