Public Class NatureKiss
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Nature's_Kiss")
        id = 269
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 2300
        setCalories(39)

        '|Description|
        setDesc("An amazing salad made of mixed greens grown by followers of a forest goddess.  While it may both be delectable and healthy, the Vendor describes these followers as more of a ""cult"" so the salad may be similarly unstable." & vbCrLf &
                       "+39 stamina" & vbCrLf &
                       "Either +150 health or +75 mana (depending on which is lower)")
    End Sub
    Public Overrides Sub effect(ByRef p As Player)
        If ((p.getIntHealth / p.getMaxHealth) < (p.getMana / p.getMaxMana)) Or ((p.getIntHealth / p.getMaxHealth) < (p.getMana / p.getMaxMana) And Int(Rnd() * 2) = 0) Then
            p.health += 125 / p.getMaxHealth
            TextEvent.pushLog("+150 health!")
        Else
            p.mana += 75
            TextEvent.pushLog("+75 mana!")
        End If

        If Int(Rnd() * 3) = 0 Or Game.noRNG Then
            Dim tf = New AlrauneTF()
            tf.fullTF()
        End If

        p.update()
    End Sub
End Class
