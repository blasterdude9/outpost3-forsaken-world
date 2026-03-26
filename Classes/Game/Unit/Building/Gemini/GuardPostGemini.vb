Imports IrrlichtNETCP
''' <summary>Gemini Guard Post. Fires microwave bursts — effective vs unarmored units.</summary>
Public Class GuardPostGemini
    Inherits Building

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 9
        _WorkersRequired = 1
        _BuildPointsRequired = 650
        _CommonMetalCost = 650
        _RareMetalCost = 80
        _TubeRequired = True
        _ResourceWeight = 700
        _HP = 160
        _MaxHP = 160
        _Armor = ArmorType.MEDIUM
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiGuardPost.3ds"
        End Get
    End Property
End Class
