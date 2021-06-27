Public Class PApple
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Apple​")
        id = 31
        tier = 3

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 150
        setCalories(15)

        '|Description|
        setDesc("An normal green apple." & DDUtils.RNRN &
                "+15 Stamina")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If Game.combatmode = True Or Game.npcmode = True Or Not p.canMoveFlag Then
            PrincessTF.step3()
        Else
            PrincessTF.step1()
        End If
    End Sub
End Class
