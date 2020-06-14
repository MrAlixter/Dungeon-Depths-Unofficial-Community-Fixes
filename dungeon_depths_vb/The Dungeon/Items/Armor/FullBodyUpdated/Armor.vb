Public Class Armor
    Inherits Item
    'Armor is an Item subtype that provides a defencive boost, and has artworks for each breast size
    Public aBoost As Integer = 0
    Public dBoost As Integer = 0
    Public hBoost As Integer = 0
    Public mBoost As Integer = 0
    Public sBoost As Integer = 0
    Public wboost As Integer = 0
    Protected slutVarInd As Integer = -1
    Protected antiSlutVarInd As Integer = -1
    Public bsizeneg1 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize0 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize1 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize2 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize3 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize4 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize5 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize6 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize7 As Tuple(Of Integer, Boolean, Boolean)

    Public usizeneg1 As Tuple(Of Integer, Boolean, Boolean)
    Public usize0 As Tuple(Of Integer, Boolean, Boolean)
    Public usize1 As Tuple(Of Integer, Boolean, Boolean)
    Public usize2 As Tuple(Of Integer, Boolean, Boolean)
    Public usize3 As Tuple(Of Integer, Boolean, Boolean)
    Public usize4 As Tuple(Of Integer, Boolean, Boolean)
    Public usize5 As Tuple(Of Integer, Boolean, Boolean)

    Public compressesBreasts As Boolean
    Public hidesDick As Boolean = False
    Public isCursed As Boolean = False
    Public bindsWearer As Boolean = False

    Protected wearer As Player
    Overridable Function getSlutVarInd()
        Return slutVarInd
    End Function
    Overridable Function getAntiSlutVarInd()
        Return antiSlutVarInd
    End Function

    Overridable Sub onEquip(ByRef p As Player)
        wearer = p
    End Sub
    Overridable Sub onUnequip(ByRef p As Player)
        wearer = Nothing
    End Sub

    Public Overrides Sub discard()
        If Game.player1.equippedArmor.getAName.Equals(getAName) Then
            Game.pushLblEvent("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub
End Class
