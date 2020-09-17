Public Class RingOfUvona
    Inherits Accessory
    'The heart necklace provides no bonuses
    Sub New()
        MyBase.setName("Ring_of_Uvona")
        MyBase.setDesc("While on the surface, this seems to be but an ornate ring crafted from " &
                     "extremely precious materials, closer inspection reveals that the inside " &
                     "of its band is inscribed with a blessing of the Uvona, Goddess of Fugue." & vbCrLf & _
                     "+7 Max mana, +13 WILL.")
        id = 123
        tier = Nothing
        MyBase.setUsable(False)

        MyBase.mBoost = 7
        MyBase.wBoost = 13

        MyBase.count = 0
        MyBase.value = 813
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        'MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)
        'MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
    End Sub
End Class
