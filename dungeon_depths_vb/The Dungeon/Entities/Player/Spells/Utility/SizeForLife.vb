Public Class SizeForLife
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Reductive Mending")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(2)
    End Sub

    Public Overrides Sub effect()
        Dim out As String = ""

        If MyBase.getCaster().dickSize > 0 Or MyBase.getCaster().breastSize > 0 Then
            Dim hdif = Math.Min(66, MyBase.getCaster.getMaxHealth - MyBase.getCaster.getIntHealth)

            MyBase.getCaster.health += (hdif / MyBase.getCaster.getMaxHealth)

            out = "You heal yourself for " & hdif & " health!"

            If (MyBase.getCaster().breastSize > MyBase.getCaster().dickSize And MyBase.getCaster().breastSize > 0) Or (MyBase.getCaster().dickSize < 1) Then
                getCaster.bs()
                out += "  Your chest squeezes uncomfortably..."
            ElseIf (MyBase.getCaster().dickSize > 0) Then
                getCaster.ds()
                out += "  Your dick squeezes uncomfortably..."
            End If

            MyBase.getCaster.drawPort()
        Else
            out = "The spell fizzles out as you cast it, and your chest and " & If(getCaster.dickSize = 0, "dick", "pussy") & " squeeze uncomfortably..."
        End If

        TextEvent.pushAndLog(out)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that heals its caster for approximately 66 HP, at the cost of bust/dick size."
    End Function
End Class
