Public Class Bounty
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Bounty's Collection")
        MyBase.setUOC(False)
        MyBase.setcost(22)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget
        Game.pushLstLog("Bounty's Collection!")
        Game.pushLblCombatEvent("Bounty's Collection!")

        If m.getIntHealth > Entity.calcDamage(p.getATK, m.getDEF / 2) Then
            'Fail
            Game.pushLblCombatEvent("Failed to collect bounty!  All loot lost...")
            Dim hasKey = False
            If m.inv.getCountAt("Key") > 0 Then hasKey = True
            m.inv = New Inventory()

            If hasKey Then m.inv.add("Key", 1)
        Else
            'Success
            m.inv.setCount(43, 4 * m.inv.getCountAt(43))

            m.die(p)
            Game.pushLblCombatEvent("Bounty Collected!")
        End If
    End Sub
End Class
