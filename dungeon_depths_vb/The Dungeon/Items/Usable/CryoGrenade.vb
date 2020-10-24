Public Class CryoGrenade
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("CryoGrenade")
        id = 128
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 560

        '|Description|
        MyBase.setDesc("A chrome-plated metal cage housing a core that glows an icy blue.  A set of vents keeps the frigid cold inside, but the entire device seems rather...poorly constructed.")
    End Sub

    Public Overrides Sub use(ByRef p As Player)

        If (p.getWIL < 8 And Int(Rnd() * 5) = 1) Or p.currTarget Is Nothing Or Game.combatmode = False Then
            'backfire
            p.savePState()

            p.defense = 20

            Dim pturns = 4
            p.petrify(Color.FromArgb(190, 75, 209, 255), pturns)
            p.drawPort()
            Game.pushLstLog(CStr("The grenade freezes you solid for 4 turns!"))
            Game.pushLblEvent(CStr("As the grenade goes off, you find yourself caught in its icy blast.  You are frozen for 4 turns!"))
        Else
            'regular effect
            p.currTarget.isStunned = True
            p.currTarget.stunct = 2
            Game.pushLstLog("The grenade freezes " & p.currTarget.getName & " solid for 3 turns!")
            Game.pushLblCombatEvent("The grenade freezes " & p.currTarget.getName & " solid for 3 turns!")
        End If
        count -= 1
    End Sub
End Class
