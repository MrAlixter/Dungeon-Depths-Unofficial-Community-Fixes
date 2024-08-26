Public Class CyberValkyrieSword
    Inherits Sword

    Public Const ITEM_NAME As String = "Mecha_Valkyrie_Sword"

    Protected uniform_id As Integer = 398

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 399
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        m_boost = 14
        a_boost = 35
        count = 0
        value = 3000

        '|Description|
        setDesc("A blazing sword used by a winged protector." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Mecha Valkyrie") And Not p.perks(perk.tfedbyweapon) > 0 Then
            Dim valkyrieTF = New CyberValkyrieTF(1, 0, 0, False)

            valkyrieTF.update()
            p.ongoingTFs.add(valkyrieTF)

            p.perks(perk.tfcausingsword) = id
            p.perks(perk.tfedbyweapon) = 1
        End If
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        If (p.className.Equals("Mecha Valkyrie") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Sword)) And p.perks(perk.tfcausingsword) = id Then
            If Not Game.lblEvent.Visible Then TextEvent.fpush("Sighing, you sheath your blade and revert to your base form.")

            p.inv.add(uniform_id, -1)

            p.perks(perk.tfedbyweapon) = -1

            p.revertToPState()
        ElseIf (p.className.Equals("Mecha Valkyrie") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Sword)) Then
            CType(p.inv.item(p.perks(perk.tfcausingsword)), Sword).onUnequip(p, w)
        End If
    End Sub
End Class
