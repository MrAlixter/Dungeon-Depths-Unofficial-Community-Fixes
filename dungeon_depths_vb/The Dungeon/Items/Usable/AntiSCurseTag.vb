Public Class AntiSCurseTag
    Inherits Item

    Sub New()
        MyBase.setName("Anti_Curse_Tag")
        MyBase.setDesc("A small paper tag with instructions to apply it to your clothing.")
        id = 153
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 777
    End Sub

    Overrides Sub use()
        Game.player.perks("slutcurse") = -1
        Equipment.antiClothingCurse()
        Game.pushLblEvent("You apply the anti-curse tag to your equipment.  All clothing/armor curses have been neutralized!")
        Game.player.createP()
        count -= 1
    End Sub
End Class
