Public Class FantomaWand
    Inherits Wand

    Private Enum mode
        flowers
        disappear
        fireworks
    End Enum

    Private current_mode As mode = mode.flowers

    Public Const ITEM_NAME As String = "Fantoma's_Wand"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 366
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1

        '|Description|
        setDesc("A slender black wand, capped with a band of white.  It bristles with chaotic energy, and Fantoma promises that the last of its three-act show is sure to leave your foes in stitches.")
    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Select Case current_mode
            Case mode.flowers
                TextEvent.push("""For my first trick,"" you say, ""Flowers!""")
                TextEvent.pushAndLog("Flowers pop out of the tip of your wand!")

                current_mode = mode.disappear
            Case mode.disappear
                If Not m.getNPC() Is Nothing Then
                    m.getNPC.isStunned = True
                    m.getNPC.stunct = 0
                ElseIf Game.combat_engaged Then
                    Game.fromCombat()
                End If

                TextEvent.push("""For my next trick,"" you declare, ""I'll make myself disappear!""")
                TextEvent.pushAndLog("You vanish, stunning your foe for 1 turn!")

                current_mode = mode.fireworks
            Case Else
                Dim dmg As Integer = Math.Min(65 * (1 + (0.08 * Game.mDun.numCurrFloor)), DDUtils.INTLMT)
                Dim d51 = Int(Rnd() * 10)
                Dim d52 = Int(Rnd() * 10)

                'critical hit
                dmg = p.getSpellDamage(m, 2 * (dmg + d51 + d52))
                TextEvent.pushAndLog("""For my third and final trick,"" you exclaim, ""FIREWORKS!""")
                TextEvent.pushAndLog(CStr("Critical hit!  You zap the " & m.name & " for " & dmg & " damage!"))
                m.takeDMG(dmg, p)

                current_mode = mode.flowers
        End Select
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If Not Game.combat_engaged And Not current_mode = mode.flowers Then current_mode = mode.flowers

        Return MyBase.getABoost(p)
    End Function
End Class
