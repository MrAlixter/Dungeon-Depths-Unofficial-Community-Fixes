Public Class MagGirlOutfitC
    Inherits Armor

    Public Const ITEM_NAME As String = "Mag._Girl_Outfit_(C)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 216
        tier = Nothing

        '|Item Flags|
        usable = False
        show_underboob = True
        compress_breast = True
        rando_inv_allowed = False

        '|Stats|
        d_boost = 5
        m_boost = 25
        h_boost = 50
        count = 0

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(304, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(305, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(306, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(307, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(308, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(309, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(225, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(226, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(227, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(228, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(229, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(28, True, True)

        '|Description|
        setDesc("A mysterious uniform worn by a mysterious protector with a bovine flair." & DDUtils.RNRN &
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
