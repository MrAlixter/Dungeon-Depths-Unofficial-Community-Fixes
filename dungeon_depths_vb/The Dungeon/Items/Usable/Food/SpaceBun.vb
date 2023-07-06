'Credit: [request to remain uncredited]

Public Class SpaceBun
    Inherits Food

    Public Const ITEM_NAME As String = "Space_Bun"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 392
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 450
        setCalories(50)

        '|Description|
        setDesc("A strange pink pastry in a clear plastic wrapper.  A small label warns against 𝓃𝑜𝓉 eating too many of them too fast." & DDUtils.RNRN &
                "... It does seem as though someone has edited the disclaimer, though." & DDUtils.RNRN &
                "+50 Stamina")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If p.perks(perk.spacebun) > 0 Or Settings.active(setting.norng) Then
            p.ongoingTFs.add(New SpaceBunTF())
            p.update()
            p.perks(perk.spacebun) = -1
        ElseIf p.perks(perk.spacebun) = -1 Then
            p.perks(perk.spacebun) = 0
        Else
            p.perks(perk.spacebun) += 1
        End If
    End Sub
End Class
