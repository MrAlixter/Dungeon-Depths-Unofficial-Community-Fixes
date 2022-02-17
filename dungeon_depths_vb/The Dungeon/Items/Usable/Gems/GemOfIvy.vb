Public Class GemOfIvy
    Inherits Item

    Public Const ITEM_NAME As String = "Gem_of_Ivy"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 306
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 5030

        '|Description|
        setDesc("A glittering verdant jewel that looks like it could be embeded into a wand.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If p.inv.getCountAt("Magical_Girl_Wand") > 0 Then
            p.inv.add("Magical_Girl_Wand", -1)
            p.inv.add("Mag._Girl_Wand_(G)", 1)
            If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Then  EquipmentDialogBackend.weaponChange(p, "Mag._Girl_Wand_(G)")
            TextEvent.pushLog("You apply the " & getName() & ".  Magical_Girl_Wand upgraded!")
        Else
            TextEvent.pushLog("Without something to use it on, the gem is basically useless...")
        End If

        count -= 1
    End Sub
End Class
