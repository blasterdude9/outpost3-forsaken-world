Public NotInheritable Class DamageVector
    Protected _Concussion
    Protected _Penetration

    ''' <summary>
    ''' Creates a new Damage Vector
    ''' </summary>
    ''' <param name="Concussion">Amount of Concussion Damage</param>
    ''' <param name="Penetration"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Concussion As Integer, ByVal Penetration As Integer)
        _Concussion = Concussion
        _Penetration = Penetration
    End Sub

    Public ReadOnly Property Concussion() As Integer
        Get
            Return _Concussion
        End Get
    End Property

    Public ReadOnly Property Penetration() As Integer
        Get
            Return _Penetration
        End Get
    End Property
End Class
