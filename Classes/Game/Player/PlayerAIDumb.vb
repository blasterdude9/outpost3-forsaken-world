''' <summary>
''' Dumb AI. Passive expansion strategy — builds economy only, no aggression.
''' Never attacks. Will eventually lose to any aggressive opponent.
''' Useful as a punching bag for testing or as a tutorial difficulty.
'''
''' Strategy per mark:
'''   Phase 1 (marks 1-20):   Build power and ore production
'''   Phase 2 (marks 21-60):  Build housing and research
'''   Phase 3 (marks 61+):    Build vehicle factory, make transports, try to evacuate
''' </summary>
Public Class PlayerAIDumb
    Inherits PlayerAI

    Private _phase As Integer = 1

    Public Overrides Sub RunAI()
        UpdatePhase()

        Select Case _phase
            Case 1 : RunPhase1()
            Case 2 : RunPhase2()
            Case 3 : RunPhase3()
        End Select
    End Sub

    Private Sub UpdatePhase()
        ' Phase transitions driven by resource thresholds
        If _phase = 1 AndAlso _CommonOre > 3000 AndAlso _AvailablePower > 60 Then
            _phase = 2
        ElseIf _phase = 2 AndAlso _Scientists >= 4 AndAlso _Workers >= 8 Then
            _phase = 3
        End If
    End Sub

    ' Phase 1: Get power and ore going
    Private Sub RunPhase1()
        ' If we have common ore and no power plants queued, build a Tokamak
        If _PowerFactories.Count = 0 AndAlso _BuildQueue.Count = 0 Then
            TryBuildEdenBuilding("Tokamak")
        End If
        ' Once we have power, build ore smelters
        If _AvailablePower >= 10 AndAlso CountBuildingType("CommonOreSmelter") < 2 Then
            TryBuildEdenBuilding("CommonOreSmelter")
        End If
    End Sub

    ' Phase 2: Grow population and research
    Private Sub RunPhase2()
        If CountBuildingType("Residence") < 2 Then
            TryBuildEdenBuilding("Residence")
        End If
        If _AvailablePower >= 30 AndAlso CountBuildingType("BasicLab") = 0 Then
            TryBuildEdenBuilding("BasicLab")
        End If
        If _CommonOre > 1000 AndAlso CountBuildingType("RareOreSmelter") = 0 Then
            TryBuildEdenBuilding("RareOreSmelter")
        End If
    End Sub

    ' Phase 3: Build vehicles, try to survive/evacuate — never attacks
    Private Sub RunPhase3()
        If CountBuildingType("VehicleFactory") = 0 Then
            TryBuildEdenBuilding("VehicleFactory")
        End If
        ' Queue transports to fill with colonists
        If _Vehicles.Count < 3 Then
            TryBuildVehicle("Evacuation Transport")
        End If
    End Sub

    ' -------------------------------------------------------------------------
    '  Helpers
    ' -------------------------------------------------------------------------
    Private Sub TryBuildEdenBuilding(ByVal typeName As String)
        If _BuildQueue.Count >= 2 Then Return  ' Don't over-queue
        Dim pos As New IrrlichtNETCP.Vector3D(
            CSng(New System.Random().Next(5, 20)),
            0,
            CSng(New System.Random().Next(5, 20))
        )
        Dim order As BuildQueue.BuildOrder = BuildingFactory.CreateOrder(typeName, pos, DirectCast(Me, Player))
        If order IsNot Nothing Then
            _BuildQueue.Enqueue(order)
        End If
    End Sub

    Private Sub TryBuildVehicle(ByVal typeName As String)
        ' Find an active vehicle factory
        For i As Integer = 0 To _Buildings.Count - 1
            If TypeOf _Buildings(i) Is IVehicleFactory Then
                Dim factory As IVehicleFactory = DirectCast(_Buildings(i), IVehicleFactory)
                If factory.CanProduceVehicle(typeName) Then
                    ' Add vehicle directly (simplified — real impl would use factory queue)
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

End Class
