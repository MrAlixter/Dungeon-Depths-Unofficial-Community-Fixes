Public Class FoNight
    Inherits Armor

    Dim oldHat As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    'CatLingerie is a cosmetic armor that doesn't provide a defense bonus
    Sub New()
        MyBase.setName("Frock_of_Night")
        MyBase.setDesc("A black dress commonly worn by those who aren't afraid of the dark." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+3 DEF" & vbCrLf & _
                       "+20 MANA" & vbCrLf & _
                       "-3 SPD")
        id = 166
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 3
        MyBase.mBoost = 20
        MyBase.sBoost = -3
        MyBase.count = 0
        MyBase.value = 200

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(59, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(226, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(227, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(228, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(229, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(43, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(141, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(142, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(143, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(144, True, True)

        MyBase.compressesBreasts = True
        MyBase.isMonsterDrop = False
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        oldHat = p.prt.iArrInd(pInd.hat)

        p.prt.setIAInd(pInd.hat, 11, True, True)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.prt.iArrInd(pInd.hat) = oldHat
    End Sub
End Class
