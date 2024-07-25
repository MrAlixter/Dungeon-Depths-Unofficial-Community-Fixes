Public Class Guillotine
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Guillotine")
        MyBase.setUOC(False)
        MyBase.setcost(27)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = 10
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))

        If dmg * 2 >= m.getIntHealth() Then
            specHit(getName, dmg * 2, getUser, getTarget, "  Critical Hit!")
        Else
            Dim out = "Your attack glances off of " & m.getNameWithTitle & ", and cracks frighteningly into the ground.  Your " & p.equippedWeapon.getName.Replace("_", " ") & " takes " & CInt(dmg * 0.75) & " damage!"
            TextEvent.pushLog(out)
            TextEvent.fpush(out & DDUtils.RNRN & "Your enemy would need to have " & dmg * 2 & " health or less for Guillotine to work.")
            p.equippedWeapon.damage(CInt(dmg * 0.75))
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Gurantees a critical hit if that would kill the enemy.  Otherwise, misses and damages the equipped weapon."
    End Function
End Class
