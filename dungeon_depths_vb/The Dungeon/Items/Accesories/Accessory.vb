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
    Public isCursed
    Overridable Sub onEquip()
    End Sub
    Overridable Sub onUnequip()
    End Sub
End Class
