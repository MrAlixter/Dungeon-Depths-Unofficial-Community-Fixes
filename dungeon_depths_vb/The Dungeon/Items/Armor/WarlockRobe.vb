Public Class WarlockRobe
    Inherits Armor

    Sub New()
        MyBase.setName("Warlock's_Robes")
        MyBase.setDesc("A snazzy robe that identifies its wearer as a high ranking follower of Uvona, Goddess of Fugue.  The goddess's power is woven into its very fabric, amplifying its wearer's own magic ability." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+5 Max Health, +10 DEF, +15 Max Mana")
        id = 115
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.hBoost = 5
        MyBase.dBoost = 20
        MyBase.mBoost = 15
        MyBase.count = 0
        MyBase.value = 1840

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(48, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(167, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(168, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(169, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(170, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
