Public Class Tendrill
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Tendrill")
        MyBase.settier(1)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        If Not getCaster.formName.Contains("Slime") And Not getCaster.formName.Contains("Goo") And Not getCaster.inv.getCountAt(VialOfSlime.ITEM_NAME) > 0 And Not getCaster.inv.getCountAt(VialOfPSlime.ITEM_NAME) > 0 Then
            TextEvent.pushAndLog("The spell sputters before poofing into nothing.  If only you had some slime...")
            Exit Sub
        End If

        Dim dmg As Integer = 30
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        If getCaster.formName.Contains("Slime") Or getCaster.formName.Contains("Goo") Then
            dmg += 9 * Math.Max(0, getCaster.breastSize)
            dmg += 7 * Math.Max(0, getCaster.buttSize)
            dmg += 10 * Math.Max(0, getCaster.dickSize)
        ElseIf getCaster.inv.getCountAt(VialOfPSlime.ITEM_NAME) > 0 Then
            dmg += 15
            TextEvent.pushLog("You uncork a " & VialOfPSlime.ITEM_NAME.Replace("_", " ") & ".")
            getCaster.inv.add(VialOfPSlime.ITEM_NAME, -1)
        ElseIf getCaster.inv.getCountAt(VialOfSlime.ITEM_NAME) > 0 Then
            TextEvent.pushLog("You uncork a " & VialOfSlime.ITEM_NAME.Replace("_", " ") & ".")
            getCaster.inv.add(VialOfSlime.ITEM_NAME, -1)
        End If

        dmg = getSpellDamage(getCaster, getTarget, dmg + d31 + d32)

        TextEvent.push("You harden your slime, and fire a spinning spike of gel!" & DDUtils.RNRN &
                       "You hit " & MyBase.getTarget.getNameWithTitle & " for " & dmg & " damage!")
        TextEvent.pushLog("You hit " & MyBase.getTarget.getNameWithTitle & " for " & dmg & " damage!")

        MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
    End Sub

    Private Function getSpellDamage(ByRef caster As Entity, ByRef target As Entity, ByVal dmg As Integer) As Integer
        Return Entity.calcDamage(dmg + (Math.Max(caster.getATK - 10, -10)), target.getWIL)
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that twists slime into magical damage.  While a simple vial may not contain enough slime to do much, if the caster is made of goo themself they can put their entire body into the attack.  The damage scales to ATK & body size rather than WIL."
    End Function
End Class
