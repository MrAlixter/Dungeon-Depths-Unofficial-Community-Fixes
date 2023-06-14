Public Class MagGirlOutfitG
    Inherits Armor

    Public Const ITEM_NAME As String = "Mag._Girl_Outfit_(G)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 304
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        show_underboob = True
        rando_inv_allowed = False
        hide_rearhair = True

        '|Stats|
        d_boost = 25
        m_boost = 17
        w_boost = 15
        count = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(91, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(400, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(401, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(402, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(403, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(87, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(384, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(385, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(386, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(387, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(20, True, True)
        cloak = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        cloakneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        cloak1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)

        '|Description|
        setDesc("A mysterious uniform worn by a mysterious protector with a fair bit of experience." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation() &
                "Magical girls can not remove this uniform.")
    End Sub

    Overrides Sub discard()
        If Game.player1.className.Equals("Magical Girl") Then
            TextEvent.pushLog("You can't just drop your uniform!")
            Exit Sub
        End If
        TextEvent.pushLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
