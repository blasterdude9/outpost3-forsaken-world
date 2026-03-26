Imports IrrlichtNETCP
''' <summary>Microbe Arachnid Scout. Fast 6-legged walker. Fires acid cloud on impact, leaving hazard zones.</summary>
Public Class ArachnidScoutMicrobe
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "MicrobeArachnidScout"
        _Turret = "AcidCloud"
        _Speed = 3.5F
        _HP = 70 : _MaxHP = 70
        _Armor = ArmorType.VERYLIGHT
        _Name = "Arachnid Scout (Microbe)"
        _Weapon = New AcidCloudMicrobe()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeArachnidScout.3ds"
        End Get
    End Property
End Class
