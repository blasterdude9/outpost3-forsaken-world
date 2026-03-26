Imports IrrlichtNETCP

Public Class StructureFactoryMicrobe
    Inherits Building
    Private _BuildQueue As New Queue(Of String)

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 15
        _WorkersRequired = 4
        _ScientistsRequired = 3
        _BuildPointsRequired = 2800
        _TubeRequired = True
        _CommonMetalCost = 2000
        _RareMetalCost = 800
        _Position = position
    End Sub

    Public Sub QueueBuilding(ByVal b As String) : _BuildQueue.Enqueue(b) : End Sub
    Public Function DequeueBuilding() As String
        If _BuildQueue.Count > 0 Then Return _BuildQueue.Dequeue()
        Return Nothing
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get : Return "MicrobeStructureFactory.3ds" : End Get
    End Property
End Class
