''' <summary>
''' Manages all resource production, consumption, and population ticks for a player each game mark.
''' Called once per mark by the GameLoop. All values are integers representing raw units.
''' </summary>
Public Class ResourceManager

    ''' <summary>
    ''' One game mark = ~2 seconds real time. Controls all tick rates.
    ''' </summary>
    Public Const MARKS_PER_CYCLE As Integer = 32

    ''' <summary>
    ''' Process one game mark for the given player.
    ''' Order: Power -> Ore -> Food -> Population -> Morale -> Building Status
    ''' </summary>
    Public Shared Sub Tick(ByRef p As AbstractPlayer)
        TickPower(p)
        TickOre(p)
        TickPopulation(p)
        TickMorale(p)
        TickBuildingStatus(p)
    End Sub

    ' -------------------------------------------------------------------------
    '  POWER
    ' -------------------------------------------------------------------------
    Private Shared Sub TickPower(ByRef p As AbstractPlayer)
        Dim totalOutput As Integer = 0
        For i As Integer = 0 To p.PowerPlants.Count - 1
            totalOutput += p.PowerPlants(i).PowerOutput()
        Next

        Dim totalDemand As Integer = 0
        For i As Integer = 0 To p.Buildings.Count - 1
            totalDemand += p.Buildings(i).PowerRequired
        Next

        p.SetAvailablePower(totalOutput)
        p.SetPowerDemand(totalDemand)

        ' If we can't meet demand, start disabling buildings by resource weight (highest weight = least important)
        If totalOutput < totalDemand Then
            Dim deficit As Integer = totalDemand - totalOutput
            ' Sort buildings by ResourceWeight descending, disable until deficit covered
            For i As Integer = 0 To p.Buildings.Count - 1
                Dim b As Building = p.Buildings(i)
                If b.Status <> "Disabled - Power" And b.PowerRequired > 0 Then
                    b.SetStatus(Building.BuildingStatus.DISABLED_POWER)
                    deficit -= b.PowerRequired
                    If deficit <= 0 Then Exit For
                End If
            Next
        Else
            ' Re-enable power-disabled buildings if we now have enough
            For i As Integer = 0 To p.Buildings.Count - 1
                Dim b As Building = p.Buildings(i)
                If b.StatusEnum = Building.BuildingStatus.DISABLED_POWER Then
                    b.SetStatus(Building.BuildingStatus.ACTIVE)
                End If
            Next
        End If
    End Sub

    ' -------------------------------------------------------------------------
    '  ORE MINING
    ' -------------------------------------------------------------------------
    Private Shared Sub TickOre(ByRef p As AbstractPlayer)
        ' Each active ore smelter / mine adds ore * multiplier per mark
        For i As Integer = 0 To p.Buildings.Count - 1
            Dim b As Building = p.Buildings(i)
            If b.StatusEnum = Building.BuildingStatus.ACTIVE Then
                If TypeOf b Is IOreProducer Then
                    Dim mine As IOreProducer = DirectCast(b, IOreProducer)
                    p.AddCommonOre(CInt(mine.CommonOreOutput() * p.CommonMultiplier))
                    p.AddRareOre(CInt(mine.RareOreOutput() * p.RareMultipler))
                End If
            End If
        Next
    End Sub

    ' -------------------------------------------------------------------------
    '  POPULATION GROWTH
    ' -------------------------------------------------------------------------
    Private Shared Sub TickPopulation(ByRef p As AbstractPlayer)
        ' Population grows toward a capacity determined by active residential buildings
        Dim capacity As Integer = 0
        For i As Integer = 0 To p.Buildings.Count - 1
            Dim b As Building = p.Buildings(i)
            If b.StatusEnum = Building.BuildingStatus.ACTIVE Then
                If TypeOf b Is IResidential Then
                    capacity += DirectCast(b, IResidential).HousingCapacity()
                End If
            End If
        Next

        Dim total As Integer = p.Workers + p.Scientists + p.Children
        If total < capacity Then
            ' Births: one child per MARKS_PER_CYCLE marks when morale > 25
            If p.Morale > 25 Then
                p.AddChildren(1)
            End If
        End If

        ' Children age into workers every MARKS_PER_CYCLE * 4 marks (handled externally via age counter)
        ' Starvation: if no food buildings and population > 0, lose morale fast
    End Sub

    ' -------------------------------------------------------------------------
    '  MORALE
    ' -------------------------------------------------------------------------
    Private Shared Sub TickMorale(ByRef p As AbstractPlayer)
        Dim delta As Integer = 0

        ' Has an active command center?
        Dim hasCC As Boolean = False
        For i As Integer = 0 To p.Buildings.Count - 1
            If p.Buildings(i).IsActiveCommandCenter Then
                hasCC = True
                Exit For
            End If
        Next
        If Not hasCC Then delta -= 3

        ' Power shortage penalty
        If p.PowerDemand > p.AvailablePower Then delta -= 2

        ' Baseline morale recovery
        delta += 1

        ' Clamp morale 0-100
        Dim newMorale As Integer = Math.Max(0, Math.Min(100, p.Morale + delta))
        p.SetMorale(newMorale)
    End Sub

    ' -------------------------------------------------------------------------
    '  BUILDING STATUS VALIDATION
    ' -------------------------------------------------------------------------
    Private Shared Sub TickBuildingStatus(ByRef p As AbstractPlayer)
        Dim hasCC As Boolean = False
        For i As Integer = 0 To p.Buildings.Count - 1
            If p.Buildings(i).IsActiveCommandCenter Then
                hasCC = True
                Exit For
            End If
        Next

        For i As Integer = 0 To p.Buildings.Count - 1
            Dim b As Building = p.Buildings(i)

            ' Buildings that require a command center go offline if none active
            If Not b.IsCommandCenter Then
                If Not hasCC And b.StatusEnum <> Building.BuildingStatus.DISABLED_NOCOMMANDCENTER Then
                    b.SetStatus(Building.BuildingStatus.DISABLED_NOCOMMANDCENTER)
                ElseIf hasCC And b.StatusEnum = Building.BuildingStatus.DISABLED_NOCOMMANDCENTER Then
                    b.SetStatus(Building.BuildingStatus.ACTIVE)
                End If
            End If

            ' Worker and scientist checks
            If b.StatusEnum = Building.BuildingStatus.ACTIVE Then
                If b.WorkersRequired > p.Workers Then
                    b.SetStatus(Building.BuildingStatus.DISABLED_WORKERS)
                ElseIf b.ScientistsRequired > p.Scientists Then
                    b.SetStatus(Building.BuildingStatus.DISABLED_SCIENTISTS)
                End If
            End If

            ' Spontaneously exploding buildings (Microbe blight risk)
            If b.SpontaneouslyExplodes And b.StatusEnum = Building.BuildingStatus.ACTIVE Then
                Dim rng As New System.Random()
                If rng.NextDouble() < 0.001 Then  ' 0.1% chance per mark
                    b.SetStatus(Building.BuildingStatus.DISABLED_BLIGHT)
                End If
            End If
        Next
    End Sub

End Class
