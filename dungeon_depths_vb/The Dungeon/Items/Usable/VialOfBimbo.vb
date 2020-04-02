Public Class VialOfBimbo
    Inherits Item

    Sub New()
        MyBase.setName("Vial_of_BIM_II")
        MyBase.setDesc("A glittery, glowing pink potion contained in a clear, scientific looking glass tube.  A small label on the vial states that it contains ""200ml of BIM_II,"" a ""Potentially dangerous arcanomutant,"" whatever that means...")
        id = 127
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1230
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        Game.pushLblEvent("Drinking the pink contents of the vial causes a dizzy calm wash to over you.")
        p.ongoingTFs.Add(New BimboPlusTF(2, 5, 0.25, True))
        p.perks("bimbotf") = 0
        count -= 1
    End Sub
End Class
