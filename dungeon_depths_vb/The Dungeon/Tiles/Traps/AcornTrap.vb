Public Class AcornTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.acorn
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Game.player1.takeDMG(Int(Rnd() * 6) + 1, Nothing)

        TextEvent.push("Something falls from above and strikes you in the head...", AddressOf yesNo)
    End Sub

    Sub yesNo()
        TextEvent.pushYesNo("Throw it into the woods?", AddressOf fightSquirrel, AddressOf getAcorn)
    End Sub
    Sub fightSquirrel()
        Dim m As ManySquirrels = New ManySquirrels()

        Monster.targetRoute(m)
        Game.toCombat(m)

        TextEvent.pushLog((m.getName() & " attack!"))
    End Sub
    Sub getAcorn()
        TextEvent.pushAndLog("+1 Acorn")
        Game.player1.inv.add(Acorn.ITEM_NAME, 1)
    End Sub
End Class
