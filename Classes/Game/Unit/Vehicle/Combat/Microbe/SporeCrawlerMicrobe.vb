Imports IrrlichtNETCP

''' <summary>
''' Microbe Spore Crawler — light combat unit. Fires blight spores.
''' Regenerates HP slowly like all Microbe units.
''' </summary>
Public Class SporeCrawlerMicrobe
    Inherits CombatVehicle

    Private Const SELF_REPAIR_RATE As Single = 0.5

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        MyBase.New(owner)
        _Name = "Spore Crawler"
        _MaxHP = 280
        _HP = 280
        _Armor = ArmorType.LIGHT
        _Speed = 6.0
        _TurnRate = 10.0
        _AttackRange = 150
        _FireIntervalTicks = 5
        _Weapon = New SporeLauncherMicrobe()
        _Position = position
    End Sub

    Public Sub Tick()
        MyBase.Tick()
        If _HP < _MaxHP Then _HP = CInt(Math.Min(_HP + SELF_REPAIR_RATE, _MaxHP))
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get

            Return "MicrobeSporeCrawler.3ds"

        End Get
    End Property
End Class
