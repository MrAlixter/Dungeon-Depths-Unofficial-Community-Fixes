Public Class AntiCurseTag
    Inherits Item

    Sub New()
        MyBase.setName("Anti_Curse_Tag")
        MyBase.setDesc("A small paper tag with instructions to apply it to your equipment." & vbCrLf & vbCrLf &
                       "Using this item will un-do the slut curse on your currently equipped armor." & vbCrLf & vbCrLf &
                       "To remove cursed (unremoveable) equipment, unequip it as usual while at least 1 Anti_Curse_Tag is present in your inventory.  Anti_Curse_Tags are consumed per each cursed equipment unequipped.")
        id = 153
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 777
    End Sub

    Overrides Sub use(ByRef p As Player)
        p.perks("slutcurse") = -1
        Equipment.antiClothingCurse(p)
        Game.pushLblEvent("You apply the anti-curse tag to your equipment.  The slut curse is neutralized!")
        p.drawPort()
        count -= 1
    End Sub
End Class
