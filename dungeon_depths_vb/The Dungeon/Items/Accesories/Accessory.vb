Public Class Accessory
    Inherits Item
    'Accessories are equippable items that provide small passive buffs
    Public aBoost As Integer = 0
    Public dBoost As Integer = 0
    Public hBoost As Integer = 0
    Public mBoost As Integer = 0
    Public sBoost As Integer = 0
    Public wBoost As Integer = 0
    Public fInd As Tuple(Of Integer, Boolean, Boolean)
    Public mInd As Tuple(Of Integer, Boolean, Boolean)
    Public isCursed, underClothes As Boolean
    Overridable Sub onEquip(ByRef p As Player)
    End Sub
    Overridable Sub onUnequip(ByRef p As Player)
    End Sub

    Public Overrides Sub discard()
        If isCursed And Game.player1.equippedAcce.getAName.Equals(getAName) Then
            Game.pushLblEvent("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub
End Class
