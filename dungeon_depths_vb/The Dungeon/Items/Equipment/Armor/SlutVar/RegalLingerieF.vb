Public Class RegalLingerieF
    Inherits Armor

    Public Const ITEM_NAME As String = "Regal_Lingerie_(Fae)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 333
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        compress_breast = True
        show_underboob = False
        anti_slut_ind = 335

        '|Stats|
        m_boost = 5
        d_boost = 5
        s_boost = 5
        w_boost = -20
        count = 0
        value = 768

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(95, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(432, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(433, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(434, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(435, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(436, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(92, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(421, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(422, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(423, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(424, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(425, True, True)

        '|Description|
        setDesc("The frilly undergarments of someone who sees themself as a princess.  Well, either that, or someone who a fairy thought could use a little more elegance in their life..." & DDUtils.RNRN &
                "Requires 15 mana to remove" & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.mana -= 15

        Game.progressTurn()
        TextEvent.pushAndLog("You focus and are able to break through the enchantment on your gear!  -15 Mana...")

        p.inv.add(ITEM_NAME, -1)
    End Sub

    Public Overrides Function getCursed(ByRef p As Player) As Boolean
        If p.getMana < 15 Then Return True Else Return False
    End Function
End Class
