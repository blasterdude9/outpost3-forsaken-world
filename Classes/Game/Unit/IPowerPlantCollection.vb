Public Class IPowerFactoryCollection
    Inherits CollectionBase

    Public Sub Add(ByVal value As IPowerPlant)
        List.Add(value)
    End Sub

    Public Function IndexOf(ByVal value As IPowerPlant) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As IPowerPlant)
        List.Insert(index, value)
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As IPowerPlant
        Get
            Return DirectCast(List.Item(index), IPowerPlant)
        End Get
    End Property

    Public Sub Remove(ByVal value As IPowerPlant)
        List.Remove(value)
    End Sub

    Public Function TotalOutput() As Integer
        Dim total As Integer = 0
        For Each p As IPowerPlant In List
            total += p.PowerOutput()
        Next
        Return total
    End Function
End Class
