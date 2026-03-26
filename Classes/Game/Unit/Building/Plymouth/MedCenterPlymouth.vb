Imports IrrlichtNETCP

Public Class MedCenterPlymouth
    Inherits Building

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 14
        _WorkersRequired = 3
        _ScientistsRequired = 2
        _BuildPointsRequired = 1800
        _TubeRequired = True
        _CommonMetalCost = 1100
        _RareMetalCost = 200
        _Position = position
    End Sub

    Public ReadOnly Property MoraleBonus() As Integer
        Get
            If _Status = BuildingStatus.ACTIVE Then Return 4
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthMedCenter.3ds"
        End Get
    End Property
End Class
