Imports IrrlichtNETCP

''' <summary>
''' Microbe Guard Post — fires blight spores instead of conventional ammo.
''' Slower but inflicts a damage-over-time effect.
''' </summary>
Public Class GuardPostMicrobe
    Inherits Building

    Public Const ATTACK_RANGE As Integer = 160       ' Longest range of all guard posts
    Public Const DAMAGE_PER_SHOT As Integer = 20     ' Lower initial hit
    Public Const DOT_DAMAGE As Integer = 8           ' Per tick damage-over-time
    Public Const DOT_DURATION_TICKS As Integer = 5
    Public Const FIRE_INTERVAL_TICKS As Integer = 6  ' Slow fire rate

    Private _TicksSinceLastShot As Integer = 0

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 10
        _BuildPointsRequired = 1100
        _TubeRequired = False
        _CommonMetalCost = 500
        _RareMetalCost = 300
        _MaxHP = 300
        _HP = 300
        _Armor = ArmorType.LIGHT
        _Position = position
    End Sub

    Public Function CanFire() As Boolean
        Return _TicksSinceLastShot >= FIRE_INTERVAL_TICKS AndAlso _Status = BuildingStatus.ACTIVE
    End Function
    Public Sub RecordShot() 

        _TicksSinceLastShot = 0

    End Sub
    Public Sub Tick() 

        _TicksSinceLastShot += 1

    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get

            Return "MicrobeGuardPost.3ds"

        End Get
    End Property
End Class
