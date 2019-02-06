Public Class MiniBoss
    Inherits Monster
    Sub New(ByVal mIndex As Integer)
        MyBase.New(-1)
        Select Case mIndex
            Case 1
                MyBase.name = "Marissa the Enchantress"
                MyBase.setMaxHealth(150)
                MyBase.setATK(25)
                MyBase.setDEF(-5)
                MyBase.setSPD(10)

                MyBase.inv.setCount("Health_Potion", 3)
                MyBase.inv.setCount("Spellbook", 2)
                MyBase.inv.setCount("Cat_Lingerie", 1)
                MyBase.inv.setCount("Restore_Potion", 1)
                MyBase.inv.setCount("Cat_Ears", 1)
                MyBase.inv.setCount("Sorcerer's_Robes", CInt(Rnd() * 2))

                title = ""
                pronoun = "she"
                pPronoun = "her"
                rPronoun = "her"
            Case 2
                MyBase.setName("Targax the Brutal")
                MyBase.setMaxHealth(250)
                MyBase.setATK(50)
                MyBase.setDEF(20)
                MyBase.setSPD(5)
                MyBase.inv.setCount("Health_Potion", 5)
                MyBase.inv.setCount("Sword_of_the_Brutal", 1)
                MyBase.inv.setCount("Warrior's_Cuirass", CInt(Rnd() * 2))

                title = ""
                pronoun = "he"
                pPronoun = "his"
                rPronoun = "him"
            Case 4
                MyBase.setName("Ooze Empress")
                MyBase.setMaxHealth(100)
                MyBase.setATK(30)
                MyBase.setDEF(70)
                MyBase.setSPD(1)
                setInventory({3, 58, 65})
                title = ""
                pronoun = "she"
                pPronoun = "her"
                rPronoun = "her"
            Case Else
                MyBase.setName("Explorer")
                MyBase.setMaxHealth(300)
                MyBase.setATK(15)
                MyBase.setDEF(15)
                MyBase.setSPD(15)
                Randomize()
                For i = 0 To 5
                    Dim invInd As Integer = 8
                    While invInd = 8 Or invInd = 10 Or invInd = 24 Or invInd = 53
                        invInd = Int(Rnd() * (Game.player.inv.upperBound + 1))
                    End While
                    MyBase.inv.add(invInd, CInt(Rnd() * 2) + 1)
                Next
        End Select
        MyBase.setHealth(1.0)
        If speed = Game.player.speed Then speed -= 1
        MyBase.sName = getName()
        MyBase.pos = Game.player.pos
    End Sub
    Public Overrides Sub attackCMD(ByRef target As Entity)
        If name.Equals("Marissa the Enchantress") Then
            If target.GetType() Is GetType(Player) Then
                If Game.player.perks("nekocurse") = -1 Then
                    Game.pushLstLog((getName() & " casts a curse on you!"))
                    Game.pushLblCombatEvent((getName() & " casts a curse on you!"))
                    Game.player.ongoingTFs.Add(New NekoTF(7, 1, 0.3, True))
                ElseIf Game.player.perks("nekocurse") > -1 And getHealth() < 45 / getMaxHealth() Then
                    Dim healvalue = Int(Rnd() * 4) + Int(Rnd() * 2) + 30
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
