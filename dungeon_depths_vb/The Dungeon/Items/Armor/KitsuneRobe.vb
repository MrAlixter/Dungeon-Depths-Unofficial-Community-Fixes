Public Class KitsuneRobe
    Inherits Armor

    Sub New()
        MyBase.setName("Kitsune's_Robes")
        MyBase.setDesc("A snazzy robe that identifies its wearer as the gurdian of a long forgotten shrine." & vbCrLf & _
                       "Fits sizes 1 through 4" & vbCrLf & _
                       "+10 Max Health, +5 DEF, +20 Max Mana")
        id = 183
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.hBoost = 10
        MyBase.dBoost = 5
        MyBase.mBoost = 20
        MyBase.count = 0
        MyBase.value = 7777

        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(253, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(254, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(255, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(256, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
