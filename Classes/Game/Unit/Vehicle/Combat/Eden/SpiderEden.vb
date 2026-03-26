Imports IrrlichtNETCP
''' <summary>Eden Spider. Unique Eden vehicle — all-terrain legged walker. Can traverse lava safely.</summary>
Public Class SpiderEden
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "EdenSpider"
        _Turret = "EMP"
        _Speed = 1.5F
        _HP = 120 : _MaxHP = 120
        _Armor = ArmorType.LIGHT
        _Name = "Spider (Eden)"
        _Weapon = New EMPEden()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenSpiderEMP.3ds"
        End Get
    End Property
End Class
