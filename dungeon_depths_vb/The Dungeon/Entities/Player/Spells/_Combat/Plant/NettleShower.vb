Public Class NettleShower
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Nettle Shower")
        MyBase.settier(1)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        For i = 0 To Int(Rnd() * 3) + Int(Rnd() * 3) + 2
            If i <> 0 AndAlso getCaster.mana < 3 Then Exit For

            'non critical hit
            Dim dmg As Integer = 12
            Dim d6 = Int(Rnd() * 6)
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d6)
            getCaster.hit(dmg, getTarget, "", "prick")

            If i <> 0 Then getCaster.mana -= 3

            If MyBase.getTarget.isDead Then Exit For
        Next
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that sends out a flurry of 2-6 thorns that deal light magic damage."
    End Function
End Class
