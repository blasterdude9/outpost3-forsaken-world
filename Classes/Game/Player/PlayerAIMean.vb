''' <summary>
''' Mean AI. Aggressive rush/harass strategy. Prioritises combat vehicles early,
''' attacks the nearest enemy building the moment it has 3+ units.
'''
''' Strategy phases:
'''   Phase 1 (economy):  Build CC + 1 power plant + 1 smelter, minimal housing
'''   Phase 2 (military): Spam Lynx units, rush the enemy CC
'''   Phase 3 (sustained): Add Panther/Tiger support, never stop pushing
'''   Fallback:            If losing badly, switch to defensive guard posts
''' </summary>
Public Class PlayerAIMean
    Inherits PlayerAI

    Private Enum AIPhase
        ECONOMY = 0
        RUSH = 1
        SUSTAINED = 2
        DEFEND = 3
    End Enum

    Private _currentPhase As AIPhase = AIPhase.ECONOMY
    Private _rng As New System.Random()
    Private _attackTarget As Unit = Nothing
    Private _marksSinceLastAttack As Integer = 0

    Public Overrides Sub RunAI()
        UpdatePhase()

        Select Case _currentPhase
            Case AIPhase.ECONOMY  : RunEconomy()
            Case AIPhase.RUSH     : RunRush()
            Case AIPhase.SUSTAINED: RunSustained()
            Case AIPhase.DEFEND   : RunDefend()
        End Select

        ' Always try to attack with idle combat vehicles
        IssueAttackOrders()
        _marksSinceLastAttack += 1
    End Sub

    ' -------------------------------------------------------------------------
    '  PHASE TRANSITIONS
    ' -------------------------------------------------------------------------
    Private Sub UpdatePhase()
        Dim combatCount As Integer = CountCombatVehicles()
        Dim hasFactory As Boolean = CountBuildingType("VehicleFactory") > 0
        Dim isLosing As Boolean = (_Buildings.Count <= 2)

        Select Case _currentPhase
            Case AIPhase.ECONOMY
                If hasFactory AndAlso combatCount >= 1 Then
                    _currentPhase = AIPhase.RUSH
                End If
            Case AIPhase.RUSH
                If combatCount >= 6 Then
                    _currentPhase = AIPhase.SUSTAINED
                ElseIf isLosing Then
                    _currentPhase = AIPhase.DEFEND
                End If
            Case AIPhase.SUSTAINED
                If isLosing Then
                    _currentPhase = AIPhase.DEFEND
                End If
            Case AIPhase.DEFEND
                ' Recover back to rush if we rebuild enough
                If combatCount >= 4 AndAlso _Buildings.Count > 3 Then
                    _currentPhase = AIPhase.RUSH
                End If
        End Select
    End Sub

    ' -------------------------------------------------------------------------
    '  PHASE 1 — ECONOMY (minimal build to enable factory fast)
    ' -------------------------------------------------------------------------
    Private Sub RunEconomy()
        If _BuildQueue.Count >= 1 Then Return  ' One thing at a time for speed

        Dim hasPower As Boolean = (_PowerFactories.Count > 0)
        Dim hasOre As Boolean = (CountBuildingType("OreSmelter") > 0 OrElse CountBuildingType("OrganicExtractor") > 0)
        Dim hasFactory As Boolean = (CountBuildingType("VehicleFactory") > 0 OrElse CountBuildingType("ArachnidFactory") > 0)

        If Not hasPower Then
            TryBuild("Tokamak")         ' Eden default; faction logic would swap this
        ElseIf Not hasOre Then
            TryBuild("CommonOreSmelter")
        ElseIf CountBuildingType("Residence") = 0 Then
            TryBuild("Residence")       ' Need workers
        ElseIf Not hasFactory Then
            TryBuild("VehicleFactory")
        End If
    End Sub

    ' -------------------------------------------------------------------------
    '  PHASE 2 — RUSH (spam light vehicles, build guard posts for defense)
    ' -------------------------------------------------------------------------
    Private Sub RunRush()
        ' Keep making Lynx units as fast as possible
        If CountCombatVehicles() < 5 Then
            TryBuildVehicle("Lynx")
        End If

        ' One guard post to protect the CC while we're away
        If CountBuildingType("GuardPost") = 0 AndAlso _CommonOre > 600 Then
            TryBuild("GuardPost")
        End If

        ' Opportunistically add a second smelter
        If CountBuildingType("CommonOreSmelter") < 2 AndAlso _BuildQueue.Count = 0 Then
            TryBuild("CommonOreSmelter")
        End If
    End Sub

    ' -------------------------------------------------------------------------
    '  PHASE 3 — SUSTAINED (diversify units, expand production)
    ' -------------------------------------------------------------------------
    Private Sub RunSustained()
        Dim combatCount As Integer = CountCombatVehicles()

        ' Keep unit count growing
        If combatCount < 12 Then
            ' Mix in heavier units
            If combatCount Mod 3 = 0 Then
                TryBuildVehicle("Panther")
            Else
                TryBuildVehicle("Lynx")
            End If
        End If

        ' Add Tiger every 15 marks once we have enough ore
        If _marksSinceLastAttack > 15 AndAlso _CommonOre > 2000 Then
            TryBuildVehicle("Tiger")
        End If

        ' Extra smelters to keep ore flowing
        If CountBuildingType("CommonOreSmelter") < 3 AndAlso _BuildQueue.Count = 0 Then
            TryBuild("CommonOreSmelter")
        End If

        ' Guard posts around the base perimeter
        If CountBuildingType("GuardPost") < 3 Then
            TryBuild("GuardPost")
        End If
    End Sub

    ' -------------------------------------------------------------------------
    '  PHASE 4 — DEFEND (hunkering down, repair and hold)
    ' -------------------------------------------------------------------------
    Private Sub RunDefend()
        ' Max out guard posts
        If CountBuildingType("GuardPost") < 5 AndAlso _BuildQueue.Count = 0 Then
            TryBuild("GuardPost")
        End If
        ' Don't waste ore on offense; rebuild economy first
        If CountBuildingType("CommonOreSmelter") < 2 AndAlso _BuildQueue.Count = 0 Then
            TryBuild("CommonOreSmelter")
        End If
        ' A few defensive vehicles
        If CountCombatVehicles() < 3 Then
            TryBuildVehicle("Lynx")
        End If
    End Sub

    ' -------------------------------------------------------------------------
    '  ATTACK LOGIC
    ' -------------------------------------------------------------------------
    Private Sub IssueAttackOrders()
        If CountCombatVehicles() = 0 Then Return
        If _marksSinceLastAttack < 5 Then Return  ' Don't spam orders every mark

        ' Find the closest enemy building as a target
        ' NOTE: In real game, we'd scan all player lists. Here we stub the target scan.
        ' Attach real implementation when IPlayerCollection is passed to AI constructor.
        _marksSinceLastAttack = 0

        ' Send all idle combat vehicles toward the last known target
        For i As Integer = 0 To _Vehicles.Count - 1
            Dim v As Vehicle = _Vehicles(i)
            If v.State = Vehicle.VehicleState.IDLE AndAlso IsCombatVehicle(v) Then
                ' Attack toward a forward position (simplified — real AI uses target coords)
                Dim fwd As New IrrlichtNETCP.Vector3D(
                    v.Position.X + CSng(_rng.Next(5, 20)),
                    0,
                    v.Position.Z + CSng(_rng.Next(5, 20))
                )
                v.MoveTo(fwd)
            End If
        Next
    End Sub

    ' -------------------------------------------------------------------------
    '  HELPERS
    ' -------------------------------------------------------------------------
    Private Sub TryBuild(ByVal typeName As String)
        If _BuildQueue.Count >= 2 Then Return
        Dim pos As New IrrlichtNETCP.Vector3D(
            CSng(_rng.Next(3, 25)), 0, CSng(_rng.Next(3, 25))
        )
        Dim order As BuildQueue.BuildOrder = BuildingFactory.CreateOrder(typeName, pos, DirectCast(Me, Player))
        If order IsNot Nothing Then _BuildQueue.Enqueue(order)
    End Sub

    Private Sub TryBuildVehicle(ByVal typeName As String)
        For i As Integer = 0 To _Buildings.Count - 1
            If TypeOf _Buildings(i) Is IVehicleFactory Then
                Dim f As IVehicleFactory = DirectCast(_Buildings(i), IVehicleFactory)
                If f.CanProduceVehicle(typeName) Then
                    Dim v As Vehicle = VehicleFactory.Create(typeName, DirectCast(Me, Player))
                    If v IsNot Nothing Then _Vehicles.Add(v)
                    Return
                End If
            End If
        Next
    End Sub

    Private Function CountBuildingType(ByVal typeName As String) As Integer
        Dim count As Integer = 0
        For i As Integer = 0 To _Buildings.Count - 1
            If _Buildings(i).GetType().Name.Contains(typeName) Then count += 1
        Next
        Return count
    End Function

    Private Function CountCombatVehicles() As Integer
        Dim count As Integer = 0
        For i As Integer = 0 To _Vehicles.Count - 1
            If IsCombatVehicle(_Vehicles(i)) Then count += 1
        Next
        Return count
    End Function

    Private Function IsCombatVehicle(ByVal v As Vehicle) As Boolean
        Return v.EquippedWeapon IsNot Nothing
    End Function

End Class
