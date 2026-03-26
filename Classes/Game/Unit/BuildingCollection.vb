Public Class BuildingCollection
    Inherits CollectionBase

    Public Sub Add(ByVal value As Building)
        List.Add(value)
    End Sub

    Public Function IndexOf(ByVal value As Building) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As Building)
        List.Insert(index, value)
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As Building
        Get
            Return DirectCast(List.Item(index), Building)
        End Get
    End Property

    Public Sub Remove(ByVal value As Building)
        List.Remove(value)
    End Sub
End Class
