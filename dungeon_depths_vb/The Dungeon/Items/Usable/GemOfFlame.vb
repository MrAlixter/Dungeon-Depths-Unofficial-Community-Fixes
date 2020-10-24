Public Class GemOfFlame
    Inherits Item
    Sub New()
        MyBase.setName("Gem_of_Flame")
        MyBase.setDesc("A glittering deep crimson jewel that looks like it could be embeded into a wand")
        id = 214
        tier = Nothing
        isMonsterDrop = True
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 5030
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If p.inv.getCountAt("Magical_Girl_Wand") > 0 Then
            p.inv.add("Magical_Girl_Wand", -1)
            p.inv.add("Mag._Girl_Wand_(R)", 1)
            If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Then Equipment.weaponChange(p, "Mag._Girl_Wand_(R)")
            Game.pushLstLog("You apply the " & getName() & ".  Magical_Girl_Wand upgraded!")
        Else
            Game.pushLstLog("Without something to use it on, the gem is basically useless...")
        End If

        count -= 1
    End Sub
End Class
