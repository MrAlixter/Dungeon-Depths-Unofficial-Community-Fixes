Public Class PApple
    Inherits Food

    Sub New()
        MyBase.setName("Apple​")
        MyBase.setDesc("An normal green apple. -15 Hunger")
        id = 32
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
        setCalories(15)
    End Sub

    Public Overrides Sub Effect()
        Dim p As Player = Game.player
        If Game.combatmode = True Or Game.npcmode = True Or Not p.canMoveFlag Then
            p.ongoingTFs.Add(New PrincessTF(False))
        Else
            p.ongoingTFs.Add(New PrincessTF())
        End If
        p.update()
    End Sub
End Class
