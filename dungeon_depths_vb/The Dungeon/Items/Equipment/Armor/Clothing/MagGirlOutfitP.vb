Public Class MagGirlOutfitP
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Mag._Girl_Outfit_(P)")
        id = 202
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False

        '|Stats|
        d_boost = 17
        m_boost = 25
        h_boost = 35
        count = 0
        value = 100

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(292, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(293, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(294, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(295, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(206, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(207, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(208, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(209, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(210, True, True)

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
