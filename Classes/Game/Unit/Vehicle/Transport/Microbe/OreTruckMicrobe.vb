Imports IrrlichtNETCP

''' <summary>Microbe Ore Truck — hauls ore from mine to smelter.</summary>
Public Class OreTruckMicrobe
    Inherits Vehicle

    Public Enum OreType
        COMMON
        RARE
    End Enum

    Private _OreType As OreType = OreType.COMMON

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        MyBase.New(owner)
        _Name = "Ore Truck"
        _Type = VehicleType.TRANSPORT
        _MaxHP = 200
        _HP = 200
        _Armor = ArmorType.LIGHT
        _Speed = 6.5
        _TurnRate = 9.0
        _CargoCapacity = 100
        _Position = position
    End Sub

    Public Property HaulingOreType() As OreType
        Get : Return _OreType : End Get
        Set(ByVal v As OreType) : _OreType = v : End Set
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get : Return "MicrobeOreTruck.3ds" : End Get
    End Property
End Class
