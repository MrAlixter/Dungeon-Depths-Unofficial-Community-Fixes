Public Class Bovinomancer
    Inherits Monster
    Sub New()
        name = "Bovinaemancer"

        maxHealth = 250
        mana = 100
        attack = 15
        defense = 10
        speed = 45
        will = 50

        setInventory({25, 34, 70, 71, 197})

        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not ("Cow".Equals(target.getPlayer.pForm.name) And Not "Cow".Equals(target.getPlayer.pForm.name)) And
            (target.getMaxHealth > getMaxHealth() Or target.getWIL > getWIL() Or target.getATK > getATK()) And mana > 15 Then
            spell1(target)
        ElseIf mana > 5 Then
            spell2(target)
        Else
            MyBase.attackCMD(target)
        End If
    End Sub

    Sub spell1(ByRef e As Entity)
        Game.pushLogAndEvent("The " & getName() & " casts ""Bovinize"", turning you into a cow!")

        If Not e.getPlayer Is Nothing Then
            playerSpell1(e.getPlayer)
        ElseIf Not e.getNPC Is Nothing Then
            npcSpell1(e.getNPC)
        End If
    End Sub
    Sub playerSpell1(ByRef p As Player)
        Polymorph.transform(p, "Cow")
    End Sub
    Sub npcSpell1(ByRef n As NPC)
        n.tfCt = 1
        n.tfEnd = Int(Rnd() * 7) + 3
        n.form = "Cow"
        n.attack = 1
        n.defense = 20
        n.speed = 1
        If n.getIntHealth > 150 Then n.health = 1
        n.maxHealth = 150
    End Sub

    Sub spell2(ByRef e As Entity)
        Dim dmg As Integer = 35 + Int(Rnd() * 20)
        dmg = getSpellDamage(e, dmg)

        Game.pushLogAndEvent("The " & getName() & " casts ""Cattle Prod"", zapping you for " & dmg & "!")

        e.takeDMG(dmg, Me)

        If Not e.getPlayer Is Nothing Then
            playerSpell2(e.getPlayer)
        End If
    End Sub
    Sub playerSpell2(ByRef p As Player)
        If Int(Rnd() * 3) Then
            p.prt.setIAInd(pInd.ears, 8, True, True)
        End If

        If Int(Rnd() * 3) Then
            p.prt.setIAInd(pInd.horns, 1, True, False)
        End If

        If Int(Rnd() * 3) Then
            p.prt.setIAInd(pInd.horns, 2, True, False)
        End If

        If Int(Rnd() * 3) Then
            p.be()
        End If

        If Int(Rnd() * 3) Then
            p.be()
        End If

        p.drawPort()
    End Sub
End Class
