Public Class Heal
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Heal")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        Dim hdif = Math.Min(50, MyBase.getCaster.getMaxHealth - MyBase.getCaster.getIntHealth)

        MyBase.getCaster.health += (hdif / MyBase.getCaster.getMaxHealth)

        Game.pushLogAndEvent("You heal yourself for " & hdif & " health!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that heals its caster for approximately 50 HP."
    End Function

    Public Overrides Function getcost() As Integer
        If Not getCaster() Is Nothing AndAlso getCaster.className.Contains("Cleric") Then Return 2 Else Return 3
    End Function
End Class
