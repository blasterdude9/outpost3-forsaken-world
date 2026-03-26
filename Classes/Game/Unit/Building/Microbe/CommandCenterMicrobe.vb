Imports IrrlichtNETCP
''' <summary>
''' Microbe Command Center. The Microbe faction uses biological-mechanical hybrid systems.
''' Their CC is organic — it slowly self-repairs and can seed blight, but has lower armor.
''' </summary>
Public Class CommandCenterMicrobe
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _WorkersRequired = 3
        _ScientistsRequired = 2
        _BuildPointsRequired = 2600
        _CommonMetalCost = 2000
        _RareMetalCost = 600
        _TubeRequired = False
        _IsCommandCenter = True
        _ProductionLevel = 80
        _DeteriorateRate = 0
        _SpontaneouslyExplodes = False
        _HP = 1500
        _MaxHP = 1500
        _Armor = ArmorType.LIGHT    ' Microbe buildings are easier to kill
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeCommandCenter.3ds"
        End Get
    End Property
End Class
