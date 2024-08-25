Public Class TimeCopAgent
    Inherits Monster

    Public Const BASE_NAME As String = "Time Cop"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 135
        attack = 35
        defense = 35
        speed = 35
        will = 35

        '|Inventory|
        setInventory({128, 128, 274, 261})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn(Game.player1.level + 1)
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        '|Basic Attack|
        Dim dmg = Entity.calcDamage(getATK, ((target.getDEF + target.getWIL) / 2))

        TextEvent.pushAndLog("The " & getName() & " fires a sleek chrome rifle!")
        target.takeDMG(dmg, Me)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        TextEvent.pushLog("The Time Cop tosses a cryogrenade at you!")
        p.petrify(Color.FromArgb(255, 75, 209, 255), 9999)
        p.drawPort()

        TextEvent.push("The Time Cop relaxes, staring at your frozen body." & DDUtils.RNRN &
                          """I got " & If(p.sex = "Male", "him", If(p.sex = "Female", "her", "them")) & ", I GOT " & If(p.sex = "Male", "HIM", If(p.sex = "Female", "HER", "THEM")) & "!"", they exclaim into their communicatior." & DDUtils.RNRN &
                          "Before long, two more agents show up and the group hastily opens a portal to a familiar cell.  The group then rotates you horizontally, and begins carrying you towards the rift before..." & DDUtils.RNRN &
                          "CRASH!!!" & DDUtils.RNRN &
                          "Your feet slip out of one of the agent's hands, and your frozen body shatters on the floor." & DDUtils.RNRN &
                          """Uhhh... whoops...""" & DDUtils.RNRN & DDUtils.RNRN & "GAME OVER!", AddressOf p.die)
    End Sub
End Class
