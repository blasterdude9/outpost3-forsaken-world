Imports IrrlichtNETCP

Public MustInherit Class Unit
    Public Enum ArmorType As Integer
        NONE = 0
        VERYLIGHT = 5
        LIGHT = 10
        MEDIUMLIGHT = 20
        MEDIUM = 25
        HEAVY = 40
    End Enum

    Protected _Name As String = ""
    Protected _ID As Integer
    Protected _HP As Integer
    Protected _MaxHP As Integer
    Protected _Armor As ArmorType
    Protected _Owner As Player
    Protected _Position As Vector3D
    Protected mesh As AnimatedMesh
    Protected _Player As Player

    Public ReadOnly Property Name() As String
        Get

            Return _Name

        End Get
    End Property

    Public ReadOnly Property ID() As Integer
        Get

            Return _ID

        End Get
    End Property

    Public Property HP() As Integer
        Get

            Return _HP

        End Get
        Set(ByVal value As Integer)

            _HP = value

        End Set
    End Property

    Public ReadOnly Property MaxHP() As Integer
        Get

            Return _MaxHP

        End Get
    End Property

    Public ReadOnly Property Armor() As ArmorType
        Get

            Return _Armor

        End Get
    End Property

    Public Property Position() As Vector3D
        Get

            Return _Position

        End Get
        Set(ByVal value As Vector3D)

            _Position = value

        End Set
    End Property

    Public ReadOnly Property Owner() As Player
        Get

            Return _Player

        End Get
    End Property

    Public Overridable Function Damage(ByVal dmg As Integer) As Integer
        Dim tmpDamage As Integer = 0
        If _Armor = ArmorType.NONE Then
            tmpDamage = dmg
        Else
            tmpDamage = CInt(dmg * (100.0 / CInt(_Armor)))
        End If
        _HP = Math.Max(0, _HP - tmpDamage)
        If _HP = 0 Then Die()
        Return tmpDamage
    End Function

    Public Overridable Function Damage(ByVal concussion As Integer, ByVal penetration As Integer) As Integer
        Dim tmpDamage As Integer = 0
        If _Armor = ArmorType.NONE Then
            tmpDamage = concussion + penetration
        Else
            tmpDamage = CInt(concussion * (100.0 / CInt(_Armor))) + penetration
        End If
        _HP = Math.Max(0, _HP - tmpDamage)
        If _HP = 0 Then Die()
        Return tmpDamage
    End Function

    Public Overridable Function Damage(ByVal dmg As DamageVector) As Integer
        Return Damage(dmg.Concussion, dmg.Penetration)
    End Function

    Public Overridable Sub Die()
        _HP = 0
        ' Subclasses override to trigger destruction effects, remove from collections, etc.
    End Sub

    Public ReadOnly Property IsAlive() As Boolean
        Get

            Return _HP > 0

        End Get
    End Property

    Public Sub New(ByRef player As Player)
        Me._Player = player
    End Sub

    Public Sub New()
    End Sub

    Public MustOverride ReadOnly Property MeshFilename() As String
End Class
