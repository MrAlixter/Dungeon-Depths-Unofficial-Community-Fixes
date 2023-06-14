Public Class HealFeelWand
    Inherits Wand

    Public Const ITEM_NAME As String = "Wand_of_Heal_and_Feel"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 368
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 4888

        '|Description|
        setDesc("A slender crimson wand that bristles with restorative energy." & DDUtils.RNRN &
                "Heals the user by 75 HP, raised the user's lust by 1/3 of the healed health." & DDUtils.RNRN &
                "Teaches its bearer the spell ""Flames of Amaraphne"" if it is not already known.")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.learnSpell("Flames of Amaraphne")
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        If Not p.className.Contains("Bimbo") Then
            p.forgetSpell("Flames of Amaraphne")
        End If
    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim hlth = Math.Min(75, p.getMaxHealth - p.getIntHealth)
        Dim lust = Math.Min(CInt(hlth / 3), 100 - p.getLust())

        p.health += hlth / p.getMaxHealth
        p.addLust(lust)

        TextEvent.pushAndLog(CStr("You zap yourself, healing " & hlth & " damage and increasing your lust by " & lust & "!"))
    End Sub
End Class
