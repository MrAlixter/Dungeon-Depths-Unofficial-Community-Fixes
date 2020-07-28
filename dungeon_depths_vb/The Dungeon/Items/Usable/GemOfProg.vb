Public Class GemOfProg
    Inherits Item
    Sub New()
        MyBase.setName("Gem_of_Progress")
        MyBase.setDesc("A glittering azure jewel that looks like it could be embeded into a wand")
        id = 206
        tier = Nothing
        isMonsterDrop = True
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 4500
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If p.inv.getCountAt("Magical_Girl_Wand") > 0 Then
            p.inv.add("Magical_Girl_Wand", -1)
            p.inv.add("Pro_Mag._Girl_Wand", 1)
            If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Then Equipment.weaponChange("Pro_Mag._Girl_Wand")
            Game.pushLstLog("You apply the " & getName() & ".  Magical_Girl_Wand upgraded!")
        Else
            Game.pushLstLog("Without something to use it on, the gem is basically useless...")
        End If

        count -= 1
    End Sub
End Class
