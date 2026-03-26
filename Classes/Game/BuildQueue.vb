''' <summary>
''' Manages a player's build queue. Buildings and vehicles are constructed over multiple
''' marks based on their BuildPointsRequired. Each mark, workers contribute build points.
''' </summary>
Public Class BuildQueue

    Public Class BuildOrder
        Public ReadOnly ItemName As String
        Public ReadOnly BuildPointsRequired As Integer
        Public BuildPointsApplied As Integer = 0
        Public ReadOnly CommonMetalCost As Integer
        Public ReadOnly RareMetalCost As Integer

        ' Callback invoked when construction completes
        Public ReadOnly OnComplete As Action(Of BuildOrder)

        Public Sub New(ByVal name As String, ByVal bpRequired As Integer,
                       ByVal commonCost As Integer, ByVal rareCost As Integer,
                       ByVal onComplete As Action(Of BuildOrder))
            ItemName = name
            BuildPointsRequired = bpRequired
            CommonMetalCost = commonCost
            RareMetalCost = rareCost
            Me.OnComplete = onComplete
        End Sub

        Public ReadOnly Property PercentComplete() As Integer
            Get
                If BuildPointsRequired = 0 Then Return 100
                Return CInt((BuildPointsApplied / BuildPointsRequired) * 100)
            End Get
        End Property

        Public ReadOnly Property IsComplete() As Boolean
            Get
                Return BuildPointsApplied >= BuildPointsRequired
            End Get
        End Property
    End Class

    Private _queue As New Queue(Of BuildOrder)
    Private _owner As AbstractPlayer

    ''' <summary>Build points produced per mark per worker assigned to construction.</summary>
    Public Const BUILD_POINTS_PER_WORKER As Integer = 10

    Public Sub New(ByRef owner As AbstractPlayer)
        _owner = owner
    End Sub

    ''' <summary>Enqueue a new build order after deducting resources.</summary>
    Public Function Enqueue(ByVal order As BuildOrder) As Boolean
        If _owner.CommonOre < order.CommonMetalCost Then Return False
        If _owner.RareOre < order.RareMetalCost Then Return False
        _owner.SpendCommonOre(order.CommonMetalCost)
        _owner.SpendRareOre(order.RareMetalCost)
        _queue.Enqueue(order)
        Return True
    End Function

    ''' <summary>Advance the front-of-queue order by one mark's worth of build points.</summary>
    Public Sub Tick()
        If _queue.Count = 0 Then Return

        Dim current As BuildOrder = _queue.Peek()
        Dim bp As Integer = Math.Max(1, _owner.Workers * BUILD_POINTS_PER_WORKER)
        current.BuildPointsApplied += bp

        If current.IsComplete Then
            _queue.Dequeue()
            current.OnComplete(current)
        End If
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return _queue.Count
        End Get
    End Property

    Public ReadOnly Property CurrentOrder() As BuildOrder
        Get
            If _queue.Count = 0 Then Return Nothing
            Return _queue.Peek()
        End Get
    End Property

    ''' <summary>Cancel the current build order. Resources are NOT refunded.</summary>
    Public Sub CancelCurrent()
        If _queue.Count > 0 Then _queue.Dequeue()
    End Sub

    ''' <summary>Cancel all queued orders. Resources are NOT refunded.</summary>
    Public Sub CancelAll()
        _queue.Clear()
    End Sub

End Class
