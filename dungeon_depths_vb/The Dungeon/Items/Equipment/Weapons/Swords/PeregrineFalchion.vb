Public Class PeregrineFalchion
    Inherits Sword

    Public Const ITEM_NAME As String = "Peregrine_Falchion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 419
        tier = 4

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 26
        s_boost = 4
        d_boost = -9
        count = 0
        value = 2378

        '|Description|
        setDesc("A broad single-handed sword, with a slightly curved edge that reflects no light.  The guard above its hilt resembles the feathers of a svelte bird of prey." & DDUtils.RNRN &
                "Critical hit rate increases the faster you are than your foe." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)

        If dmg <= 4 Then
            Return -1
        ElseIf dmg >= 11 Or getAltCrit(p, m) Then
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
