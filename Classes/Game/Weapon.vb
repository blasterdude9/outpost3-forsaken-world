''' <summary>
''' Base class for all weapons. A weapon has a range, rate of fire, and produces
''' a DamageVector on hit. Mounted on vehicles or fixed on buildings.
''' </summary>
Public MustInherit Class Weapon

    Public Enum WeaponType As Integer
        LASER = 0
        RAIL_GUN = 1
        ROCKET = 2
        EMP = 3
        MICROWAVE = 4
        BLIGHT_PROJECTOR = 5
        ACID_CLOUD = 6
        RPG = 7
        STARFLARE = 8
        SUPERNOVA = 9
        THORS_HAMMER = 10
    End Enum

    Protected _Type As WeaponType
    Protected _Range As Integer          ' in map tiles
    Protected _CooldownMarks As Integer  ' marks between shots
    Protected _CurrentCooldown As Integer = 0
    Protected _BaseDamage As DamageVector

    Public ReadOnly Property WeaponKind() As WeaponType
        Get
            Return _Type
        End Get
    End Property

    Public ReadOnly Property Range() As Integer
        Get
            Return _Range
        End Get
    End Property

    Public ReadOnly Property IsReady() As Boolean
        Get
            Return _CurrentCooldown = 0
        End Get
    End Property

    ''' <summary>Try to fire at a target. Returns the DamageVector if fired, Nothing if on cooldown.</summary>
    Public Function Fire(ByRef target As Unit) As DamageVector
        If _CurrentCooldown > 0 Then Return Nothing
        _CurrentCooldown = _CooldownMarks
        Return CalculateDamage(target)
    End Function

    ''' <summary>Tick cooldown down by one mark.</summary>
    Public Sub Tick()
        If _CurrentCooldown > 0 Then _CurrentCooldown -= 1
    End Sub

    ''' <summary>Override to apply weapon-specific damage modifiers.</summary>
    Protected Overridable Function CalculateDamage(ByRef target As Unit) As DamageVector
        Return _BaseDamage
    End Function

    Public MustOverride ReadOnly Property DisplayName() As String
End Class
