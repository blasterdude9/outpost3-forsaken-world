Imports IrrlichtNETCP

''' <summary>
''' Base class for all combat vehicles. Has a weapon with ammo, range, and fire rate.
''' </summary>
Public MustInherit Class CombatVehicle
    Inherits Vehicle

    Protected Shadows _Weapon As Weapon
    Protected _AttackRange As Single
    Protected _TicksSinceLastShot As Integer = 0
    Protected _FireIntervalTicks As Integer = 3
    Protected _TargetID As Integer = -1

    Public ReadOnly Property AttackRange() As Single
        Get
            Return _AttackRange
        End Get
    End Property

    Public ReadOnly Property HasTarget() As Boolean
        Get
            Return _TargetID >= 0
        End Get
    End Property

    Public Property TargetID() As Integer
        Get
            Return _TargetID
        End Get
        Set(ByVal value As Integer)
            _TargetID = value
        End Set
    End Property

    Public Function CanFire() As Boolean
        Return _TicksSinceLastShot >= _FireIntervalTicks AndAlso _HP > 0
    End Function

    Public Sub RecordShot()
        _TicksSinceLastShot = 0
    End Sub

    Public Overrides Sub Tick(ByVal markDuration As Double)
        MyBase.Tick(markDuration)
        _TicksSinceLastShot += 1
    End Sub

    ''' <summary>
    ''' Returns damage dealt if in range. Call each tick when target is set.
    ''' </summary>
    Public Function TryFire(ByVal target As Unit) As Integer
        If Not CanFire() Then Return 0
        Dim dx As Single = target.Position.X - _Position.X
        Dim dz As Single = target.Position.Z - _Position.Z
        Dim dist As Single = CSng(Math.Sqrt(dx * dx + dz * dz))
        If dist <= _AttackRange Then
            RecordShot()
            Dim dmg As DamageVector = _Weapon.Fire(target)
            If dmg IsNot Nothing Then Return dmg.Concussion + dmg.Penetration
        End If
        Return 0
    End Function

    Public Sub New(ByRef owner As Player)
        MyBase.New(owner)
        _Type = VehicleType.COMBAT
    End Sub
End Class
