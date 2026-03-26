''' <summary>
''' Factory that maps vehicle type name strings to concrete Vehicle instances.
''' Used by AI and build queues to instantiate vehicles by name.
''' </summary>
Public Class VehicleFactory

    Public Shared Function Create(ByVal typeName As String, ByRef owner As Player) As Vehicle
        Select Case typeName.ToLower().Replace(" ", "")

            ' ---- EDEN ----
            Case "lynx", "lynxeden"             : Return New LynxEden(owner)
            Case "panther", "panthereden"        : Return New PantherEden(owner)
            Case "tiger", "tigereden"            : Return New TigerEden(owner)
            Case "spider", "spidereden"          : Return New SpiderEden(owner)
            Case "conveceden"                    : Return New ConVecEden(owner)
            Case "evacuationtransport",
                 "evacuationtransporteden"       : Return New EvacuationTransportEden(owner)

            ' ---- PLYMOUTH ----
            Case "lynxplymouth"                  : Return New LynxPlymouth(owner)
            Case "pantherplymouth"               : Return New PantherPlymouth(owner)
            Case "tigerplymouth"                 : Return New TigerPlymouth(owner)
            Case "convecplymouth"                : Return New ConVecPlymouth(owner)
            Case "evacuationtransportplymouth"   : Return New EvacuationTransportPlymouth(owner)

            ' ---- GEMINI ----
            Case "lynxgemini"                    : Return New LynxGemini(owner)
            Case "panthergemini"                 : Return New PantherGemini(owner)
            Case "tigergemini"                   : Return New TigerGemini(owner)
            Case "convecgemini"                  : Return New ConVecGemini(owner)

            ' ---- MICROBE ----
            Case "arachnidscout",
                 "arachnidscoutmicrobe"          : Return New ArachnidScoutMicrobe(owner)
            Case "arachnidwarrior",
                 "arachnidwarriormicrobe"        : Return New ArachnidWarriorMicrobe(owner)
            Case "sporelauncher",
                 "sporelaunchermicrobe"          : Return New SporeLauncherMicrobe(owner)
            Case "convecmicrobe"                 : Return New ConVecMicrobe(owner)

            Case Else
                Return Nothing
        End Select
    End Function

End Class
