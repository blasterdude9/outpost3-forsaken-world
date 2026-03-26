Public Class Player
    Inherits AbstractPlayer

    ''' <summary>
    ''' Creates a human player
    ''' </summary>
    ''' <param name="PlayerName">Name of the player as displayed to others</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal PlayerName As String)
        _Name = PlayerName
    End Sub

End Class
