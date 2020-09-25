Public Class Accessory
    Inherits EquipmentItem

    'Accessories are equippable items that provide small passive buffs
    Public fInd As Tuple(Of Integer, Boolean, Boolean)
    Public mInd As Tuple(Of Integer, Boolean, Boolean)
    Public underClothes As Boolean

    Public Overrides Sub discard()
        If isCursed And owner.equippedAcce.getAName.Equals(getAName) Then
            Game.pushLblEvent("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub
End Class
