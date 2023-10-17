Public Class CyberValkyrieArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Mecha_Valkyrie_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 398
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False
        show_underboob = True
        is_sexy = True

        '|Stats|
        d_boost = 25
        m_boost = 12
        count = 0
        value = 2400

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(107, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(108, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(490, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(491, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(492, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(101, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(475, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(476, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(477, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(478, True, True)

        '|Description|
        setDesc("An ethereal armor set built for a partially mechanical defender." & DDUtils.RNRN &
                "Hardlight Effect" & DDUtils.RNRN &
                "Mecha Valkyries can not remove this armor." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Overrides Sub discard()
        If Game.player1.className.Equals("Mecha Valkyrie") Then
            TextEvent.pushLog("Your armor magically reappears!")
            Exit Sub
        End If

        TextEvent.pushLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
