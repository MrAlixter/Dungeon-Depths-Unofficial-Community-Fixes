Public Class NameChange
    Inherits Item

    Public Const ITEM_NAME As String = "Name_Change"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 121
        tier = Nothing

        '|Item Flags|
        usable = True
        can_be_stolen = False
        rando_inv_allowed = False
        MyBase.onBuy = AddressOf teach

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("""Not happy with your current name?  Maybe you've evolved past who you were when it fit you?  I can give you a new name, no questions asked.""")
    End Sub

    Sub teach()
        count = 0
        Dim newName = InputBox("What do you want for a name?")
        If newName = "" Then newName = "???"
        Game.player1.name = newName
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
        TextEvent.push("You wake up to the teacher's snap.  ""Well then, " & Game.player1.name & ", it seems like we're done here."" she says with a knowing grin.  Done?  Right!  The name change.  She already did it?  But you've always been " & Game.player1.name & "..." & DDUtils.RNRN & "Stripping naked, you give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it...", AddressOf CType(Game.hteach, HypnoTeach).back)
    End Sub
End Class
