Public Class MajManaPotion
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Major_Mana_Potion")
        id = 241
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1233

        '|Description|
        setDesc("A better, rarer mana potion.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        TextEvent.pushLog("You drink the " & getName())
        Dim phMana = p.mana

        Dim meffect As MajManaEffect = New MajManaEffect
        meffect.apply(p)

        TextEvent.push("You drink the " & getName() & ".  +" & (p.mana - phMana) & " mana!")
        count -= 1
    End Sub
End Class
