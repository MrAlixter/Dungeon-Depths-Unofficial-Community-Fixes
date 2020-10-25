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
        MyBase.value = 150
        setCalories(15)

        '|Description|
        MyBase.setDesc("A spikey magenta fruit that seems to glow with a crimson light." & DDUtils.RNRN &
                       "+15 Stamina" & DDUtils.RNRN & "Dragoness Transformation")
    End Sub

    Public Overrides Sub Effect()
        Dim p As Player = Game.player1

        BroodmotherTF.halfDragonTF(p)

        Game.pushLblEvent("As you bite into the fruit, your form changes!")
    End Sub
End Class
