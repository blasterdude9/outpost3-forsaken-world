Imports IrrlichtNETCP

Public Class StructureFactoryPlymouth
    Inherits Building

    Private _BuildQueue As New Queue(Of String)

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 18
        _WorkersRequired = 7
        _ScientistsRequired = 1
        _BuildPointsRequired = 3200
        _TubeRequired = True
        _CommonMetalCost = 2800
        _RareMetalCost = 400
        _Position = position
    End Sub

    Public Sub QueueBuilding(ByVal buildingName As String)
        _BuildQueue.Enqueue(buildingName)
    End Sub

    Public Function DequeueBuilding() As String
        If _BuildQueue.Count > 0 Then Return _BuildQueue.Dequeue()
        Return Nothing
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthStructureFactory.3ds"
        End Get
    End Property
End Class
