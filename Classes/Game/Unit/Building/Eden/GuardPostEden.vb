Imports IrrlichtNETCP
''' <summary>Eden Guard Post. Fixed defensive turret. Fires laser at approaching enemies.</summary>
Public Class GuardPostEden
    Inherits Building

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 8
        _WorkersRequired = 1
        _ScientistsRequired = 0
        _BuildPointsRequired = 600
        _CommonMetalCost = 600
        _RareMetalCost = 100
        _TubeRequired = True
        _ResourceWeight = 700
        _HP = 150
        _MaxHP = 150
        _Armor = ArmorType.MEDIUM
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenGuardPost.3ds"
        End Get
    End Property
End Class
