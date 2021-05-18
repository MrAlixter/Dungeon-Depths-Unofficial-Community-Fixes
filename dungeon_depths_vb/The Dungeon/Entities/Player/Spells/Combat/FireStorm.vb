Public Class FireStorm
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Firestorm")
        MyBase.settier(1)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        For i = 0 To Int(Rnd() * 3) + 2
            If getCaster.mana < 5 Then Exit For
            'non critical hit
            Dim dmg As Integer = 35
            Dim d31 = Int(Rnd() * 3)
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31)
            Game.pushLogAndEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
            If i <> 0 Then getCaster.mana -= 5
            If MyBase.getTarget.isDead Then Exit For
        Next
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that sends out a flurry of 2-4 balls of flame that deal medium magic damage."
    End Function
End Class
