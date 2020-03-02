Public Class RingOfUvona
    Inherits Accessory
    'The heart necklace provides no bonuses
    Sub New()
        MyBase.setName("Ring_of_Uvona")
        MyBase.setDesc("While on the surface, this seems to be but an ornate ring crafted from " &
                     "extremely precious materials, closer inspection reveals that the inside " &
                     "of its band is inscribed with a blessing of the Uvona, Goddess of Fugue." & vbCrLf & _
                     "+7 Max mana, +13 WIL.")
        id = 123
        tier = Nothing
        MyBase.setUsable(False)

        MyBase.mBoost = 7
        MyBase.wBoost = 13

        MyBase.count = 0
        MyBase.value = 813
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
