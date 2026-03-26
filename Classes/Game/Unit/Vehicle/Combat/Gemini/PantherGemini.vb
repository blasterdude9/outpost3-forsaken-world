Imports IrrlichtNETCP
''' <summary>Gemini Panther. Rail gun variant — long range, high penetration.</summary>
Public Class PantherGemini
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "GeminiPanther"
        _Turret = "RailGun"
        _Speed = 2.0F
        _HP = 155 : _MaxHP = 155
        _Armor = ArmorType.MEDIUMLIGHT
        _Name = "Panther (Gemini)"
        _Weapon = New RailGunGemini()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiPantherRailGun.3ds"
        End Get
    End Property
End Class
