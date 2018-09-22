Public Class Unconcious
    Inherits pClass
    Sub New()
        MyBase.New(Game.player.pClass.h, Game.player.pClass.a, Game.player.pClass.m, _
                   Game.player.pClass.d, Game.player.pClass.s, Game.player.pClass.w, "Unconscious")
        MyBase.revertPassage = ""
    End Sub
End Class
