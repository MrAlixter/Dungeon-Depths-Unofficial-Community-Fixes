Public Class Slime
    Inherits pForm
    Sub New()
        MyBase.New(0.4, 1, 1, 2.5, 0.75, 0.75, "Slime", True)

        revertPassage = "Your body firms up, leaving you less jiggly than you were a few moments ago..."
        transformPassage = "Your body collapses into a puddle of viscous gel, which you raise up into a roughly human-looking form."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        p.maxHealth += 12

        If Not learnSkills Then Exit Sub

        If level = 3 Then p.learnSpecial("Absorption II")
        If level = 4 Then
            p.perks(perk.slimeregenplus) = 1
            TextEvent.pushLog("Your passive regeneration has improved!")
        End If
        If level = 5 Then p.learnSpell("Tendrill")
    End Sub

    Public Overrides Sub deLVL(toLevel As Integer, ByRef p As Player)
        p.maxHealth -= 12

        If toLevel < 4 And p.perks(perk.slimeregenplus) > -1 Then
            p.perks(perk.slimeregenplus) = -1
            TextEvent.pushLog("Your passive regeneration has decreased...")
        End If
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()

        Game.player1.perks(perk.slimehair) = -1
        Game.player1.perks(perk.slimeregenplus) = -1

        'HumanTF.change(Game.player1, False)
    End Sub
End Class
