Public Class Princess
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 0.5, 3, 0.75, 0.75, 0.75, "Princess")
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        p.maxMana += 6
        p.mana += 6

        If Not learnSkills Then Exit Sub

    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        p.maxMana -= 6
        p.mana -= 6
    End Sub
End Class
