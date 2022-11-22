Public Class CuteBeam
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Sweet Sunbeam")
        MyBase.settier(3)
        MyBase.setcost(17)
    End Sub
    Public Overrides Sub effect()
        If getTarget.health < 0.5 And Not getTarget.form.Equals("Plush") Then
            targetPlushTF()
        Else
            Dim dmg As Integer = 33
            Dim d6 = Int(Rnd() * 20)

            MyBase.getTarget.takeDMG(dmg + d6, MyBase.getCaster)

            TextEvent.pushLog(CStr("A golden ray engulfs your foe!"))
            TextEvent.pushCombat(CStr("A golden ray of light engulfs your foe, cackling with a rosy glow!  As they stumble back, you notice that they seem a little... cuter... than they did before..."))
        End If
    End Sub
    Public Overrides Sub backfire()
        selfPlushTF()
    End Sub

    Sub targetPlushTF()
        MyBase.getTarget.tfCt = 1
        MyBase.getTarget.tfEnd = 7
        MyBase.getTarget.form = "Plush"
        MyBase.getTarget.attack = 0
        MyBase.getTarget.defense *= 1.25
        TextEvent.pushLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a plush!"))
        TextEvent.pushCombat(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a plush version of their prior form!"))
    End Sub

    Sub selfPlushTF()
        Polymorph.transform(MyBase.getCaster, "Plush")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 3 spell that transforms its target into a cute plush version of their normal form with a low chance of backfiring or missing altogether."
    End Function
End Class
