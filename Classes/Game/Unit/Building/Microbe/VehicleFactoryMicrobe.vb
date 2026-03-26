Imports IrrlichtNETCP

Public Class VehicleFactoryMicrobe
    Inherits Building
    Private _BuildQueue As New Queue(Of String)

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 20
        _WorkersRequired = 6
        _ScientistsRequired = 3
        _BuildPointsRequired = 3200
        _TubeRequired = True
        _CommonMetalCost = 2500
        _RareMetalCost = 1200
        _Position = position
    End Sub

    Public Sub QueueVehicle(ByVal v As String) 


        _BuildQueue.Enqueue(v)


    End Sub
    Public Function DequeueVehicle() As String
        If _BuildQueue.Count > 0 Then Return _BuildQueue.Dequeue()
        Return Nothing
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get

            Return "MicrobeVehicleFactory.3ds"

        End Get
    End Property
End Class
