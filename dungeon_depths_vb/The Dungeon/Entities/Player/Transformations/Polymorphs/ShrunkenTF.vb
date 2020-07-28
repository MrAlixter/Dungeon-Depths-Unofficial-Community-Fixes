Public NotInheritable Class ShrunkenTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "Shrunken"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As Player = Game.player1
        turnsTilNextStep = 90 + Int(Rnd() * 20)
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1
        Dim out = ""


        p.pClass = p.classes("Shrunken")

        out += "The shrink ray in your hands doesn't do anything, despite your pulling of its trigger numerous times.  As it begins emitting a high frequency whine, it occurs to you that perhaps something might be wrong.  As your line of sight starts lowering on the horizon, your heart sinks and you toss aside the broken ray gun.  As soon as it makes contact with the ground, however, it fires a highly concentrated beam that hits you straight in the chest.  Nearly instantaniously you and all of your belongings shrink down to the size of a small pebble.  Fortunately, it doesn't seem like your opponent has lost track of you for now, but given how small you are you may want to avoid direct conflict for now."

        Game.pushLblEvent(out)
    End Sub
End Class
