Public Class IcicleFlurry
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Icicle Flurry")
        MyBase.settier(1)
        MyBase.setcost(8)
    End Sub
    Public Overrides Sub effect()
        For i = 0 To Int(Rnd() * 2) + Int(Rnd() * 2) + 2
            If i <> 0 AndAlso getCaster.mana < 6 Then Exit For

            Dim dmg As Integer = 39
            Dim d3 = Int(Rnd() * 3) + 1

            If getCaster.passDieRoll(20, 1) Then
                'critical hit
                dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, 2 * (dmg + d3))
                getCaster.hit(dmg, getTarget, "  Critical Hit!", "pierce")
            Else
                'non-critical hit
                dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d3)
                getCaster.hit(dmg, getTarget, "", "pierce")
            End If

            If i <> 0 Then getCaster.mana -= 6

            If MyBase.getTarget.isDead Then Exit For
        Next
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that sends out a flurry of 2-4 spears of ice that deal medium magic damage, with a rare chance to hit critically."
    End Function
End Class
