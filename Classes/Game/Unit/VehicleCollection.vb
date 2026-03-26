Public Class VehicleCollection
    Inherits CollectionBase

    Public Sub Add(ByVal value As Vehicle)
        List.Add(value)
    End Sub

    Public Function IndexOf(ByVal value As Vehicle) As Integer
        Return List.IndexOf(value)
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As Vehicle
        Get
            Return DirectCast(List.Item(index), Vehicle)
        End Get
    End Property

    Public Sub Remove(ByVal value As Vehicle)
        List.Remove(value)
    End Sub

    Public Function GetByType(ByVal t As Vehicle.VehicleType) As VehicleCollection
        Dim result As New VehicleCollection()
        For Each v As Vehicle In List
            If v.VehicleKind = t Then result.Add(v)
        Next
        Return result
    End Function
End Class
