Public Class SummonBattery
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Summon Battery")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(10)
    End Sub
    Public Overrides Sub effect()
        If getCaster.getGold < 10 Then
            getCaster.mana += getcost()
            Game.pushLogAndEvent("You don't have enough gold to transmute a battery!")
            Exit Sub
        End If

        getCaster.gold -= 10
        getCaster.inv.add("AAAAAA_Battery", 1)

        Game.pushLblEvent("You place a stack of ten gold coins on the floor and repeat the incantation scrawled on the back of the specification sheet.  With a boiling flash of light, the coins melt down and reform into a single charged cell." & DDUtils.RNRN &
                          "+1 AAAAAA Battery")
        Game.pushLstLog("You transmute a AAAAAA Battery!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that uses the matter of 10 gold coins to transmute a AAAAAA battery cell."
    End Function
End Class
