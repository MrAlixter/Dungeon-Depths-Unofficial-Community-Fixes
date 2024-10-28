Public Class Lucifork
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Lucifork")
        MyBase.setUOC(False)
        MyBase.setcost(46)
    End Sub
    Public Overrides Sub effect()
        If Not getUser.equippedWeapon.GetType().IsSubclassOf(GetType(Spear)) Then
            TextEvent.fpushAndLog("...but you don't have a spear equipped.")

            getUser.stamina += getCost()
            Exit Sub
        End If

        Randomize()
        stab(0)
    End Sub
    Public Sub stab(ByVal i As Integer)
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If (i > 1 AndAlso Not p.passDieRoll(i, 1)) Or m.isDead Or i > 32 Then Exit Sub

        Dim dmg As Integer = Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1)
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
        dmg = Entity.calcDamage(dmg, getTarget.defense)

        specHit(getName, dmg, getUser, getTarget, If(i > 0, "  Additional attack!", ""))

        If m.perks(npc_perk.burn) > -1 Then
            Dim d As Integer = 4 + Int(Rnd() * 8) + Int(Rnd() * 7) + Int(Rnd() * 6) + Int(Rnd() * 5) + Int(Rnd() * 4) + Int(Rnd() * 3)
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(m.getNameWithTitle) & " takes " & d & " fire damage!")
            m.takeDMG(d, Game.player1)
            m.perks(npc_perk.burn) -= 1
        End If

        i += 1
        stab(i)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A sinister spear attack that has the potential to chain additional attacks based on the luck of the user.  One additonal attack is guranteed.  If the target is already on fire, deals extra fire damage with each hit."
    End Function
End Class
