Public Class BFormReset
    Inherits Item

    Sub New()
        MyBase.setName("Base_Form_Reset")
        MyBase.setDesc("""Not happy with your current base form?  I can cause you to forget it, and default you to how you are now.  Well, as long as you're in a stable form, that is...""")
        id = 131
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1000
        MyBase.onBuy = AddressOf teach
    End Sub

    Sub teach()
        count = 0
        Dim p = Game.player

        If Not Transformation.canBeTFed(p) Then
            Game.pushNPCDialog("Unfortunately, you seem to be in a rather unstable state.  I am afraid that I will not be able to set your base state at this time.")
            Game.player.gold += value
            Exit Sub
        End If

        p.pState.save(p)
        p.sState.save(p)
        CType(Game.hteach, HTeach).hypnotize("Have you seen my pendant?  I know it is a bit of a cliche, but doesn't seeing it swing back and forth just relax you so perfectly?  Back...and forth...watch it glisten in the light...feel yourself go deeper and deeper...deeper...and deeper...until you just...*SNAP*...drift away...", AddressOf wakeup)
    End Sub
    Sub wakeup()
        Game.player.UIupdate()
        Equipment.clothesChange("Naked")
        Game.player.createP()
        Game.pushLblEvent("You wake up to the teacher's snap.  ""Well then, " & Game.player.name & ", it seems like we're done here."" she says with a knowing grin.  Done?  Right!  The form reset.  She already did it?  But you've always looked like this..." & vbCrLf & vbCrLf & "Stripping naked, you give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it...", AddressOf CType(Game.hteach, HTeach).back)
    End Sub
End Class
