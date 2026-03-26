Imports IrrlichtNETCP
''' <summary>Gemini Lynx. Balanced Lynx with microwave turret — effective vs infantry and light vehicles.</summary>
Public Class LynxGemini
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "GeminiLynx"
        _Turret = "Microwave"
        _Speed = 2.8F
        _HP = 90 : _MaxHP = 90
        _Armor = ArmorType.VERYLIGHT
        _Name = "Lynx (Gemini)"
        _Weapon = New MicrowaveGemini()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiLynxMicrowave.3ds"
        End Get
    End Property
End Class
