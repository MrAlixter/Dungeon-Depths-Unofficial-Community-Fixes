Public Class RingOfUvona
    Inherits Accessory
    'The heart necklace provides no bonuses
    Sub New()
        '|ID Info|
        setName("Ring_of_Uvona")
        id = 123
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 7
        w_boost = 13
        count = 0
        value = 813

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        'MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)
        'MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)

        '|Description|
        setDesc("While on the surface, this seems to be but an ornate ring crafted from extremely precious materials, closer inspection reveals that the inside of its band is inscribed with a blessing of the Uvona, Goddess of Fugue." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
