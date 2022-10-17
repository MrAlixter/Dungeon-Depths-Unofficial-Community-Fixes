Public Class HelpWanted
    Inherits Quest

    Sub New()
        MyBase.New("Help Wanted")

        quest_index = qInd.helpWanted

        objectives.Add(New HWantedSnipCollars)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        TextEvent.pushNPCDialog("""Hey, can I ask for your help on something?  I've been seeing a lot of people roaming around here with those collars looking for valubles, and that got me thinking... Why don't I expand my staff?  If you can snip off a few of their collars and send them my way,  I can make it worth your time.""" & DDUtils.RNRN &
                   "Quest ""Help Wanted"" acquired!" & vbCrLf & "+1 Old Snips")

        Game.player1.inv.add(251, 1)
        Game.player1.perks(perk.collarssnipped) = 0
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.currFloor.floorNumber > 2 And Not getComplete()
    End Function
End Class

Friend Class HWantedSnipCollars
    Inherits Objective

    Sub New()
        MyBase.New("Snip the collars off of 5 thralls.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        Dim newpoint = Game.currFloor.getRndAdjPoint(Game.player1)
        Game.shop_npc_list(0).pos = newpoint
        Game.currFloor.npcPositions(0) = newpoint

        Game.drawBoard()

        Game.npcEncounter(Game.shopkeeper)
        TextEvent.pushNPCDialog("""Well done!  With the extra manpower, I'll probably be able to rotate in some more useful stock.  For more immediate payment, I hope this is to your liking.""" & DDUtils.RNRN &
                           "+1 Collar Snips" & vbCrLf &
                           "+1000 Gold")

        Game.player1.gold += 1000
        Game.player1.inv.add("Collar_Snips", 1)
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.collarssnipped) & "/5]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.perks(perk.collarssnipped) >= 5
    End Function
End Class

