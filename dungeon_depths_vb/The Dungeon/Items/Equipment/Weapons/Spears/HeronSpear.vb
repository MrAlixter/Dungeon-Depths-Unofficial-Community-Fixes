Public Class HeronSpear
    Inherits Spear

    Public Const ITEM_NAME As String = "Heronbeak_Pike"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 420
        tier = 4

        '|Item Flags|
        usable = True

        '|Stats|
        a_boost = 26
        d_boost = -9
        count = 0
        value = 2378
        MyBase.weight = 7

        '|Description|
        setDesc("A slender spear made out of a metallic alloy that shines blue in the light.  The elongated taper into its tip brings to mind the shape of a particuar shorebird, almost as though it was designed to fly through the air.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                "Critical hit rate increases the faster you are than your foe." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) +
            Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1)
        If dmg <= 8 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 10 Or getAltCrit(p, m) Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.getABoost(p))
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Function getAltCrit(ByRef p As Player, ByRef m As Entity) As Boolean
        If m.getSPD >= p.getSPD Then Return False

        Dim ratio As Double = Math.Min(p.getSPD / m.getSPD, 5.0)

        Return (Rnd() * ratio) > 1.0
    End Function

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f3f5
                Return 4
            Case LootTable.bracket.f6f9
                Return 3
            Case LootTable.bracket.f10f12
                Return 3
            Case LootTable.bracket.f14fXX
                Return 2
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
