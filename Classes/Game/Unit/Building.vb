Public MustInherit Class Building
    Inherits Unit

    Public Enum BuildingStatus As Integer
        ACTIVE = 0
        DISABLED_EMP = 1
        DISABLED_NOCOMMANDCENTER = 2
        DISABLED_DAMAGED = 3
        DISABLED_POWER = 4
        DISABLED_SCIENTISTS = 5
        DISABLED_WORKERS = 6
        DISABLED_BLIGHT = 7
        NONE = -1
    End Enum

    Protected _Status As BuildingStatus = BuildingStatus.NONE
    Protected _PowerRequired As Integer = 0
    Protected _Power As Integer = 0
    Protected _WorkersRequired As Integer = 0
    Protected _Workers As Integer = 0
    Protected _ScientistsRequired As Integer = 0
    Protected _Scientists As Integer = 0
    Protected _BuildPointsRequired As Integer = 0
    Protected _BuildPoints As Integer = 0
    Protected _TubeRequired As Boolean = True
    Protected _Tube As Boolean = False
    Protected _CommonMetalCost As Integer = 0
    Protected _RareMetalCost As Integer = 0
    Protected _IsCommandCenter As Boolean = False
    Protected _SpontaneouslyExplodes As Boolean = False
    Protected _ResourceWeight As Integer = 999

    Public ReadOnly Property StatusEnum() As BuildingStatus
        Get
            Return _Status
        End Get
    End Property

    Public Sub SetStatus(ByVal s As BuildingStatus)
        _Status = s
    End Sub

    Public ReadOnly Property Status() As String
        Get
            Select Case _Status
                Case BuildingStatus.ACTIVE                      : Return "Active"
                Case BuildingStatus.DISABLED_DAMAGED            : Return "Disabled - Damage"
                Case BuildingStatus.DISABLED_EMP                : Return "Disabled - EMP"
                Case BuildingStatus.DISABLED_NOCOMMANDCENTER    : Return "Disabled - Command Center"
                Case BuildingStatus.DISABLED_POWER              : Return "Disabled - Power"
                Case BuildingStatus.DISABLED_SCIENTISTS         : Return "Disabled - Scientists"
                Case BuildingStatus.DISABLED_WORKERS            : Return "Disabled - Workers"
                Case BuildingStatus.DISABLED_BLIGHT             : Return "Disabled - Blight"
                Case Else                                       : Return "Disabled"
            End Select
        End Get
    End Property

    Public ReadOnly Property IsCommandCenter() As Boolean
        Get
            Return _IsCommandCenter
        End Get
    End Property

    Public ReadOnly Property IsActiveCommandCenter() As Boolean
        Get
            Return _IsCommandCenter AndAlso _Status = BuildingStatus.ACTIVE
        End Get
    End Property

    Public ReadOnly Property PowerRequired() As Integer
        Get
            Return _PowerRequired
        End Get
    End Property

    Public ReadOnly Property WorkersRequired() As Integer
        Get
            Return _WorkersRequired
        End Get
    End Property

    Public ReadOnly Property ScientistsRequired() As Integer
        Get
            Return _ScientistsRequired
        End Get
    End Property

    Public ReadOnly Property BuildPointsRequired() As Integer
        Get
            Return _BuildPointsRequired
        End Get
    End Property

    Public ReadOnly Property CommonMetalCost() As Integer
        Get
            Return _CommonMetalCost
        End Get
    End Property

    Public ReadOnly Property RareMetalCost() As Integer
        Get
            Return _RareMetalCost
        End Get
    End Property

    Public ReadOnly Property TubeRequired() As Boolean
        Get
            Return _TubeRequired
        End Get
    End Property

    Public ReadOnly Property ResourceWeight() As Integer
        Get
            Return _ResourceWeight
        End Get
    End Property

    Public ReadOnly Property SpontaneouslyExplodes() As Boolean
        Get
            Return _SpontaneouslyExplodes
        End Get
    End Property

End Class
