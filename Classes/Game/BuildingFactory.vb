''' <summary>
''' Factory that maps building type name strings to concrete BuildOrder instances.
''' Used by AI and (eventually) by player build menus to queue construction.
''' </summary>
Public Class BuildingFactory

    ''' <summary>
    ''' Create a BuildOrder for the named building type at the given position.
    ''' Returns Nothing if the type name is unrecognised.
    ''' </summary>
    Public Shared Function CreateOrder(ByVal typeName As String,
                                       ByVal position As IrrlichtNETCP.Vector3D,
                                       ByRef owner As Player) As BuildQueue.BuildOrder

        ' Normalise: strip faction suffix, lowercase for comparison
        Dim key As String = typeName.ToLower().Replace(" ", "")

        Select Case key

            ' ---- EDEN ----
            Case "tokamak", "tokamakeden"
                Dim b As New TokamakEden(position, owner)
                Return MakeOrder(b, owner)

            Case "commonoresmelter", "commonoresmeltereden"
                Dim b As New CommonOreSmelterEden(position, owner)
                Return MakeOrder(b, owner)

            Case "rareoresmelter", "rareoresmeltereden"
                Dim b As New RareOreSmelterEden(position, owner)
                Return MakeOrder(b, owner)

            Case "residence", "residenceeden"
                Dim b As New ResidenceEden(position, owner)
                Return MakeOrder(b, owner)

            Case "resden", "resdeneden"
                Dim b As New ResDenEden(position, owner)
                Return MakeOrder(b, owner)

            Case "gorf", "gorfeden"
                Dim b As New GORFEden(position, owner)
                Return MakeOrder(b, owner)

            Case "basiclab", "basiclabeden"
                Dim b As New BasicLabEden(position, owner)
                Return MakeOrder(b, owner)

            Case "standardlab", "standardlabeden"
                Dim b As New StandardLabEden(position, owner)
                Return MakeOrder(b, owner)

            Case "advancedlab", "advancedlabeden"
                Dim b As New AdvancedLabEden(position, owner)
                Return MakeOrder(b, owner)

            Case "vehiclefactory", "vehiclefactoryeden"
                Dim b As New VehicleFactoryEden(position, owner)
                Return MakeOrder(b, owner)

            Case "guardpost", "guardposteden"
                Dim b As New GuardPostEden(position, owner)
                Return MakeOrder(b, owner)

            ' ---- PLYMOUTH ----
            Case "mhdgenerator", "mhdgeneratorplymouth"
                Dim b As New MHDGeneratorPlymouth(position, owner)
                Return MakeOrder(b, owner)

            Case "commonoresmelterplymouth"
                Dim b As New CommonOreSmelterPlymouth(position, owner)
                Return MakeOrder(b, owner)

            Case "rareoresmelterplymouth"
                Dim b As New RareOreSmelterPlymouth(position, owner)
                Return MakeOrder(b, owner)

            Case "residenceplymouth"
                Dim b As New ResidencePlymouth(position, owner)
                Return MakeOrder(b, owner)

            Case "nursery", "nurseryplymouth"
                Dim b As New NurseryPlymouth(position, owner)
                Return MakeOrder(b, owner)

            Case "university", "universityplymouth"
                Dim b As New UniversityPlymouth(position, owner)
                Return MakeOrder(b, owner)

            Case "vehiclefactoryplymouth"
                Dim b As New VehicleFactoryPlymouth(position, owner)
                Return MakeOrder(b, owner)

            Case "guardpostplymouth"
                Dim b As New GuardPostPlymouth(position, owner)
                Return MakeOrder(b, owner)

            ' ---- GEMINI ----
            Case "solarcollector", "solarcollectorgemini"
                Dim b As New SolarCollectorGemini(position, owner)
                Return MakeOrder(b, owner)

            Case "commonoresmeltergemini"
                Dim b As New CommonOreSmelterGemini(position, owner)
                Return MakeOrder(b, owner)

            Case "rareoresmeltergemini"
                Dim b As New RareOreSmelterGemini(position, owner)
                Return MakeOrder(b, owner)

            Case "residencegemini"
                Dim b As New ResidenceGemini(position, owner)
                Return MakeOrder(b, owner)

            Case "researchlab", "researchlabgemini"
                Dim b As New ResearchLabGemini(position, owner)
                Return MakeOrder(b, owner)

            Case "vehiclefactorygemini"
                Dim b As New VehicleFactoryGemini(position, owner)
                Return MakeOrder(b, owner)

            Case "guardpostgemini"
                Dim b As New GuardPostGemini(position, owner)
                Return MakeOrder(b, owner)

            ' ---- MICROBE ----
            Case "bioreactor", "bioreactormicrobe"
                Dim b As New BioreactorMicrobe(position, owner)
                Return MakeOrder(b, owner)

            Case "organicextractor", "organicextractormicrobe"
                Dim b As New OrganicExtractorMicrobe(position, owner)
                Return MakeOrder(b, owner)

            Case "hiveden", "hivedenmicrobe"
                Dim b As New HiveDenMicrobe(position, owner)
                Return MakeOrder(b, owner)

            Case "blightlab", "blightlabmicrobe"
                Dim b As New BlightLabMicrobe(position, owner)
                Return MakeOrder(b, owner)

            Case "arachnidfactory", "arachnidfactorymicrobe"
                Dim b As New ArachnidFactoryMicrobe(position, owner)
                Return MakeOrder(b, owner)

            Case "blightturret", "blightturretmicrobe"
                Dim b As New BlightTurretMicrobe(position, owner)
                Return MakeOrder(b, owner)

            Case Else
                Return Nothing
        End Select
    End Function

    Private Shared Function MakeOrder(ByVal b As Building, ByRef owner As Player) As BuildQueue.BuildOrder
        Return New BuildQueue.BuildOrder(
            b.GetType().Name,
            b.BuildPointsRequired,
            b.CommonMetalCost,
            b.RareMetalCost,
            Sub(order As BuildQueue.BuildOrder)
                ' On complete: set building active and add to player collections
                b.SetStatus(Building.BuildingStatus.ACTIVE)
                owner.Buildings.Add(b)
                If TypeOf b Is IPowerPlant Then
                    owner.PowerPlants.Add(DirectCast(b, IPowerPlant))
                End If
            End Sub
        )
    End Function

End Class
