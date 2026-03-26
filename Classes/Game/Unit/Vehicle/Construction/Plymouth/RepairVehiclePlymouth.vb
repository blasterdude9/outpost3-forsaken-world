Imports IrrlichtNETCP

''' <summary>Plymouth Repair Vehicle — repairs friendly units and buildings in the field.</summary>
Public Class RepairVehiclePlymouth
    Inherits Vehicle

    Public Const REPAIR_AMOUNT_PER_TICK As Integer = 15
    Public Const REPAIR_RANGE As Single = 60.0

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        MyBase.New(owner)
        _Name = "Repair Vehicle"
        _Type = VehicleType.REPAIR
        _MaxHP = 300
        _HP = 300
        _Armor = ArmorType.LIGHT
        _Speed = 5.0
        _TurnRate = 8.0
        _Position = position
    End Sub

    Public Sub RepairUnit(ByRef target As Unit)
        Dim dx As Single = target.Position.X - _Position.X
        Dim dz As Single = target.Position.Z - _Position.Z
        Dim dist As Single = CSng(Math.Sqrt(dx * dx + dz * dz))
        If dist <= REPAIR_RANGE Then
            target.Repair(REPAIR_AMOUNT_PER_TICK)
        End If
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get : Return "PlymouthRepairVehicle.3ds" : End Get
    End Property
End Class
