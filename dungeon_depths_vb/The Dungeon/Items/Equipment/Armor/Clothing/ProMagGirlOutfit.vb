Public Class ProMagGirlOutfit
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Pro_Mag._Girl_Outfit")
        id = 201
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False
        compress_breast = True
        slut_var_ind = 10

        '|Stats|
        d_boost = 30
        s_boost = 20
        m_boost = 40
        count = 0
        value = 100

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(288, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(289, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(290, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(291, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(201, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(202, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(203, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(204, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(205, True, True)

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
