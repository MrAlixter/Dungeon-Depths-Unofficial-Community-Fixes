Public Class LiveLingerie
    Inherits Armor
    Sub New()
        MyBase.setName("Living_Lingerie")
        MyBase.setDesc("A suit of living lingerie embued with a the soul of a mimic." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+2 DEF" & vbCrLf & _
                       "The mimic's movment rapidly raises lust" & vbCrLf & _
                       "May not be easy to remove")
        id = 56
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.value = 450
        MyBase.antiSlutVarInd = 55
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(16, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(266, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(82, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(84, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(86, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(88, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(44, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(45, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(145, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(146, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(147, True, True)

        MyBase.compressesBreasts = True
        MyBase.isCursed = True
        MyBase.isRandoTFAcceptable = False
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If Not p.perks(perk.livelinge) > -1 Then p.perks(perk.livelinge) = 0
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        If Not p.perks(perk.livelinge) > -1 Then p.perks(perk.livelinge) = -1
    End Sub
End Class
