Public Class MoltenFireball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Molten Fireball")
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 40
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)
        If 1 = 0 Then
            'critical hit
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            TextEvent.pushAndLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!  The blowback hits you for " & dmg * 0.087 & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
            MyBase.getCaster.takeDMG(dmg * 0.087, MyBase.getCaster)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "An unstable tier 1 spell that deals medium magical damage without a mana cost, although its explosive casting damages its user as well."
    End Function
End Class
