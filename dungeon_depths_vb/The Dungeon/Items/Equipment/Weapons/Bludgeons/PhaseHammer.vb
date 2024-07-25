Public Class PhaseHammer
    Inherits Bludgeon

    Public Const ITEM_NAME As String = "Phase_Hammer"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 275
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        MyBase.a_boost = 69
        count = 0
        value = 3488

        '|Description|
        setDesc("A heavy chrome-plated mallet that converts the meager energy contained in an AAAAAA Battery into a powerful impact.  Batteries not included." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 12) + 1

        If dmg <= 3 Then Return -1
 

        dmg += (p.getATK)

        If p.inv.getCountAt("AAAAAA_Battery") < 1 Then
            Return Player.calcDamage(dmg, m.getDEF)
        Else
            p.inv.add("AAAAAA_Battery", -1)
            TextEvent.pushAndLog("The hammer head ejects a smoldering battery shell.  " & p.inv.getCountAt("AAAAAA_Battery") & " batter" & If(p.inv.getCountAt("AAAAAA_Battery") = 1, "y", "ies") & " left!")
        End If

        dmg += (getABoost(p))

        Return Player.calcDamage(dmg, m.getDEF)
    End Function
End Class
