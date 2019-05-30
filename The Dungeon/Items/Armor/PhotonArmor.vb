
Public Class PhotonArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Photon_Armor")
        MyBase.setDesc("This armor consists of lightweight though fragile black plates of an advanced plastic, alongside a powerful shield generator that harnesses its users mana to withstand impacts." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+12 Max mana, +10 DEF, Hardlight Effect")
        id = 104
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 12
        MyBase.dBoost = 10
        MyBase.count = 0
        MyBase.value = 4331
        MyBase.slutVarInd = 105
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(42, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(145, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(146, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(147, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Public Overrides Sub onEquip()
        MyBase.onEquip()
        Game.player.perks("hardlight") = 1
    End Sub
End Class
