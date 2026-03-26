Imports IrrlichtNETCP

''' <summary>Eden EMP Vehicle — specialist unit. Disables enemy electronics in a wide radius.</summary>
Public Class EMPVehicleEden
    Inherits CombatVehicle

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        MyBase.New(owner)
        _Name = "EMP Truck"
        _MaxHP = 400
        _HP = 400
        _Armor = ArmorType.LIGHT
        _Speed = 6.0
        _TurnRate = 9.0
        _AttackRange = 200    ' EMP has very long range
        _FireIntervalTicks = 12
        _Weapon = New EMPEden()
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get : Return "EdenEMPVehicle.3ds" : End Get
    End Property
End Class
