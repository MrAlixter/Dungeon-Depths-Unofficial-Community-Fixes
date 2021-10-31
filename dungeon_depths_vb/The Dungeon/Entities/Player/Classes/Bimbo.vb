Public Class Bimbo
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 0.5, 0.5, 0.75, 1, 0.5, "Bimbo")
        MyBase.revertPassage = "Your mind feels slightly more useful, and you pout sligthly as your tits and ass decrease in size.  While you are sad to see them go, you have become smart enough to realize that it is probably for the best."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If Not learnSkills Then Exit Sub

        p.nextLevelXp = p.nextLevelXp / 2
        If level = 3 And Not p.knownSpecials.Contains("Charm") Then p.knownSpecials.Add("Charm") : TextEvent.pushLog("Charm special learned!")
        If level = 4 Then p.perks(perk.slutcurse) = 1
        If level = 4 And Not p.knownSpells.Contains("Flames of Amaraphne") Then p.knownSpells.Add("Flames of Amaraphne") : TextEvent.pushLog("Flames of Amaraphne learned!")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If p.breastSize > 0 Then p.bs()
    End Sub
End Class
