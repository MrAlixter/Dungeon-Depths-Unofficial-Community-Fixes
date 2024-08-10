Public Class Freeze
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Freeze")
        MyBase.setUOC(True)
        MyBase.settier(2)
        MyBase.setcost(4)
    End Sub
    Public Overrides Sub effect()
        Dim p = getCaster()

        If Game.combat_engaged Then
            'regular effect
            getTarget.perks(npc_perk.freeze) = 2
            TextEvent.fpushAndLog("Your spell freezes " & getTarget.getNameWithTitle & " solid for 3 turns!")
        Else
            'backfire
            p.savePState()

            p.defense = 20

            Dim pturns = 5
            p.petrify(Color.FromArgb(240, 75, 209, 255), pturns)
            p.drawPort()
            TextEvent.fpushAndLog(CStr("You freeze yourself solid for 5 turns!"))
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 utility spell that freezes its target for 3 turns, with a low chance of missing altogether."
    End Function
End Class
