Imports IrrlichtNETCP

Public Class IrrlichtObj
    Private _device As IrrlichtDevice
    Private _driver As VideoDriver
    Private _scene As SceneManager

    Public ReadOnly Property device() As IrrlichtDevice
        Get
            Return _device
        End Get
    End Property

    Public ReadOnly Property driver() As VideoDriver
        Get
            Return _driver
        End Get
    End Property

    Public ReadOnly Property scene() As SceneManager
        Get
            Return _scene
        End Get
    End Property

    Public Sub New(ByRef device As IrrlichtDevice, ByRef driver As VideoDriver, ByRef scene As SceneManager)
        _device = device
        _driver = driver
        _scene = scene
    End Sub
End Class
