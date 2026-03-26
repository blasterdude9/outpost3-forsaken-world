Imports IrrlichtNETCP
''' <summary>
''' Eden ConVec (Construction Vehicle). Carries a building kit.
''' Deploys at a location to begin construction of a new structure.
''' Must be loaded with a specific building type at a Vehicle Factory.
''' </summary>
Public Class ConVecEden
    Inherits Vehicle

    Private _loadedKit As String = ""

    Public Sub New(ByRef owner As Player)
        _Chassis = "EdenConVec"
        _Turret = "None"
        _Speed = 1.5F
        _HP = 90 : _MaxHP = 90
        _Armor = ArmorType.LIGHT
        _Name = "ConVec (Eden)"
        _Player = owner
    End Sub

    Public ReadOnly Property LoadedKit() As String
        Get
            Return _loadedKit
        End Get
    End Property

    ''' <summary>Load this ConVec with a building kit.</summary>
    Public Sub LoadKit(ByVal buildingType As String)
        _loadedKit = buildingType
    End Sub

    ''' <summary>Deploy the loaded kit at the vehicle's current position.</summary>
    Public Function DeployKit() As String
        Dim kit As String = _loadedKit
        _loadedKit = ""
        Return kit   ' Caller adds the building to the player's BuildQueue
    End Function

    Public ReadOnly Property HasKit() As Boolean
        Get
            Return _loadedKit <> ""
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenConVec.3ds"
        End Get
    End Property
End Class
