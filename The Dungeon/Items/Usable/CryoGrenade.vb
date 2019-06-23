Public Class CryoGrenade
    Inherits Item

    Sub New()
        MyBase.setName("CryoGrenade")
        MyBase.setDesc("A chrome-plated metal cage housing a core that glows an icy blue.  A set of vents keeps the frigid cold inside, but the entire device seems rather...poorly constructed.")
        id = 128
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 560
    End Sub

    Public Overrides Sub use()
        Dim p = Game.player

        If (p.getWIL < 8 And Int(Rnd() * 5) = 1) Or p.currTarget Is Nothing Or Game.combatmode = False Then
            'backfire
            If Transformation.canBeTFed(p) Then
                p.pState.save(p)
            End If
            p.defence = 20

            Dim pturns = 4
            p.petrify(Color.FromArgb(190, 75, 209, 255), pturns)
            p.createP()
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
