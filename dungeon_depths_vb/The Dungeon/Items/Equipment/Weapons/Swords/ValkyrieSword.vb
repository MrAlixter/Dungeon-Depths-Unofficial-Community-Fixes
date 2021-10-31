Public Class ValkyrieSword
    Inherits Sword

    Sub New()
        '|ID Info|
        setName("Valkyrie_Sword")
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
            valkyrieTF.step1()
            p.perks(perk.tfcausingsword) = id
            p.perks(perk.tfedbyweapon) = 1
            p.drawPort()
        End If
    End Sub

    Public Overrides Sub onunEquip(ByRef p As Player, ByRef w As Weapon)
        If (p.className.Equals("Valkyrie") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Sword)) Then
            TextEvent.pushLog("Putting away your sword causes you to change into your regular self!")
            TextEvent.pushLog("Sighing, you stow away your sword and revert to your base form.  Helix Slash special forgotten...")
            If p.knownSpecials.Contains("Helix Slash") Then p.knownSpecials.Remove("Helix Slash")
            If p.knownSpecials.Contains("Blazing Angel Strike") Then p.knownSpecials.Remove("Blazing Angel Strike")

            p.perks(perk.tfedbyweapon) = -1

            p.inv.add(95, -1)
            p.revertToPState()
        End If
    End Sub
End Class
