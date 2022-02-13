Public Class MagGirlOutfit
    Inherits Armor

    Public Const ITEM_NAME = "Magical_Girl_Outfit"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 10
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False
        anti_slut_ind = 201
        slut_var_ind = 170

        '|Stats|
        d_boost = 10
        count = 0
        value = 100

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(60, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(230, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(231, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(232, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(32, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(33, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(100, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(101, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(102, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(103, True, True)

        '|Description|
        setDesc("A mysterious uniform worn by a mysterious protector." & DDUtils.RNRN &
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
