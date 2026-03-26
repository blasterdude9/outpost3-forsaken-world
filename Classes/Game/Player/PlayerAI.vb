Public MustInherit Class PlayerAI
    Inherits AbstractPlayer

    ''' <summary>
    ''' Create a new AI player, which utilizes AIFunction() to run the AI's routine
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' This function is what gets triggered each mark to execute the AI's procedure
    ''' and control it's actions. Try not to allow this to get too hefty.
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub RunAI()

End Class
