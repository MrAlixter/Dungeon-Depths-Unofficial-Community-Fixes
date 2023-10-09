Public Class FirehawkWand
    Inherits Wand

    Public Const ITEM_NAME As String = "Firehawk's_Quill"
    Protected Const MANA_COST As Integer = 8
    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 421
        tier = 4

        '|Item Flags|
        usable = False
        droppable = False

        '|Stats|
        w_boost = 26
        count = 0
        value = 2378

        '|Description|
        setDesc("A narrow golded rod; its surface engraved with the texture of a feather.  When held, it burns with a firey glow." & DDUtils.RNRN &
                "Critical hit rate increases the faster you are than your foe." & DDUtils.RNRN &
                "Drains " & MANA_COST & " MP per use.  If MP is less than " & MANA_COST & ", the attack will fail." & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        If p.getMana > MANA_COST Then
            p.setMana(Math.Max(0, p.getMana - MANA_COST))

            Dim dmg As Integer = 40
            Dim d51 = Int(Rnd() * 3)
            Dim d52 = Int(Rnd() * 3)
            If (d51 = d52 And d52 = 2) Or getAltCrit(p, m) Then
                'critical hit
                dmg = p.getSpellDamage(m, 2 * (dmg + d51 + d52))
                p.hit(dmg, m, "  Critical hit!", "burn")
            Else
                'non critical hit
                dmg = p.getSpellDamage(m, dmg + d51 + d52)
                p.hit(dmg, m, "", "burn")
            End If
        Else
            TextEvent.pushAndLog("The wand sputters, and all that comes forth is a puff of smoke.")
        End If
    End Sub

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
