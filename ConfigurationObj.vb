Imports IrrlichtNETCP
Imports Microsoft.Win32

Public Class ConfigurationObj
    Protected _InstallPath As String
    Protected _DriverType As DriverType
    Protected _Resolution As Dimension2D
    Protected _ColorDepth As Integer
    Protected _FullScreen As Boolean
    Protected _VSync As Boolean
    Protected _AntiAlias As Boolean
    Protected _GameServerHost As String
    Protected _GameServerPort As Integer

    ''' <summary>
    ''' Loads Application Configuration from Registry
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        _InstallPath = System.IO.Directory.GetCurrentDirectory()
        _DriverType = IrrlichtNETCP.DriverType.OpenGL
        _Resolution = New Dimension2D(800, 600)
        _ColorDepth = 32
        _FullScreen = False
        _VSync = False
        _AntiAlias = True
        _GameServerHost = "127.0.0.1"
        _GameServerPort = 10032
    End Sub

    Public ReadOnly Property InstallPath() As String
        Get
            Return _InstallPath
        End Get
    End Property

    Public ReadOnly Property DriverType() As DriverType
        Get
            Return _DriverType
        End Get
    End Property

    Public ReadOnly Property Resolution() As Dimension2D
        Get
            Return _Resolution
        End Get
    End Property

    Public ReadOnly Property ColorDepth() As Integer
        Get
            Return ColorDepth
        End Get
    End Property

    Public ReadOnly Property VSync() As Boolean
        Get
            Return _VSync
        End Get
    End Property

    Public ReadOnly Property AntiAlias() As Boolean
        Get
            Return _AntiAlias
        End Get
    End Property

    Public ReadOnly Property GameServerHost() As String
        Get
            Return _GameServerHost
        End Get
    End Property

    Public ReadOnly Property GameServerPort() As Integer
        Get
            Return _GameServerPort
        End Get
    End Property

    Public ReadOnly Property FullScreen() As Boolean
        Get
            Return _FullScreen
        End Get
    End Property
End Class
