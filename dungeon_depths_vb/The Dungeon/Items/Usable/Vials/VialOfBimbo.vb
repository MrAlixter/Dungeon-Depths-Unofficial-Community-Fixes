Public Class VialOfBimbo
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Vial_of_BIM_II")
        id = 127
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 1230

        '|Description|
        setDesc("A glittery, glowing pink potion contained in a clear, scientific looking glass tube.  A small label on the vial states that it contains ""200ml of BIM_II,"" a ""Potentially dangerous arcanomutant,"" whatever that means...")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        TextEvent.push("Drinking the pink contents of the vial causes a dizzy calm wash to over you.")
        p.ongoingTFs.Add(New BimboPlusTF(2, 5, 0.25, True))
        p.perks(perk.bimbotf) = 0
        count -= 1
    End Sub
End Class
