Imports IrrlichtNETCP

''' <summary>Microbe Acid Walker — heavy unit. Devastating vs buildings due to armor bypass.</summary>
Public Class AcidWalkerMicrobe
    Inherits CombatVehicle

    Private Const SELF_REPAIR_RATE As Single = 1.0

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        MyBase.New(owner)
        _Name = "Acid Walker"
        _MaxHP = 850
        _HP = 850
        _Armor = ArmorType.MEDIUM
        _Speed = 3.5
        _TurnRate = 6.0
        _AttackRange = 130
        _FireIntervalTicks = 7
        _Weapon = New AcidCannonMicrobe()
        _Position = position
    End Sub

    Public Sub Tick()
        MyBase.Tick()
        If _HP < _MaxHP Then _HP = CInt(Math.Min(_HP + SELF_REPAIR_RATE, _MaxHP))
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get

            Return "MicrobeAcidWalker.3ds"

        End Get
    End Property
End Class
