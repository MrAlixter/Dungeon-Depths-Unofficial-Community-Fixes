Public Class ValkyrieSword
    Inherits Sword

    Public Const ITEM_NAME As String = "Valkyrie_Sword"

    Protected uniform_id As Integer = 95

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 96
        tier = 3

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.m_boost = 7
        MyBase.a_boost = 22
        count = 0
        value = 1000

        '|Description|
        setDesc("A blazing sword used by a winged protector." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Valkyrie") And Not p.perks(perk.tfedbyweapon) > 0 Then
            Dim valkyrieTF = New ValkyrieTF2(1, 0, 0, False)

            valkyrieTF.update()
            p.ongoingTFs.add(valkyrieTF)

            p.perks(perk.tfcausingsword) = id
            p.perks(perk.tfedbyweapon) = 1
        End If
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        If (p.className.Equals("Valkyrie") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Sword)) Then
            TextEvent.push("Sighing, you sheath your blade and revert to your base form.")

            p.inv.add(uniform_id, -1)

            p.perks(perk.tfedbyweapon) = -1

            p.revertToPState()
        End If
    End Sub
End Class
