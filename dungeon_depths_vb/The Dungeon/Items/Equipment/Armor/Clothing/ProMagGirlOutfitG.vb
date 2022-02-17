Public Class ProMagGirlOutfitG
    Inherits Armor

    Public Const ITEM_NAME As String = "Pro_Mag._G._Outfit_(G)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 305
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False
        compress_breast = True

        '|Stats|
        d_boost = 30
        m_boost = 40
        w_boost = 20
        count = 0
        value = 100

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(404, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(405, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(406, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(407, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(408, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(388, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(389, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(390, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(391, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(392, True, True)

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
