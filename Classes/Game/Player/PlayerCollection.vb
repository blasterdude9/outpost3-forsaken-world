Public Class PlayerCollection
    Inherits CollectionBase

    Public Sub Add(ByVal value As Player)
        List.Add(value)
    End Sub

    Public Function IndexOf(ByVal value As Player) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As Player)
        List.Insert(index, value)
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As Player
        Get
            Return DirectCast(List.Item(index), Player)
        End Get
    End Property

    Public Sub Remove(ByVal value As Player)
        List.Remove(value)
    End Sub
End Class
