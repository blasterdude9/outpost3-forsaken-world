Imports IrrlichtNETCP
''' <summary>Plymouth Residence. Slightly larger capacity than Eden's.</summary>
Public Class ResidencePlymouth
    Inherits Building
    Implements IResidential

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 5
        _WorkersRequired = 1
        _BuildPointsRequired = 700
        _CommonMetalCost = 700
        _TubeRequired = True
        _ResourceWeight = 150
        _Position = position
    End Sub

    Public Function HousingCapacity() As Integer Implements IResidential.HousingCapacity
        Return 24
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthResidence.3ds"
        End Get
    End Property
End Class
