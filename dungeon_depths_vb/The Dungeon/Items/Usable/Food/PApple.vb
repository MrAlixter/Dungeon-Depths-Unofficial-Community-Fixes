Public Class PApple
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("Apple​")
        id = 31
        tier = 3

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 150
        setCalories(15)

        '|Description|
        MyBase.setDesc("An normal green apple." & DDUtils.RNRN & "+15 Stamina")
    End Sub

    Public Overrides Sub Effect()
        Dim p As Player = Game.player1
        If Game.combatmode = True Or Game.npcmode = True Or Not p.canMoveFlag Then
            p.ongoingTFs.Add(New PrincessTF(False))
        Else
            p.ongoingTFs.Add(New PrincessTF())
        End If
        p.update()
    End Sub
End Class
