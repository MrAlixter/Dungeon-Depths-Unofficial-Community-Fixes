Public Class TargaxSword
    Inherits Sword

    Public Const ITEM_NAME As String = "Sword_of_the_Brutal"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 24
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False
        MyBase.onSell = AddressOf BEggGetSword.completeStep

        '|Stats|
        MyBase.a_boost = 50
        count = 0
        value = 3332

        '|Description|
        setDesc("A suspicious sword owned by a brutal despot." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        End If
        dmg += (p.getATK) + (Me.getABoost(p))
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If Not p.perks(perk.swordpossess) > -1 Then p.perks(perk.swordpossess) = 0
    End Sub
    Public Overloads Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnequip(p, w)
        If p.perks(perk.swordpossess) > -1 Then p.perks(perk.swordpossess) = -1
    End Sub
End Class
