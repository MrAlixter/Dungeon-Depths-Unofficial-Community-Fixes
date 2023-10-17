Public Class MagSlutOutfit
    Inherits Armor

    Public Const ITEM_NAME As String = "Magical_Slut_Outfit"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 170
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False
        anti_slut_ind = 10
        is_sexy = True

        '|Stats|
        d_boost = 10
        count = 0
        value = 100

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(61, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(233, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(234, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(235, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(37, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(236, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(211, True, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(212, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(213, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(214, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(215, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(216, True, True)

        '|Description|
        setDesc("A mysterious uniform worn by a mysterious protector." & DDUtils.RNRN &
                "Magical girls can not remove this uniform." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
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
