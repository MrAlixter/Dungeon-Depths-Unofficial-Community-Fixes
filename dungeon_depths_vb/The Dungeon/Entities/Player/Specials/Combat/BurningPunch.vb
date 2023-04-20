Public Class BurningPunch
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Megaton Punch")
        MyBase.setUOC(False)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = MyBase.getUser.getATK + 20
        Dim d31 = Int(Rnd() * 6)
        Dim d32 = Int(Rnd() * 6)
        If 1 = 0 Then
            'critical hit
        Else
            'non critical hit
            dmg = MyBase.getUser.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            dmg = Entity.calcDamage(dmg, getTarget.defense)
            specHit(getName, dmg, getUser, getTarget)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A punch so fast that it causes its user's fist to become engulfed in flame.  The impact deals heavy magic damage."
    End Function
End Class
