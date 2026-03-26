Public Class IOreFactoryCollection
    Inherits CollectionBase

    Public Sub Add(ByVal value As IOreFactory)
        List.Add(value)
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As IOreFactory
        Get
            Return DirectCast(List.Item(index), IOreFactory)
        End Get
    End Property

    Public Sub Remove(ByVal value As IOreFactory)
        List.Remove(value)
    End Sub

    Public Function TotalCommon() As Integer
        Dim t As Integer = 0
        For Each f As IOreFactory In List
            t += f.CommonOreOutput()
        Next
        Return t
    End Function

    Public Function TotalRare() As Integer
        Dim t As Integer = 0
        For Each f As IOreFactory In List
            t += f.RareOreOutput()
        Next
        Return t
    End Function
End Class
