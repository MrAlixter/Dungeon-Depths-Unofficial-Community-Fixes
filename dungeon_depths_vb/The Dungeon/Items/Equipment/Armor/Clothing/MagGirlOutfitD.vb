Public Class MagGirlOutfitD
    Inherits Armor

    Public Const ITEM_NAME As String = "Mag._Girl_Outfit_(D)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 208
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False

        '|Stats|
        h_boost = 13
        d_boost = 13
        m_boost = 26
        a_boost = 13
        s_boost = 13
        w_boost = 13
        count = 0

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(284, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(285, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(286, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(287, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(196, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(197, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(198, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(199, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(200, True, True)

        '|Description|
        setDesc("A mysterious uniform worn by a mysterious ""protector"" that has embraced the dark side." & DDUtils.RNRN &
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
