Public Class MiniBoss
    Inherits Monster
    Sub New(ByVal mIndex As Integer)
        Select Case mIndex
            Case 1
                name = "Marissa the Enchantress"
                setMaxHealth(150)
                setATK(25)
                setDEF(-5)
                setSPD(10)

                inv.setCount("Health_Potion", 3)
                inv.setCount("Spellbook", 2)
                inv.setCount("Cat_Lingerie", 1)
                inv.setCount("Restore_Potion", 1)
                inv.setCount("Cat_Ears", 1)
                inv.setCount("Mana_Charm", 1 + CInt(Rnd() * 2))
                inv.setCount("Omni_Charm", 1)
                inv.setCount("Sorcerer's_Robes", CInt(Rnd() * 2))

                title = " "
                pronoun = "she"
                pPronoun = "her"
                rPronoun = "her"
            Case 2
                setName("Targax the Brutal")
                setMaxHealth(250)
                setATK(50)
                setDEF(20)
                setSPD(5)
                inv.setCount("Health_Potion", 2)
                inv.setCount("Major_Health_Potion", 3)
                inv.setCount("Sword_of_the_Brutal", 1)
                inv.setCount("Warrior's_Cuirass", CInt(Rnd() * 2))
                inv.setCount("Attack_Charm", 1 + CInt(Rnd() * 2))
                inv.setCount("Omni_Charm", 1)

                title = " "
                pronoun = "he"
                pPronoun = "his"
                rPronoun = "him"
            Case 4
                setName("Ooze Empress")
                setMaxHealth(100)
                setATK(30)
                setDEF(70)
                setSPD(1)
                setInventory({3, 58, 65})
                inv.setCount("Defence_Charm", 1 + CInt(Rnd() * 2))
                inv.setCount("Omni_Charm", 1)
                title = " "
                pronoun = "she"
                pPronoun = "her"
                rPronoun = "her"
            Case Else
                setName("Explorer")
                setMaxHealth(300)
                setATK(15)
                setDEF(15)
                setSPD(15)
                Randomize()
                For i = 0 To 5
                    Dim invInd As Integer = 8
                    While invInd = 8 Or invInd = 10 Or invInd = 24 Or invInd = 53 Or invInd = 119
                        invInd = Int(Rnd() * (Game.player.inv.upperBound + 1))
                    End While
                    inv.add(invInd, CInt(Rnd() * 2) + 1)
                Next
        End Select
        setHealth(1.0)
        If speed = Game.player.speed Then speed -= 1
        sName = getName()
        pos = Game.player.pos
    End Sub
    Public Overrides Sub attackCMD(ByRef target As Entity)
        If isStunned Then
            Game.pushLblEvent(name & " is stunned!")
            Exit Sub
        End If

        If name.Equals("Marissa the Enchantress") Then
            If target.GetType() Is GetType(Player) Then
                If Game.player.perks("nekocurse") = -1 Then
                    Game.pushLstLog((getName() & " casts a curse on you!"))
                    Game.pushLblCombatEvent((getName() & " casts a curse on you!"))
                    Game.player.ongoingTFs.Add(New NekoTF(7, 1, 0.3, True))
                ElseIf Game.player.perks("nekocurse") > -1 And getHealth() < 45 / getMaxHealth() Then
                    Dim healvalue = Int(Rnd() * 4) + Int(Rnd() * 2) + 30
                    If getIntHealth() + healvalue > getMaxHealth() Then healvalue = getMaxHealth() - getIntHealth()
                    Game.pushLstLog((getName() & " heals herself!  +" & healvalue & " health!"))
                    Game.pushLblCombatEvent((getName() & " heals herself for " & healvalue & " health!"))
                    takeDMG(-healvalue, Nothing)
                ElseIf Game.player.getIntHealth < 20 Then
                    Game.pushLstLog((getName() & " waits expectantly..."))
                    Game.pushLblCombatEvent((getName() & " waits expectantly..."))
                Else
                    Game.pushLstLog((getName() & " casts lightning bolt!"))
                    Game.pushLblCombatEvent((getName() & " casts lightning bolt!"))
                    MyBase.attackCMD(target)
                End If
            Else
                Game.pushLstLog((getName() & " casts lightning bolt!"))
                Game.pushLblCombatEvent((getName() & " casts lightning bolt!"))
                MyBase.attackCMD(target)
            End If
        Else
            MyBase.attackCMD(target)
        End If

    End Sub
End Class
