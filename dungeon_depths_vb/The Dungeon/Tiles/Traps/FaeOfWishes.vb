Public Class FaeOfWishes
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.faeofwishes
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(105), """Hi there!  I'm the fae of wishes, and you've just won a free wish!""" & DDUtils.RNRN &
                          "Press any non-movement key to continue...", AddressOf displayDialog)
    End Sub

    Sub displayDialog()
        Dim heal = New Tuple(Of String, Action)("Healing", AddressOf FaeOfWishes.heal)
        Dim gold = New Tuple(Of String, Action)("Gold", AddressOf FaeOfWishes.gold)
        Dim skills = New Tuple(Of String, Action)("Skills", AddressOf FaeOfWishes.skills)
        Dim stronger = New Tuple(Of String, Action)("Strength", AddressOf FaeOfWishes.stronger)
        TextEvent.pushManySelect("Wish for what?", heal, gold, skills, stronger)
    End Sub

    Shared Sub heal()
        Dim p As Player = Game.player1

        p.health = 1.0
        p.mana = p.getMaxMana
        p.stamina = 100

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), "That's an easy one!  Consider your wish granted.")
    End Sub
    Shared Sub gold()
        Dim p As Player = Game.player1

        p.inv.add("Hornswoggler's_Oculus", 1)

        EquipmentDialogBackend.equipGlasses(p, "Hornswoggler's_Oculus", False)
        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), "Hmmm...  Gold...  Oh, you know who gets a lot of gold?  Pirates!  You could use this snazzy pirate trick to get more gold!")
    End Sub
    Shared Sub skills()
        Dim p As Player = Game.player1

        p.inv.add("Pirate_Handbook", 1)

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), """More skills?  I'm not really sure where I would get- OH!  Check out this pirate handbook!  You could definitely learn a thing or two from the high seas!""" & DDUtils.RNRN &
                          "+1 Pirate Handbook")
    End Sub
    Shared Sub stronger()
        Dim p As Player = Game.player1

        p.inv.add("Eyepatch", 1)

        EquipmentDialogBackend.equipGlasses(p, "Eyepatch", False)
        p.drawPort()

        p.changeClass("Pirate")

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), "Stronger, eh?  Pirates are really strong!  If you want to be really strong, you should be a pirate!")
    End Sub
End Class
