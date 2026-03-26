Imports IrrlichtNETCP
''' <summary>
''' Microbe Blight Turret. Fires concentrated blight spores at enemies.
''' Infected units take ongoing damage and spread blight on their tile when destroyed.
''' Requires Blight Lab research.
''' </summary>
Public Class BlightTurretMicrobe
    Inherits Building

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 14
        _WorkersRequired = 1
        _ScientistsRequired = 1
        _BuildPointsRequired = 1000
        _CommonMetalCost = 800
        _RareMetalCost = 400
        _TubeRequired = True
        _ResourceWeight = 700
        _HP = 120
        _MaxHP = 120
        _Armor = ArmorType.LIGHT
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeBlightTurret.3ds"
        End Get
    End Property
End Class
