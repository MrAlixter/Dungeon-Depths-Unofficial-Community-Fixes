Public Class UpgradeValkyrieSword
    Inherits Item

    Public Const ITEM_NAME As String = "Upgrade_Valkyrie_Sword"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 400
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf fix

        '|Stats|
        count = 0
        value = 4500

        '|Description|
        setDesc("""So, think you can lend me your sword and some of that sparkly gear you've got there?  I'd love to take a crack at a few modifications...""" & DDUtils.RNRN &
                "Consumes 1x " & ValkyrieSword.ITEM_NAME & " and 1x (" & PhotonBikini.ITEM_NAME & " or " & PhotonBlade.ITEM_NAME & " or " & PhotonArmor.ITEM_NAME & ", selected in that order and based on the count owned of each)")
    End Sub

    Sub fix()
        Dim p = Game.player1
        Game.shopMenu.Close()

        If p.inv.getCountAt(ValkyrieSword.ITEM_NAME) > 0 AndAlso Not p.equippedWeapon.getAName.Equals(ValkyrieSword.ITEM_NAME) AndAlso getConsumedPhotonGear(p) <> "" Then
            TextEvent.pushNPCDialog("Alright, there we go!")
            TextEvent.pushLog("+1 " & CyberValkyrieSword.ITEM_NAME)
            TextEvent.pushLog("-1 " & ValkyrieSword.ITEM_NAME)
            TextEvent.pushLog("-1 " & getConsumedPhotonGear(p))

            p.inv.add(ValkyrieSword.ITEM_NAME, -1)
            p.inv.add(getConsumedPhotonGear(p), -1)
            p.inv.add(CyberValkyrieSword.ITEM_NAME, 1)
            p.UIupdate()
        ElseIf p.equippedWeapon.getAName.Equals(ValkyrieSword.ITEM_NAME) Then
            TextEvent.pushNPCDialog("You're gonna have to put that thing down for me to work on it, right?")
            p.gold += value
        Else
            TextEvent.pushNPCDialog("Hate to say it, but there's not much I can do for you there..." & DDUtils.RNRN &
                                    "You might need to unequip some gear if you've got any of the photon parts equipped.")
            p.gold += value
        End If

        count -= 1
    End Sub

    Function getConsumedPhotonGear(ByRef p As Player) As String
        Dim p_bikini_ct = p.inv.getCountAt(PhotonBikini.ITEM_NAME)
        Dim p_armor_ct = p.inv.getCountAt(PhotonArmor.ITEM_NAME)
        Dim p_blade_ct = p.inv.getCountAt(PhotonBlade.ITEM_NAME)

        If p_bikini_ct > 0 AndAlso Math.Max(p_bikini_ct, p_armor_ct) = p_bikini_ct AndAlso Math.Max(p_bikini_ct, p_blade_ct) = p_bikini_ct AndAlso Not (p.equippedArmor.getAName.Equals(PhotonBikini.ITEM_NAME) And p_bikini_ct = 1) Then
            Return PhotonBikini.ITEM_NAME
        ElseIf p_blade_ct > 0 AndAlso Math.Max(p_blade_ct, p_bikini_ct) = p_blade_ct AndAlso Math.Max(p_blade_ct, p_armor_ct) = p_blade_ct AndAlso Not (p.equippedWeapon.getAName.Equals(PhotonBlade.ITEM_NAME) And p_blade_ct = 1) Then
            Return PhotonBlade.ITEM_NAME
        ElseIf p_armor_ct > 0 AndAlso Math.Max(p_armor_ct, p_bikini_ct) = p_armor_ct AndAlso Math.Max(p_armor_ct, p_blade_ct) = p_armor_ct AndAlso Not (p.equippedArmor.getAName.Equals(PhotonArmor.ITEM_NAME) And p_armor_ct = 1) Then
            Return PhotonArmor.ITEM_NAME
        End If

        Return ""
    End Function
End Class
