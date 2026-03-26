Imports IrrlichtNETCP

''' <summary>Eden Structure Factory — constructs new buildings via ConVec deployment.</summary>
Public Class StructureFactoryEden
    Inherits Building

    Private _BuildQueue As New Queue(Of String)

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 20
        _WorkersRequired = 6
        _ScientistsRequired = 2
        _BuildPointsRequired = 3500
        _TubeRequired = True
        _CommonMetalCost = 3000
        _RareMetalCost = 500
        _Position = position
    End Sub

    Public Sub QueueBuilding(ByVal buildingName As String)
        _BuildQueue.Enqueue(buildingName)
    End Sub

    Public Function DequeueBuilding() As String
        If _BuildQueue.Count > 0 Then
            Return _BuildQueue.Dequeue()
        End If
        Return Nothing
    End Function

    Public ReadOnly Property QueueCount() As Integer
        Get
            Return _BuildQueue.Count
        End Get
    End Property

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenStructureFactory.3ds"
        End Get
    End Property
End Class
