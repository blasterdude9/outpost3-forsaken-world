Public Class IPlayerCollection
    Inherits CollectionBase

    Public Function Add(ByVal value As IPlayer) As Integer
        Return List.Add(value)
    End Function

    Public Function IndexOf(ByVal value As IPlayer) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As IPlayer)
        List.Insert(index, value)
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As Player
        Get
            Return DirectCast(List.Item(index), IPlayer)
        End Get
    End Property

    Public Sub Remove(ByVal value As IPlayer)
        List.Remove(value)
    End Sub
End Class
