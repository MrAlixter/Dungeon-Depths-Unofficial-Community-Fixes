Public Class CryoGrenade
    Inherits Item

    Public Const ITEM_NAME As String = "CryoGrenade"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 128
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 560

        '|Description|
        setDesc("A chrome-plated metal cage housing a core that glows an icy blue.  A set of vents keeps the frigid cold inside, but the entire device seems rather...poorly constructed.")
    End Sub

    Public Overrides Sub use(ByRef p As Player)

        If (p.getWIL < 8 And Int(Rnd() * 5) = 1) Or p.currTarget Is Nothing Or Game.combat_engaged = False Then
            'backfire
            p.savePState()

            p.defense = 20

            Dim pturns = 4
            p.petrify(Color.FromArgb(240, 75, 209, 255), pturns)
            p.drawPort()
            TextEvent.pushLog(CStr("The grenade freezes you solid for 4 turns!"))
            TextEvent.push(CStr("As the grenade goes off, you find yourself caught in its icy blast.  You are frozen for 4 turns!"))
        Else
            'regular effect
            p.currTarget.perks(npc_perk.stun) = 2
            TextEvent.pushLog("The grenade freezes " & p.currTarget.getName & " solid for 3 turns!")
            TextEvent.pushCombat("The grenade freezes " & p.currTarget.getName & " solid for 3 turns!")
        End If
        count -= 1
    End Sub
End Class
