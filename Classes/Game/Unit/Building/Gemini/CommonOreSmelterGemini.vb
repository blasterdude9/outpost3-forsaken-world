Imports IrrlichtNETCP
''' <summary>Gemini Common Ore Smelter. Same yield as Eden but cheaper to build.</summary>
Public Class CommonOreSmelterGemini
    Inherits Building
    Implements IOreProducer

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 10
        _WorkersRequired = 2
        _BuildPointsRequired = 700
        _CommonMetalCost = 700
        _TubeRequired = True
        _ResourceWeight = 200
        _Position = position
    End Sub

    Public Function CommonOreOutput() As Integer Implements IOreProducer.CommonOreOutput
        Return 15
    End Function
    Public Function RareOreOutput() As Integer Implements IOreProducer.RareOreOutput
        Return 0
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiCommonOreSmelter.3ds"
        End Get
    End Property
End Class
