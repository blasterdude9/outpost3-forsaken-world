Public MustInherit Class OreBuilding
    Inherits Building
    Implements IOreFactory

    Protected _CommonOreOutput As Integer = 0
    Protected _RareOreOutput As Integer = 0

    Public Function CommonOreOutput() As Integer Implements IOreFactory.CommonOreOutput
        If _Status = BuildingStatus.ACTIVE Then
            Return _CommonOreOutput
        Else
            Return 0
        End If
    End Function

    Public Function RareOreOutput() As Integer Implements IOreFactory.RareOreOutput
        If _Status = BuildingStatus.ACTIVE Then
            Return _RareOreOutput
        Else
            Return 0
        End If
    End Function
End Class
