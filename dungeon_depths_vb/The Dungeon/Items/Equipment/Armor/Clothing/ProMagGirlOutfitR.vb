Public Class ProMagGirlOutfitR
    Inherits Armor

    Public Const ITEM_NAME As String = "Pro_Mag._G._Outfit_(R)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 211
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False
        compress_breast = True

        '|Stats|
        d_boost = 30
        m_boost = 40
        a_boost = 20
        count = 0
        value = 100

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(300, True, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(301, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(302, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(303, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(221, True, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(222, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(223, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(224, True, True)

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
