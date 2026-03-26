Imports IrrlichtNETCP
''' <summary>Plymouth Guard Post. Fires RPG rounds. More splash damage than Eden laser.</summary>
Public Class GuardPostPlymouth
    Inherits Building

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 10
        _WorkersRequired = 1
        _BuildPointsRequired = 700
        _CommonMetalCost = 700
        _RareMetalCost = 150
        _TubeRequired = True
        _ResourceWeight = 700
        _HP = 180
        _MaxHP = 180
        _Armor = ArmorType.HEAVY
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthGuardPost.3ds"
        End Get
    End Property
End Class
