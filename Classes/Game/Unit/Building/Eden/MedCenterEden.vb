Imports IrrlichtNETCP

''' <summary>
''' Eden Medical Center — raises morale and reduces disease mortality.
''' Required to maintain population growth past a certain size.
''' </summary>
Public Class MedCenterEden
    Inherits Building

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 12
        _WorkersRequired = 2
        _ScientistsRequired = 3
        _BuildPointsRequired = 2000
        _TubeRequired = True
        _CommonMetalCost = 1200
        _RareMetalCost = 300
        _Position = position
    End Sub

    Public ReadOnly Property MoraleBonus() As Integer
        Get
            If _Status = BuildingStatus.ACTIVE Then
                Return 5
            End If
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenMedCenter.3ds"
        End Get
    End Property
End Class
