Imports IrrlichtNETCP

Public Class StructureFactoryGemini
    Inherits Building
    Private _BuildQueue As New Queue(Of String)

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 20
        _WorkersRequired = 6
        _ScientistsRequired = 2
        _BuildPointsRequired = 3300
        _TubeRequired = True
        _CommonMetalCost = 2900
        _RareMetalCost = 450
        _Position = position
    End Sub

    Public Sub QueueBuilding(ByVal b As String) : _BuildQueue.Enqueue(b) : End Sub
    Public Function DequeueBuilding() As String
        If _BuildQueue.Count > 0 Then Return _BuildQueue.Dequeue()
        Return Nothing
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiStructureFactory.3ds"
        End Get
    End Property
End Class
