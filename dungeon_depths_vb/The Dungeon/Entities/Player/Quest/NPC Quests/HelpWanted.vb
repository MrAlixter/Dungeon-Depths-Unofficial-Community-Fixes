Public Class HelpWanted
    Inherits Quest

    Sub New()
        MyBase.New("Help Wanted")

        objectives.Add(New HWantedSnipCollars)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Game.player1.inv.add(251, 1)
        Game.player1.perks(perk.collarssnipped) = 0
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.currFloor.floorNumber > 2 And Not getComplete()
    End Function
End Class

Public Class HWantedSnipCollars
    Inherits Objective

    Sub New()
        MyBase.New("Snip the collars of 5 thralls.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        Dim newpoint = Game.currFloor.getRndAdjPoint(Game.player1)
        Game.shopNPCList(0).pos = newpoint
        Game.currFloor.npcPositions(0) = newpoint

        Game.drawBoard()

        Game.npcEncounter(Game.shopkeeper)
        Game.pushNPCDialog("""Well done!  With the extra manpower, I'll probably be able to rotate in some more useful stock.  For more immediate payment, I hope this is to your liking.""" & DDUtils.RNRN &
                           "+1 Collar Snips" & vbCrLf &
                           "+1000 Gold")
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.collarssnipped) & "/5]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.perks(perk.collarssnipped) >= 5
    End Function
End Class

