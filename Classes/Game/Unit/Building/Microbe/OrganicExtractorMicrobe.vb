Imports IrrlichtNETCP
''' <summary>
''' Microbe Organic Extractor. Mines ore via biological dissolution.
''' Slower than a smelter but can extract from low-yield deposits other factions ignore.
''' </summary>
Public Class OrganicExtractorMicrobe
    Inherits Building
    Implements IOreProducer

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 8
        _WorkersRequired = 1
        _ScientistsRequired = 1
        _BuildPointsRequired = 750
        _CommonMetalCost = 600
        _RareMetalCost = 200
        _TubeRequired = True
        _ResourceWeight = 200
        _SpontaneouslyExplodes = True
        _Position = position
    End Sub

    Public Function CommonOreOutput() As Integer Implements IOreProducer.CommonOreOutput
        Return 12
    End Function
    Public Function RareOreOutput() As Integer Implements IOreProducer.RareOreOutput
        Return 4   ' Microbe extracts rare even from common deposits
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeOrganicExtractor.3ds"
        End Get
    End Property
End Class
