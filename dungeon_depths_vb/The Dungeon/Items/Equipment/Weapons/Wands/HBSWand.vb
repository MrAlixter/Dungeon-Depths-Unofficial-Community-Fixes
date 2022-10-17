Public Class HBSWand
    Inherits Wand

    Public Const ITEM_NAME As String = "Wand_of_Heart_and_Star"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 367
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 10000
        w_boost = 10

        '|Description|
        setDesc("A slender golden wand, tipped with a small five-pointed star.  Shining runes twist along its length, pulsing with a patient rhythm." & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = 55
        Dim d51 = Int(Rnd() * 4)
        Dim d52 = Int(Rnd() * 4)

        If d51 = d52 And d52 = 2 Then
            'critical hit
            dmg = p.getSpellDamage(m, 2 * (dmg + d51 + d52))
            TextEvent.pushAndLog(CStr("Critical hit!  You zap the " & m.name & " for " & dmg & " damage!"))
            m.takeDMG(dmg, p)
        Else
            'non critical hit
            dmg = p.getSpellDamage(m, dmg + d51 + d52)
            TextEvent.pushAndLog(CStr("You zap the " & m.name & " for " & dmg & " damage!"))
            m.takeDMG(dmg, p)
        End If
    End Sub
End Class
