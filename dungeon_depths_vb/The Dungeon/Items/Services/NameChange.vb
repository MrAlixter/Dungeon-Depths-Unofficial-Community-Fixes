Public Class NameChange
    Inherits Item

    Sub New()
        setName("Name_Change")
        setDesc("""Not happy with your current name?  Maybe you've evolved past who you were when it fit you?  I can give you a new name, no questions asked.""")
        id = 121
        tier = Nothing
        usable = true
        count = 0
        value = 1000
        MyBase.onBuy = AddressOf teach
        can_be_stolen = False
        rando_inv_allowed = False
    End Sub

    Sub teach()
        count = 0
        Dim newName = InputBox("What do you want for a name?")
        If newName = "" Then newName = "???"
        Game.player1.name = newName
        Game.hideNPCButtons()
        CType(Game.hteach, HypnoTeach).hypnotize("Have you seen my pendant?  I know it is a bit of a cliche, but doesn't seeing it swing back and forth just relax you so perfectly?  Back...and forth...watch it glisten in the light...feel yourself go deeper and deeper...deeper...and deeper...until you just...*SNAP*...drift away...", AddressOf wakeup)
    End Sub
    Sub wakeup()
        Game.player1.UIupdate()
        Equipment.clothesChange(Game.player1, "Naked")
        Game.player1.drawPort()
        Game.pushLblEvent("You wake up to the teacher's snap.  ""Well then, " & Game.player1.name & ", it seems like we're done here."" she says with a knowing grin.  Done?  Right!  The name change.  She already did it?  But you've always been " & Game.player1.name & "..." & DDUtils.RNRN & "Stripping naked, you give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it...", AddressOf CType(Game.hteach, HypnoTeach).back)
    End Sub
End Class
