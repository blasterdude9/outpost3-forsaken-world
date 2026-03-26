Imports IrrlichtNETCP
''' <summary>Plymouth ConVec. Same function as Eden ConVec but sturdier chassis.</summary>
Public Class ConVecPlymouth
    Inherits Vehicle

    Private _loadedKit As String = ""

    Public Sub New(ByRef owner As Player)
        _Chassis = "PlymouthConVec"
        _Turret = "None"
        _Speed = 1.4F
        _HP = 110 : _MaxHP = 110
        _Armor = ArmorType.MEDIUMLIGHT
        _Name = "ConVec (Plymouth)"
        _Player = owner
    End Sub

    Public Sub LoadKit(ByVal buildingType As String)
        _loadedKit = buildingType
    End Sub

    Public Function DeployKit() As String
        Dim kit As String = _loadedKit
        _loadedKit = ""
        Return kit
    End Function

    Public ReadOnly Property HasKit() As Boolean
        Get
            Return _loadedKit <> ""
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthConVec.3ds"
        End Get
    End Property
End Class
