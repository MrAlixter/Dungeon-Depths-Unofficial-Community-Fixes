Public Class KeepAway
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Keep Away")
        MyBase.setUOC(False)
        MyBase.setcost(11)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1)
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
        dmg = Entity.calcDamage(dmg, getTarget.defense * 1.15)

        specHit(getName, dmg, getUser, getTarget)

        If p.equippedWeapon.GetType().IsSubclassOf(GetType(Spear)) AndAlso p.passDieRoll(2) Then
            MyBase.getTarget.despawn("keepaway")
            Game.updatable_queue.clear()

            TextEvent.pushLog("You throw " & m.getNameWithTitle() & " with the shaft of your weapon!")
            If Not m.isDead Then TextEvent.fpush("You throw " & m.getNameWithTitle() & " with the shaft of your weapon, and " & m.pronoun & " doesn't seem keen to re-engage after recovering from " & m.p_pronoun & " hard landing.")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Swats a foe with the intent to knock it back.  If the user is wielding a spear, there is a 50% chance of the enemy being knocked away."
    End Function
End Class
