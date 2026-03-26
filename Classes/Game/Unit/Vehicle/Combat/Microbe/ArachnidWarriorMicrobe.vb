Imports IrrlichtNETCP
''' <summary>Microbe Arachnid Warrior. Heavy walker. Blight Projector infects vehicles on hit.</summary>
Public Class ArachnidWarriorMicrobe
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "MicrobeArachnidWarrior"
        _Turret = "BlightProjector"
        _Speed = 1.5F
        _HP = 220 : _MaxHP = 220
        _Armor = ArmorType.MEDIUM
        _Name = "Arachnid Warrior (Microbe)"
        _Weapon = New BlightProjectorMicrobe()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeArachnidWarrior.3ds"
        End Get
    End Property
End Class
