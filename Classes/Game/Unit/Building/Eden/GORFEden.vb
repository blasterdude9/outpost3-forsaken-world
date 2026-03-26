Imports IrrlichtNETCP
''' <summary>
''' Eden GORF (General-purpose ORe Facility). Mines and smelts ore AND provides housing.
''' Jack of all trades — less efficient than dedicated buildings but great early-game.
''' </summary>
Public Class GORFEden
    Inherits Building
    Implements IOreProducer
    Implements IResidential

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 12
        _WorkersRequired = 3
        _ScientistsRequired = 0
        _BuildPointsRequired = 900
        _CommonMetalCost = 900
        _RareMetalCost = 0
        _TubeRequired = True
        _ResourceWeight = 250
        _Position = position
    End Sub

    Public Function CommonOreOutput() As Integer Implements IOreProducer.CommonOreOutput
        Return 8
    End Function
    Public Function RareOreOutput() As Integer Implements IOreProducer.RareOreOutput
        Return 2
    End Function
    Public Function HousingCapacity() As Integer Implements IResidential.HousingCapacity
        Return 10
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenGORF.3ds"
        End Get
    End Property
End Class
