Public Class ScarletComb
    Inherits Item

    Public Const ITEM_NAME As String = "Scarlet_Comb"

    Dim plyr As Player = Nothing

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 451
        tier = 3

        '|Item Flags|
        usable = True
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 836

        '|Description|
        setDesc("A small, red comb." & DDUtils.RNRN &
                "This item can be used to change your hairstyle.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Game.combat_engaged Or Game.shop_npc_engaged Or Game.lblEvent.Visible Or Game.pnlEvent.Visible Or Game.pnlDescription.Visible Or Game.pnlEquip.Visible Then
            TextEvent.pushLog("You cannot use the comb now...")
            Exit Sub
        End If

        MyBase.use(p)
        count -= 1
        restyle()
        plyr = p
    End Sub

    Sub restyle()
        Dim gen = New RestyleCharacterGenerator
        gen.hideNonHairOptions()
        gen.ShowDialog()

        gen.Dispose()

        Dim p = If(plyr Is Nothing, Game.player1, plyr)
        p.drawPort()
    End Sub
End Class
