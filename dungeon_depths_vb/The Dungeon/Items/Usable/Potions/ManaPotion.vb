Public Class ManaPotion
    Inherits Item

    Sub New()
        MyBase.setName("Mana_Potion")
        MyBase.setDesc("A normal, everyday mana potion.")
        id = 13
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
    End Sub

    Overrides Sub use()
        Game.pushLstLog("You drink the " & getName())
        Dim phMana = Game.player.mana

        Dim meffect As ManaEffect = New ManaEffect
        meffect.apply(Game.player)

        Game.pushLblEvent("You drink the " & getName() & ".  +" & (Game.player.mana - phMana) & " mana!")
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
