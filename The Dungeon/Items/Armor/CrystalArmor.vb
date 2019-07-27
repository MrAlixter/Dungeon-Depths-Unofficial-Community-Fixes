Public Class CrystalArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Crystalline_Armor")
        MyBase.setDesc("A set of armor made up of a series of diamond-like plates enhanced by concentrated mana.  While normally these would be extremely brittle, the magical energy lends them a fair amount of durability, and lends their wearer some extra mana." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+20 DEF" & vbCrLf & _
                       "+15 MANA")
        id = 144
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 20
        MyBase.mBoost = 15
        MyBase.count = 0
        MyBase.value = 2777

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(53, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(207, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(208, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(209, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(210, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        MyBase.onEquip()
        Game.player.mana += 15
    End Sub
    Public Overrides Sub onUnequip()
        MyBase.onEquip()
        Game.player.mana -= 15
        If Game.player.mana < 0 Then Game.player.mana = 0
    End Sub
End Class
