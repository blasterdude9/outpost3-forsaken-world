Public MustInherit Class PowerPlantBuilding
    Inherits Building
    Implements IPowerPlant

    Protected _ProductionLevel As Integer = 0
    Protected _RequiresSatellite As Boolean = False
    Protected _DeteriorateRate As Integer = 0
    Public Function PowerOutput() As Integer Implements IPowerPlant.PowerOutput
        Return _ProductionLevel
    End Function
End Class
