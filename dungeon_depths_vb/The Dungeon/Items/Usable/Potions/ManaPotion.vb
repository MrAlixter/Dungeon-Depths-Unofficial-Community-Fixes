Public Class ManaPotion
    Inherits Item

    Sub New()
        MyBase.setName("Mana_Potion")
        MyBase.setDesc("A normal, everyday mana potion.")
        id = 13
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 633
    End Sub

    Overrides Sub use(ByRef p As Player)
        Game.pushLstLog("You drink the " & getName())
        Dim phMana = p.mana

        Dim meffect As ManaEffect = New ManaEffect
        meffect.apply(p)

        Game.pushLblEvent("You drink the " & getName() & ".  +" & (p.mana - phMana) & " mana!")
        count -= 1
    End Sub
End Class
