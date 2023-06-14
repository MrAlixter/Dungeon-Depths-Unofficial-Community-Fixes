Public Class DitzDazeWand
    Inherits Wand

    Public Const ITEM_NAME As String = "Wand_of_Ditz_and_Daze"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 369
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 4888
        w_boost = -20

        '|Description|
        setDesc("A slender pink wand that bristles with glittery energy." & DDUtils.RNRN &
                "Stuns all in an area for 4 turns." & DDUtils.RNRN &
                "Teaches its bearer the spell ""Flash Bolt"" if it is not already known." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.learnSpell("Flash Bolt")
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        If Not p.className.Equals("Mage") Then
            p.forgetSpell("Flash Bolt")
        End If
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        If Not m.getNPC() Is Nothing Then
            m.getNPC.isStunned = True
            m.getNPC.stunct = 3
        ElseIf Game.combat_engaged Then
            Game.fromCombat()
        End If

        p.perks(perk.mesmerized) = 4

        TextEvent.pushAndLog("You zap the area, stunning your foe for 4 turns!  You are mesmerized for 4 turns.")
    End Sub
End Class
