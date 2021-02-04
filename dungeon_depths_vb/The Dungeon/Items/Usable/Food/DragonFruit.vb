Public Class DragonFruit
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("Dragonfruit​")
        id = 230
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False
        MyBase.isMonsterDrop = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 500
        setCalories(20)

        '|Description|
        MyBase.setDesc("A spikey magenta fruit that seems to glow with a crimson light." & DDUtils.RNRN &
                       "+20 Stamina" & vbCrLf &
                       "+40% Mana" & vbCrLf &
                       "+25 XP")
    End Sub

    Public Overrides Sub Effect()
        Dim p As Player = Game.player1

        Game.pushLogAndEvent("+" & CInt(Game.player1.getMaxMana * 0.4) & " Max Mana, +25 XP")
        Game.player1.xp += 25
        Game.player1.mana += CInt(Game.player1.getMaxMana * 0.4)

        If Int(Rnd() * 6) = 0 Or Game.noRNG Then
            BroodmotherTF.halfDragonTF(p)
            Game.pushLogAndEvent("As you bite into the fruit, your form changes!")
        End If
    End Sub
End Class
