Imports IrrlichtNETCP

''' <summary>
''' Base class for all vehicles. Vehicles move across the map, can carry cargo,
''' and (for combat units) fire weapons at targets.
''' </summary>
Public MustInherit Class Vehicle
    Inherits Unit

    Public Enum VehicleState As Integer
        IDLE = 0
        MOVING = 1
        ATTACKING = 2
        MINING = 3
        BUILDING = 4
        REPAIRING = 5
        DEAD = 6
    End Enum

    Protected _State As VehicleState = VehicleState.IDLE
    Protected _Speed As Single = 1.0F          ' tiles per mark
    Protected _TurnRate As Single = 45.0F      ' degrees per mark
    Protected _CargoCapacity As Integer = 0
    Protected _CargoLoaded As Integer = 0
    Protected _TargetPosition As Vector3D
    Protected _HasTarget As Boolean = False
    Protected _Chassis As String = ""
    Protected _Turret As String = ""
    Protected _Weapon As Weapon = Nothing

    Public ReadOnly Property State() As VehicleState
        Get
            Return _State
        End Get
    End Property

    Public ReadOnly Property Speed() As Single
        Get
            Return _Speed
        End Get
    End Property

    Public ReadOnly Property CargoCapacity() As Integer
        Get
            Return _CargoCapacity
        End Get
    End Property

    Public ReadOnly Property CargoLoaded() As Integer
        Get
            Return _CargoLoaded
        End Get
    End Property

    Public ReadOnly Property Chassis() As String
        Get
            Return _Chassis
        End Get
    End Property

    Public ReadOnly Property Turret() As String
        Get
            Return _Turret
        End Get
    End Property

    Public ReadOnly Property EquippedWeapon() As Weapon
        Get
            Return _Weapon
        End Get
    End Property

    ''' <summary>Issue a move order to this vehicle.</summary>
    Public Sub MoveTo(ByVal target As Vector3D)
        _TargetPosition = target
        _HasTarget = True
        _State = VehicleState.MOVING
    End Sub

    ''' <summary>Order this vehicle to attack a target unit.</summary>
    Public Sub AttackTarget(ByRef target As Unit)
        If _Weapon Is Nothing Then Return
        _State = VehicleState.ATTACKING
        MoveTo(target.Position)
    End Sub

    ''' <summary>Called each game mark. Advances movement and fires weapons if in range.</summary>
    Public Overridable Sub Tick(ByVal markDuration As Double)
        If _State = VehicleState.DEAD Then Return

        If _State = VehicleState.MOVING And _HasTarget Then
            ' Move toward target
            Dim dx As Single = _TargetPosition.X - _Position.X
            Dim dz As Single = _TargetPosition.Z - _Position.Z
            Dim dist As Single = CSng(Math.Sqrt(dx * dx + dz * dz))
            If dist < 0.5F Then
                _Position = _TargetPosition
                _HasTarget = False
                _State = VehicleState.IDLE
            Else
                Dim moveStep As Single = Math.Min(_Speed, dist)
                _Position.X += (dx / dist) * moveStep
                _Position.Z += (dz / dist) * moveStep
            End If
        End If
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return _Chassis & "_" & _Turret & ".3ds"
        End Get
    End Property

End Class

''' <summary>Typed collection of vehicles.</summary>
Public Class VehicleCollection
    Inherits CollectionBase

    Public Sub Add(ByVal value As Vehicle)
        List.Add(value)
    End Sub

    Public Function IndexOf(ByVal value As Vehicle) As Integer
        Return List.IndexOf(value)
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As Vehicle
        Get
            Return DirectCast(List.Item(index), Vehicle)
        End Get
    End Property

    Public Sub Remove(ByVal value As Vehicle)
        List.Remove(value)
    End Sub
End Class
