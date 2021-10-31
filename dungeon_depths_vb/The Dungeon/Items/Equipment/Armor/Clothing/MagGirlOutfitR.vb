Public Class MagGirlOutfitR
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Mag._Girl_Outfit_(R)")
        id = 210
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False

        '|Stats|
        d_boost = 25
        m_boost = 17
        a_boost = 15
        count = 0
        value = 100

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(296, True, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(297, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(298, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(299, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(217, True, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(218, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(219, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(220, True, True)

        '|Description|
        setDesc("A mysterious uniform worn by a mysterious protector with a fair bit of experience." & DDUtils.RNRN &
                getSizeInformation() & vbCrLf &
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
