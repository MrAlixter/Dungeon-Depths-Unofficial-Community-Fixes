Public Class CatArmor
    Inherits Armor

    Dim oldHat As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    'CatLingerie is a cosmetic armor that doesn't provide a defense bonus
    Sub New()
        MyBase.setName("Cat_Armor")

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

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(26, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(73, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(74, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(75, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(76, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(77, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(78, True, True)

        MyBase.slutVarInd = 12
        MyBase.compressesBreasts = True

        MyBase.setDesc("An adorable cat themed set of lightweight armor that also boosts attack. Nya." & DDUtils.RNRN &
                                      getSizeInformation() & vbCrLf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        oldHat = p.prt.iArrInd(pInd.hat)

        p.prt.setIAInd(pInd.hat, 9, True, True)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.prt.iArrInd(pInd.hat) = oldHat
    End Sub
End Class
