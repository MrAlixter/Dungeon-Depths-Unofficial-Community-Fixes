Public Class UpgradeArmor
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Upgrade_Armor")
        id = 263
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf fix

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("""If your equipped kit is a litte less... practical... than you'd like, I can get it adjusted to be better protection.""")
    End Sub

    Sub fix()
        Dim p = Game.player1
        Game.shopMenu.Close()

        If Equipment.antiClothingCurse(p) Then
            TextEvent.pushNPCDialog("Alright, there we go!  That should do you a little better in the defense department.")
        Else
            TextEvent.pushNPCDialog("Well, I hate to say it but there isn't much I can do for you there...")
            p.gold += 2000
        End If

        count -= 1
    End Sub
End Class
