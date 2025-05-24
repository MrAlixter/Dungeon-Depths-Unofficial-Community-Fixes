Public MustInherit Class PolymorphedNPC
    Inherits Monster

    Protected originalShape As NPC

    Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        originalShape = e

        '| - Setup Stats - |
        health = e.health
        maxHealth = e.getMaxHealth() * getHPModifier()
        mana = e.mana
        maxMana = e.getMaxMana() * getMPModifier()
        attack = e.getATK() * getATKModifier()
        defense = e.getDEF() * getDEFModifier()
        speed = e.getSPD() * getSPDModifier()
        will = e.getWIL() * getWILModifier()

        gold = e.gold
        xp_value = e.xp_value

        inv = e.inv

        '| - Text Stats - |
        name = e.name
        pronoun = e.pronoun
        r_pronoun = e.r_pronoun
        p_pronoun = e.p_pronoun
        form = getFormName()

        perks = e.perks
        perks(npc_perk.tfdur) = duration

        '| - Replace the selected NPC - |
        p.setTarget(Me)
        currTarget = p
        'Game.npc_list.Remove(e)
        Game.npc_list.Clear()
        Game.npc_list.Add(Me)

        Game.updatable_queue.replace(e, Me)
    End Sub

    Overridable Function getHPModifier() As Double
        Return 1.0
    End Function
    Overridable Function getMPModifier() As Double
        Return 1.0
    End Function
    Overridable Function getATKModifier() As Double
        Return 1.0
    End Function
    Overridable Function getDEFModifier() As Double
        Return 1.0
    End Function
    Overridable Function getSPDModifier() As Double
        Return 1.0
    End Function
    Overridable Function getWILModifier() As Double
        Return 1.0
    End Function

    MustOverride Function getFormName() As String

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If originalShape.getWIL > target.getWIL And Int(Rnd() * 2) = 0 Then
            TextEvent.fpushAndLog("The transformed " & originalShape.getName() & " briefly regains control!")
            originalShape.attackCMD(target)
        Else
            newAttackCMD(target)
        End If
    End Sub

    MustOverride Sub newAttackCMD(ByRef target As Entity)

    Public Overrides Sub reactToTF()
        originalShape.reactToTF()
    End Sub

    Public Overrides Sub revert()
        originalShape.health = health
        originalShape.mana = mana
        originalShape.gold = gold
        originalShape.xp_value = xp_value

        originalShape.perks = perks
        originalShape.perks(npc_perk.tfdur) = -1

        Game.player1.setTarget(originalShape)
        'Game.npc_list.Remove(Me)
        Game.npc_list.Clear()
        Game.npc_list.Add(originalShape)

        Game.updatable_queue.replace(Me, originalShape)

        If Game.player1.isDead Or Game.lblEvent.Visible Or Game.pnlEvent.Visible Then
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " returns to " & p_pronoun & " original form!")
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " returns to " & p_pronoun & " original form!")
        End If

    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        Me.isDead = True
        originalShape.die(cause)
    End Sub

    Public Shared Function polymorph(ByRef t As NPC, ByRef p As Player, ByVal dur As Integer, ByVal form As String) As PolymorphedNPC
        If t.GetType.IsSubclassOf(GetType(PolymorphedNPC)) Then
            TextEvent.push("Your foe is already polymorphed!")
            Return Nothing
        End If

        Select Case form
            Case "Amnesiac"
                Return New PAmnesiac(t, p, dur)
            Case "Bee-Girl"
                Return New PBeegirl(t, p, dur)
            Case "Bunny"
                Return New PBunny(t, p, dur)
            Case "Cat-Girl"
                Return New PCatGirl(t, p, dur)
            Case "Cow"
                Return New PCow(t, p, dur)
            Case "Dragon​"
                Return New PDragon(t, p, dur)
            Case "Dove"
                Return New PDove(t, p, dur)
            Case "Giant Frog"
                Return New PGiantFrog(t, p, dur)
            Case "Goblin"
                Return New PGoblin(t, p, dur)
            Case "Goo Girl"
                Return New PGooGirl(t, p, dur)
            Case "Hellhound"
                Return New PHellhound(t, p, dur)
            Case "Newt"
                Return New PNewt(t, p, dur)
            Case "Princess"
                Return New PPrincess(t, p, dur)
            Case "Pyreslug"
                Return New PPyreslug(t, p, dur)
            Case "Sheep"
                Return New PSheep(t, p, dur)
            Case "Slime"
                Return New PSlime(t, p, dur)
            Case "Succubus​"
                Return New PSuccubus(t, p, dur)
            Case "Trilobite"
                Return New PTrilobite(t, p, dur)
            Case Else
                Return Nothing
        End Select
    End Function
End Class
