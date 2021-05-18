Public Class ManaPotion
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Mana_Potion")
        id = 13
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 633

        '|Description|
        setDesc("A normal, everyday mana potion.")

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
