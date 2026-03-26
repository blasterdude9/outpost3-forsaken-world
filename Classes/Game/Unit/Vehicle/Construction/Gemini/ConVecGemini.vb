Imports IrrlichtNETCP
Public Class ConVecGemini
    Inherits Vehicle
    Private _loadedKit As String = ""
    Public Sub New(ByRef owner As Player)
        _Chassis = "GeminiConVec" : _Speed = 1.6F : _HP = 95 : _MaxHP = 95
        _Armor = ArmorType.LIGHT : _Name = "ConVec (Gemini)" : _Player = owner
    End Sub
    Public Sub LoadKit(ByVal buildingType As String) : _loadedKit = buildingType : End Sub
    Public Function DeployKit() As String
        Dim k = _loadedKit : _loadedKit = "" : Return k
    End Function
    Public ReadOnly Property HasKit() As Boolean
        Get : Return _loadedKit <> "" : End Get
    End Property
    Public Overrides ReadOnly Property MeshFilename() As String
        Get : Return "GeminiConVec.3ds" : End Get
    End Property
End Class
