Public Class NameChange
    Inherits Item

    Sub New()
        MyBase.setName("Name_Change")
        MyBase.setDesc("""Not happy with your current name?  Maybe you've evolved past who you were when it fit you?  I can give you a new name, no questions asked.""")
        id = 121
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1000
        MyBase.onBuy = AddressOf teach

        MyBase.isRandoTFAcceptable = False
    End Sub

    Sub teach()
        count = 0
        Dim newName = InputBox("What do you want for a name?")
        If newName = "" Then newName = "???"
        Game.player.name = newName
        Game.hideNPCButtons()
        CType(Game.hteach, HTeach).hypnotize("Have you seen my pendant?  I know it is a bit of a cliche, but doesn't seeing it swing back and forth just relax you so perfectly?  Back...and forth...watch it glisten in the light...feel yourself go deeper and deeper...deeper...and deeper...until you just...*SNAP*...drift away...", AddressOf wakeup)
    End Sub
    Sub wakeup()
        Game.player.UIupdate()
        Equipment.clothesChange("Naked")
        Game.player.drawPort()
        Game.pushLblEvent("You wake up to the teacher's snap.  ""Well then, " & Game.player.name & ", it seems like we're done here."" she says with a knowing grin.  Done?  Right!  The name change.  She already did it?  But you've always been " & Game.player.name & "..." & vbCrLf & vbCrLf & "Stripping naked, you give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it...", AddressOf CType(Game.hteach, HTeach).back)
    End Sub
End Class
