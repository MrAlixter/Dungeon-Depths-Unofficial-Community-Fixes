Public Class MajManaPotion
    Inherits Item

    Sub New()
        MyBase.setName("Major_Mana_Potion")
        MyBase.setDesc("A better, rarer mana potion.")
        id = 241
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1233
    End Sub

    Overrides Sub use(ByRef p As Player)
        Game.pushLstLog("You drink the " & getName())
        Dim phMana = p.mana

        Dim meffect As MajManaEffect = New MajManaEffect
        meffect.apply(p)

        Game.pushLblEvent("You drink the " & getName() & ".  +" & (p.mana - phMana) & " mana!")
        count -= 1
    End Sub
End Class
