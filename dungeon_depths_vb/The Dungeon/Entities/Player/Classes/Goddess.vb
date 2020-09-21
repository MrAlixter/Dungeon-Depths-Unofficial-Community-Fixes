Public Class Goddess
    Inherits pClass
    Sub New()
        MyBase.New(7, 7, 7, 7, 7, 7, "Goddess")
        MyBase.revertPassage = "The golden aura leaves your body, and you once again join the world of the mortals."
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        p.maxHealth += 10
        p.maxMana += 5
        p.attack += 5
        p.defense += 5
        p.speed += 5
        p.will += 5
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        p.maxHealth -= 10
        p.maxMana -= 5
        p.attack -= 5
        p.defense -= 5
        p.speed -= 5
        p.will -= 5
    End Sub
End Class
