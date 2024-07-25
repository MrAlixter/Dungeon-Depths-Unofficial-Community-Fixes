Public Class VampiricThrust
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Vampiric Thrust")
        MyBase.setUOC(False)
        MyBase.setcost(18)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1)
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
        dmg = Entity.calcDamage(dmg, getTarget.defense * 1.23)

        specHit(getName, dmg, getUser, getTarget)

        p.equippedWeapon.durability = Math.Min(p.equippedWeapon.durability + dmg, 100)
        p.inv.item(p.equippedWeapon.getAName()).durability = p.equippedWeapon.durability

        p.health += (dmg / p.getMaxHealth)

        Dim out = "Restored " & dmg & " HP to both you and your equipped " & p.equippedWeapon.getName.Replace("_", " ") & "!"
        If m.isDead Then
            TextEvent.pushLog(out)
        Else
            TextEvent.fpushAndLog(out)
        End If

    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Syphons the away the health of an enemy, restoring health equal to the damage dealt to both the user and their equipped weapon.  Vampiric Thrust will deal less damage than usual against enemies as their defense increases."
    End Function
End Class
