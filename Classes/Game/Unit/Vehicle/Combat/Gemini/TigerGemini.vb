Imports IrrlichtNETCP
''' <summary>Gemini Tiger. Starflare launcher — area-burst weapon, best vs clustered enemies.</summary>
Public Class TigerGemini
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "GeminiTiger"
        _Turret = "Starflare"
        _Speed = 1.0F
        _HP = 280 : _MaxHP = 280
        _Armor = ArmorType.HEAVY
        _Name = "Tiger (Gemini)"
        _Weapon = New StarflareGemini()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiTigerStarflare.3ds"
        End Get
    End Property
End Class
