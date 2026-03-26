Imports IrrlichtNETCP
''' <summary>Eden Residence. Houses workers and children. Required for population growth.</summary>
Public Class ResidenceEden
    Inherits Building
    Implements IResidential

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 5
        _WorkersRequired = 1
        _ScientistsRequired = 0
        _BuildPointsRequired = 600
        _CommonMetalCost = 600
        _RareMetalCost = 0
        _TubeRequired = True
        _ResourceWeight = 150
        _Position = position
    End Sub

    Public Function HousingCapacity() As Integer Implements IResidential.HousingCapacity
        Return 20
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenResidence.3ds"
        End Get
    End Property
End Class
