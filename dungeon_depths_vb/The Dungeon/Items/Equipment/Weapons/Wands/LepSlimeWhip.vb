Public Class LepSlimeWhip
    Inherits Wand

    Public Const ITEM_NAME As String = "Whip_of_Leporine_Slime"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 372
        tier = Nothing

        '|Item Flags|
        usable = False
        npc_drop_only = True

        '|Stats|
        m_boost = 10
        a_boost = 33
        w_boost = 10
        count = 0
        value = 10

        '|Description|
        setDesc("A tar-black whip of opaque slime dripping off of the consumed shaft of a wand.  Two small ""ears"" spring up just above the handle..." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1)
        If dmg <= 5 Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If
        dmg += (p.attack) + (Me.getABoost(p))
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        'do nothing
    End Sub
End Class
