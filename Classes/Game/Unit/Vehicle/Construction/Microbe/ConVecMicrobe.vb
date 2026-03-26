Imports IrrlichtNETCP
''' <summary>Microbe ConVec. Organic frame. Self-repairs 1HP/mark when idle.</summary>
Public Class ConVecMicrobe
    Inherits Vehicle
    Private _loadedKit As String = ""
    Public Sub New(ByRef owner As Player)
        _Chassis = "MicrobeConVec" : _Speed = 1.7F : _HP = 85 : _MaxHP = 85
        _Armor = ArmorType.LIGHT : _Name = "ConVec (Microbe)" : _Player = owner
    End Sub
    Public Sub LoadKit(ByVal buildingType As String) : _loadedKit = buildingType : End Sub
    Public Function DeployKit() As String
        Dim k = _loadedKit : _loadedKit = "" : Return k
    End Function
    Public ReadOnly Property HasKit() As Boolean
        Get : Return _loadedKit <> "" : End Get
    End Property
    Public Overrides Sub Tick(ByVal markDuration As Double)
        MyBase.Tick(markDuration)
        ' Self-repair when idle
        If _State = VehicleState.IDLE AndAlso _HP < _MaxHP Then
            _HP = Math.Min(_MaxHP, _HP + 1)
        End If
    End Sub
    Public Overrides ReadOnly Property MeshFilename() As String
        Get : Return "MicrobeConVec.3ds" : End Get
    End Property
End Class
