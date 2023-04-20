Public Class FlashBolt
    Inherits Spell

    Public Const SPELL_NAME As String = "Flash Bolt"

    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Flash Bolt")
        MyBase.settier(2)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 35
        Dim d31 = Int(Rnd() * 7)
        Dim d32 = Int(Rnd() * 7)
        If Int(Rnd() * 6) = 0 Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, (dmg + d31 + d32) * 2)
            getCaster.hit(dmg, getTarget, "  Critical hit!", "zap")
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            getCaster.hit(dmg, getTarget, "zap")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that deals medium magic damage and is guaranteed to hit first, with a low chance of missing altogether."
    End Function
End Class
