Public MustInherit Class FoodBuilding
    Inherits Building
    Implements IFoodFactory

    Protected _FoodOutput As Integer = 0

    Public Function FoodOutput() As Integer Implements IFoodFactory.FoodOutput
        If _Status = BuildingStatus.ACTIVE Then
            Return _FoodOutput
        Else
            Return 0
        End If
    End Function
End Class
