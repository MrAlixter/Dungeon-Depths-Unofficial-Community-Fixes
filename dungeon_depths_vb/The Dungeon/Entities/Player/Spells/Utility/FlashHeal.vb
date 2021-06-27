Public Class FlashHeal
    Inherits Spell

    Public Const SPELL_NAME As String = "Flash Heal"

    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Flash Heal")
        MyBase.setUOC(True)
        MyBase.settier(2)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        Dim hdif = Math.Min(85, MyBase.getCaster.getMaxHealth - MyBase.getCaster.getIntHealth)

        MyBase.getCaster.health += (hdif / MyBase.getCaster.getMaxHealth)

        Game.pushLogAndEvent("You heal yourself for " & hdif & " health!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that heals its caster for approximately 85 HP and is guaranteed to be cast first, with a low chance of missing altogether."
    End Function
End Class
