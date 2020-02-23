Public Class CatArmor
    Inherits Armor

    Dim oldHat As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    'CatLingerie is a cosmetic armor that doesn't provide a defence bonus
    Sub New()
        MyBase.setName("Cat_Armor")
        MyBase.setDesc("An adorable cat themed set of lightweight armor that also boosts attack. Nya." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+7 DEF" & vbCrLf & _
                       "+7 ATK" & vbCrLf & _
                       "+33 SPD")
        id = 146
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 7
        MyBase.aBoost = 7
        MyBase.sBoost = 33
        MyBase.count = 0
        MyBase.value = 2456

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(54, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(211, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(212, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(213, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(214, True, True)

        MyBase.slutVarInd = 12
        MyBase.compressesBreasts = True
    End Sub

    Public Overrides Sub onEquip()
        oldHat = Game.player.prt.iArrInd(pInd.hat)

        Game.player.prt.setIAInd(pInd.hat, 9, True, True)
    End Sub

    Public Overrides Sub onUnequip()
        Game.player.prt.iArrInd(pInd.hat) = oldHat
    End Sub
End Class
