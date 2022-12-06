Public Class BFormReset
    Inherits Item

    Public Const ITEM_NAME As String = "Base_Form_Reset"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 131
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf teach

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("""Not happy with your current base form?  I can cause you to forget it, and default you to how you are now.  Well, as long as you're in a stable form, that is...""")
    End Sub

    Sub teach()
        count = 0
        Dim p = Game.player1

        If Not Transformation.canBeTFed(p) Then
            Game.shopMenu.Close()
            TextEvent.pushNPCDialog("Unfortunately, you seem to be in a rather unstable state.  I am afraid that I will not be able to set your base state at this time.")
            Game.player1.gold += value
            Exit Sub
        End If

        p.pState.save(p)
        p.sState.save(p)

        Game.hideNPCButtons()
        CType(Game.hteach, HypnoTeach).hypnotize("Perfect!" & DDUtils.RNRN &
                                                 "Speaking of perfection, have you seen my pendant?  I know it may seem a bit clichéd, but does seeing it swing back and forth not just relax you so... perfectly?" & DDUtils.RNRN &
                                                 "Back... and forth... watch it glisten in the light..." & DDUtils.RNRN &
                                                 "Feel yourself go deeper and deeper... deeper... and deeper... until you just..." & DDUtils.RNRN &
                                                 "*SNAP*" & DDUtils.RNRN &
                                                 "...drift away...", AddressOf wakeup)
    End Sub
    Sub wakeup()
        Game.player1.UIupdate()
        EquipmentDialogBackend.armorChange(Game.player1, "Naked")
        Game.player1.drawPort()
        TextEvent.push("You wake up to the teacher's snap.  ""Well then, " & Game.player1.name & ", it seems like we're done here."" she says with a knowing grin.  Done?  Right!  The form reset.  She already did it?  But you've always looked like this..." & DDUtils.RNRN & "Stripping naked, you give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it...", AddressOf CType(Game.hteach, HypnoTeach).back)
    End Sub
End Class

