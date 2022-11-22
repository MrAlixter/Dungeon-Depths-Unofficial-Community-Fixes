Public Class FeatherDagger
    Inherits Dagger

    Public Const ITEM_NAME As String = "Featherlight_Stiletto"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 353
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 375

        a_boost = 5
        s_boost = 10

        '|Description|
        setDesc("A small, nearly weightless blade with the pattern of a feather engraved along its length." & DDUtils.RNRN &
                "When attacking, the user hits twice." & DDUtils.RNRN &
                "Critical hit rate increases the faster you are than your foe." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDesc() As Object
        Return "A small, nearly weightless blade with the pattern of a feather engraved along its length." & DDUtils.RNRN &
               "When attacking, the user hits twice." & DDUtils.RNRN &
               "Critical hit rate increases the faster you are than your foe." & DDUtils.RNRN &
               getStatInformation()
    End Function
    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso (Not p.className.Contains("Maid") Or p.className.Equals("Maiden")) Then
            p.inv.add(MaidDuster.ITEM_NAME, 1)
            p.inv.add(FeatherDagger.ITEM_NAME, -1)

            If p.equippedWeapon.getAName.Equals(ITEM_NAME) Then EquipmentDialogBackend.equipWeapon(p, MaidDuster.ITEM_NAME)

            TextEvent.pushLog("With a poof, your " & ITEM_NAME & " turns into a " & MaidDuster.ITEM_NAME & "!")

            p.inv.invNeedsUDate = True
            p.UIupdate()
        End If

        Return MyBase.getABoost(p)
    End Function

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        '1st hit
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then
            p.miss(m)
        ElseIf dmg >= 11 Or getAltCrit(p, m) Then
            If (p.getATK * 2) >= m.getIntHealth Then Return -2
            p.cHit(p.getATK, m)
        Else
            dmg += (p.getATK) + (Me.a_boost)
            If (Player.calcDamage(dmg, m.defense)) >= m.getIntHealth Then Return Player.calcDamage(dmg, m.defense)
            p.hit(Player.calcDamage(dmg, m.defense), m)
        End If

        '2nd hit
        dmg = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then
            Return -1
        ElseIf dmg >= 11 Or getAltCrit(p, m) Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.a_boost)
        Return Player.calcDamage(dmg, m.defense)
    End Function
    Function getAltCrit(ByRef p As Player, ByRef m As Entity) As Boolean
        If m.getSPD >= p.getSPD Then Return False

        Dim ratio As Double = Math.Min(p.getSPD / m.getSPD, 5.0)

        Return (Rnd() * ratio) > 1.0
    End Function
End Class
