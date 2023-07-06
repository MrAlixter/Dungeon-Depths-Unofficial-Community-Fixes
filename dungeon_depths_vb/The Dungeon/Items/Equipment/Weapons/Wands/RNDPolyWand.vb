Public Class RNDPolyWand
    Inherits Wand

    Private Enum randomPolymorphNPC
        minotaurCow
        minotaurBull
        dragon
        succubus
        slime
        bimbo
        cake
        alraune
        blob
        halfDragonR
        tigress
        faerie
    End Enum

    Public Const ITEM_NAME As String = "Wand_of_Warp_and_Weave"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 370
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False

        '|Stats|
        count = 0
        value = 4888

        '|Description|
        setDesc("A slender cyan wand that bristles with volatile energy." & DDUtils.RNRN &
                "Transforms all in an area at random, dealing damage proportional to the change in stats to any opponents." & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        TextEvent.pushAndLog("You zap the area, transforming both yourself and your foe!")

        Dim m_avg_stats = (m.maxHealth + m.maxMana + m.attack + m.defense + m.will + m.speed) / 6

        If p.perks(perk.tfedbyweapon) > -1 Then PerkEffects.randomPoly(p.formStates(stateInd.magGState)) Else PerkEffects.randomPoly()

        Dim ind = [Enum].GetNames(GetType(randomPolymorphNPC)).Length
        polymorphNPC(m.getNPC, indToForm([Enum].GetValues(GetType(randomPolymorphNPC))(Int(Rnd() * ind))))

        Dim m_avg_stats2 = (m.maxHealth + m.maxMana + m.attack + m.defense + m.will + m.speed) / 6

        Dim dmg As Integer = 15 + Math.Abs(m_avg_stats - m_avg_stats2)


        TextEvent.pushAndLog("The " & m.getName & " takes " & dmg & " damage!")

        m.takeDMG(dmg, p)
    End Sub

    Private Shared Function indToForm(ByVal rp As randomPolymorphNPC) As pForm
        Select Case rp
            Case randomPolymorphNPC.minotaurCow
                Return New MinotaurCow
            Case randomPolymorphNPC.minotaurBull
                Return New MinotaurBull
            Case randomPolymorphNPC.dragon
                Return New Dragon
            Case randomPolymorphNPC.succubus
                Return New Succubus
            Case randomPolymorphNPC.slime
                Return New Slime
            Case randomPolymorphNPC.cake
                Return New Cake
            Case randomPolymorphNPC.alraune
                Return New AlrauneF
            Case randomPolymorphNPC.halfDragonR
                Return New HalfDragonR
            Case randomPolymorphNPC.tigress
                Return New Tigress
            Case randomPolymorphNPC.faerie
                Return New FaeForm
            Case Else
                Return New Blob
        End Select
    End Function

    Public Shared Sub polymorphNPC(ByRef n As NPC, ByVal form As pForm)
        n.maxHealth = n.sMaxHealth
        n.maxMana = n.sMaxMana
        n.attack = n.sAttack
        n.defense = n.sDefense
        n.will = n.sWill
        n.speed = n.sSpeed

        n.maxHealth *= form.h
        n.maxMana *= form.m
        n.attack *= form.a
        n.defense *= form.d
        n.will *= form.w
        n.speed *= form.s

        n.form = form.name
        n.perks(npc_perk.tfdur) = 999
    End Sub
End Class
