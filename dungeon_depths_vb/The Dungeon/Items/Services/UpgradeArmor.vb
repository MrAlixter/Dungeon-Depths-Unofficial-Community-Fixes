Public Class UpgradeArmor
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Upgrade_Armor")
        id = 263
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False
        MyBase.onBuy = AddressOf fix

        '|Stats|
        MyBase.count = 0
        MyBase.value = 1000

        '|Description|
        MyBase.setDesc("""If your equipped kit is a litte less... practical... than you'd like, I can get it adjusted to be better protection.""")
    End Sub

    Sub fix()
        Dim p = Game.player1
        Game.shopMenu.Close()

        If Equipment.antiClothingCurse(p) Then
            Game.pushNPCDialog("Alright, there we go!  That should do you a little better in the defense department.")
        Else
            Game.pushNPCDialog("Well, I hate to say it but there isn't much I can do for you there...")
            p.gold += 2000
        End If

        count -= 1
    End Sub
End Class
