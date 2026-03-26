Imports IrrlichtNETCP

''' <summary>
''' Microbe Residence — organic hive-like structure. Highest capacity of all factions.
''' </summary>
Public Class ResidenceMicrobe
    Inherits Building
    Public Const MAX_CAPACITY As Integer = 20

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 6
        _WorkersRequired = 0
        _BuildPointsRequired = 1000
        _TubeRequired = True
        _CommonMetalCost = 400
        _RareMetalCost = 200
        _ResourceWeight = 10
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get : Return "MicrobeResidence.3ds" : End Get
    End Property
End Class
