Imports IrrlichtNETCP
''' <summary>Plymouth Tiger. Slower but highest HP of all Tigers. EMP cannon disables entire vehicle columns.</summary>
Public Class TigerPlymouth
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "PlymouthTiger"
        _Turret = "EMP"
        _Speed = 0.8F
        _HP = 350 : _MaxHP = 350
        _Armor = ArmorType.HEAVY
        _Name = "Tiger (Plymouth)"
        _Weapon = New EMPPlymouth()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthTigerEMP.3ds"
        End Get
    End Property
End Class
