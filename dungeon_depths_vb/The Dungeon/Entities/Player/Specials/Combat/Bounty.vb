Public Class Bounty
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Bounty's Collection")
        MyBase.setUOC(False)
        MyBase.setcost(22)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget
        TextEvent.pushLog("Bounty's Collection!")
        TextEvent.pushCombat("Bounty's Collection!")

        If m.getIntHealth > Entity.calcDamage(p.getATK, m.getDEF / 2) Then
            'Fail
            TextEvent.pushCombat("Failed to collect bounty!  All loot lost...")
            Dim hasKey = False
            If m.inv.getCountAt("Key") > 0 Then hasKey = True
            m.inv = New Inventory()

            If hasKey Then m.inv.add("Key", 1)
        Else
            'Success
            m.inv.setCount(43, 4 * m.inv.getCountAt(43))

            m.die(p)
            TextEvent.pushCombat("Bounty Collected!")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "If this attack would kill its target, it greatly increases the amount of gold dropped.  If not, it intimidates the target into hiding away all of their non-key valuables..." &
               If(Not t Is Nothing, DDUtils.RNRN & "This attack would deal aproximately " & Entity.calcDamage(c.getATK, t.getDEF / 2) & " damage.", "")
    End Function
End Class
