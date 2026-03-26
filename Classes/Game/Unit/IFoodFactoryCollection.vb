Public Class IFoodFactoryCollection
    Inherits CollectionBase

    Public Sub Add(ByVal value As IFoodFactory)
        List.Add(value)
    End Sub

    Public Function IndexOf(ByVal value As IFoodFactory) As Integer
        Return List.IndexOf(value)
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As IFoodFactory
        Get
            Return DirectCast(List.Item(index), IFoodFactory)
        End Get
    End Property

    Public Sub Remove(ByVal value As IFoodFactory)
        List.Remove(value)
    End Sub

    Public Function TotalOutput() As Integer
        Dim total As Integer = 0
        For Each f As IFoodFactory In List
            total += f.FoodOutput()
        Next
        Return total
    End Function
End Class
