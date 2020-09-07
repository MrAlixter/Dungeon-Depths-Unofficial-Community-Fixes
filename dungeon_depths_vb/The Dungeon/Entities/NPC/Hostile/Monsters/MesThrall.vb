Public Class MesThrall
    Inherits Monster
    Sub New()
        name = "Mesmerized Thrall"
        maxHealth = 85
        attack = 20
        defense = 7
        speed = 9
        setInventory({0, 1, 13})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        If p.pForm.name.Equals("Blowup Doll") Then
            despawn("p-death")
            Game.pushLblEvent("Your enemy, seeing your current state, decides that you likely aren't useful and leaves you alone.")
            Exit Sub
        End If
        Dim out As String = ""
        Dim ln1 As String = Nothing
        If p.pClass.name.Equals("Thrall") Then
            out = "Despite your fatigue, you are able to roll out of the way of the thrall's attempt to restrain you, and make a clumsy escape."

        Else
            ln1 = "As you collapse, you see the thrall pull a small metal collar out of their bag.  Lacking the strength to resist, you are powerless as they secure it firmly around your neck, all the while murmuring whispers of the joys of submission into your ear.  Once they have the collar fitted properly, they place a small glowing gem into a slot on the collar, igniting a small array of runes.  Your mind goes blank in an instant, and while at first an ammnesia-fueled panic sets in it is quickly replaced by a booming disembodied voice."
            p.inv.add(69, 1)
            Equipment.accChange("Slave_Collar")
            p.health = 1
            p.mana = p.getMaxMana()
            Game.player1.will -= 3
            If Game.player1.will < 1 Then Game.player1.will = 0
        End If
        If Not p.currTarget Is Nothing Then despawn("p-death")
        If Not ln1 Is Nothing Then
            Game.pushLblEvent(ln1, AddressOf ThrallTF.thrallLN2)
        Else
            Game.pushLblEvent(out)
        End If
    End Sub
End Class
