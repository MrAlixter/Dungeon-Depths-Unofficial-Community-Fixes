Public Class Armor
    Inherits Item
    'Armor is an Item subtype that provides a defencive boost, and has artworks for each breast size
    Public aBoost As Integer = 0
    Public dBoost As Integer = 0
    Public mBoost As Integer = 0
    Public sBoost As Integer = 0
    Public eBoost As Integer = 0
    Public bsizeneg1 As Tuple(Of Integer, Boolean)
    Public bsize0 As Tuple(Of Integer, Boolean)
    Public bsize1 As Tuple(Of Integer, Boolean)
    Public bsize2 As Tuple(Of Integer, Boolean)
    Public bsize3 As Tuple(Of Integer, Boolean)
    Public bsize4 As Tuple(Of Integer, Boolean)
    Public bsize5 As Tuple(Of Integer, Boolean)
    Public bsize6 As Tuple(Of Integer, Boolean)
    Public bsize7 As Tuple(Of Integer, Boolean)
    Overridable Sub onEquip()
    End Sub
    Overridable Sub onUnequip()
    End Sub
End Class
