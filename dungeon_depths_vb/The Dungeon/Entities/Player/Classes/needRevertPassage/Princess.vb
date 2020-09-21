Public Class Princess
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 0.5, 3, 0.75, 0.75, 0.75, "Princess")
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        p.maxMana += 6
        p.mana += 6
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        p.maxMana -= 6
        p.mana -= 6
    End Sub
End Class
