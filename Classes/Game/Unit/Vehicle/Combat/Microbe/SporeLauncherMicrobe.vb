Imports IrrlichtNETCP
''' <summary>
''' Microbe Spore Launcher. Long-range artillery. Fires blight spore clusters.
''' Spreads blight on impact tiles. Devastating vs static bases.
''' </summary>
Public Class SporeLauncherMicrobe
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "MicrobeSporeLauncher"
        _Turret = "SporeCluster"
        _Speed = 0.7F
        _HP = 180 : _MaxHP = 180
        _Armor = ArmorType.LIGHT
        _Name = "Spore Launcher (Microbe)"
        _Weapon = New BlightProjectorMicrobe()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeSporeLauncher.3ds"
        End Get
    End Property
End Class
