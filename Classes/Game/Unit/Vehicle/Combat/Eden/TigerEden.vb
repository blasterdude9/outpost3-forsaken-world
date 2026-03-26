Imports IrrlichtNETCP
''' <summary>Eden Tiger. Heavy assault tank. Slow but devastating firepower and high armor.</summary>
Public Class TigerEden
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "EdenTiger"
        _Turret = "Supernova"
        _Speed = 1.0F
        _HP = 300 : _MaxHP = 300
        _Armor = ArmorType.HEAVY
        _Name = "Tiger (Eden)"
        _Weapon = New SupernovaEden()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenTigerSupernova.3ds"
        End Get
    End Property
End Class
