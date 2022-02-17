Public Class PPanties
    Inherits Accessory

    Public Const ITEM_NAME As String = "Pink_Panties"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 180
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = False
        under_b_clothes = True
        rando_inv_allowed = True

        '|Stats|
        h_boost = 10
        m_boost = 10
        a_boost = 10
        d_boost = 10
        s_boost = 10
        w_boost = 10
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(14, False, True)

        '|Description|
        setDesc("A pink pair of panties that aren't a part of anything in the non-debug menu game.  Well, at least not yet..." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
