Public Class DueForAnUpgrade
    Inherits Quest

    Sub New()
        MyBase.New("Due For an Upgrade")

        qInd = qInds.dfaUpgrade

        objectives.Add(New DFAUpgradeStep1)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        TextEvent.pushNPCDialog("""Hmmmm, as much as... hot?... as the outfit you have there is, it looks like your gear could be reinforced into something that offers a bit more protection.  No amount of smithing is going to break that curse if you got it, buuuut if you can find me the materials, I can at least take a crack at getting you some better armor.""" & DDUtils.RNRN &
                   "Quest ""Due For an Upgrade"" acquired!")
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.currFloor.floorNumber > 2 And Game.player1.equippedArmor.getAntiSlutInd <> -1 And Not getComplete()
    End Function
End Class

Public Class DFAUpgradeStep1
    Inherits Objective

    Sub New()
        MyBase.New("Collect 5 armor fragments from chests.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(29), """Nice!  I'm gonna stoke my furnace and melt these down, stop by when you get the chance and I'll forge you a better set of armor, okay?""" & DDUtils.RNRN &
                         "+1000 Gold")

        Game.player1.gold += 1000

        Game.player1.inv.setCount("Armor_Fragments", 0)
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.inv.getCountAt("Armor_Fragments") & "/5]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.inv.getCountAt("Armor_Fragments") >= 5
    End Function
End Class

