Imports IrrlichtNETCP
''' <summary>Gemini Residence.</summary>
Public Class ResidenceGemini
    Inherits Building
    Implements IResidential

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 5
        _WorkersRequired = 1
        _BuildPointsRequired = 550
        _CommonMetalCost = 550
        _TubeRequired = True
        _ResourceWeight = 150
        _Position = position
    End Sub

    Public Function HousingCapacity() As Integer Implements IResidential.HousingCapacity
        Return 18
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiResidence.3ds"
        End Get
    End Property
End Class
