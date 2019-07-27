Public Class Armor
    Inherits Item
    'Armor is an Item subtype that provides a defencive boost, and has artworks for each breast size
    Public aBoost As Integer = 0
    Public dBoost As Integer = 0
    Public hBoost As Integer = 0
    Public mBoost As Integer = 0
    Public sBoost As Integer = 0
    Public wboost As Integer = 0
    Public slutVarInd As Integer = -1
    Public antiSlutVarInd As Integer = -1
    Public bsizeneg1 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize0 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize1 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize2 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize3 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize4 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize5 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize6 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize7 As Tuple(Of Integer, Boolean, Boolean)
    Public compressesBreasts As Boolean
    Overridable Sub onEquip()
    End Sub
    Overridable Sub onUnequip()
    End Sub
    Public Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
