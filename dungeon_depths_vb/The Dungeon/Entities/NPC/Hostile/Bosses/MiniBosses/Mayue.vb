Public Class Mayue
    Inherits MiniBoss

    Dim turns_until_spell As Integer
    Dim enchantment_inds_used As List(Of Integer)
    Sub New()
        '|ID Info|
        name = "Mayue, Feline Enchantress"

        '|Stats|
        maxHealth = 120
        attack = 44
        defense = 5
        speed = 44
        will = 5
        xp_value = 200
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount("Extra_Life", 8)
        inv.setCount("Gold", 1000)

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        turns_until_spell = 3
        enchantment_inds_used = New List(Of Integer)

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) Then
            turns_until_spell -= 1

            If turns_until_spell < 1 And inv.getCountAt("Extra_Life") < 4 And Not target.getPlayer Is Nothing And enchantment_inds_used.Count < 5 Then
                TextEvent.pushAndLog(getName() & " casts Marissa's Enchantment!")

                marissasEnchantment(target.getPlayer)

                turns_until_spell = 2 + Int(Rnd() * 2)
                Exit Sub
            ElseIf turns_until_spell < 1 And getIntHealth() < 50 Then
                Dim healvalue = Int(Rnd() * 4) + Int(Rnd() * 2) + 30
                If getIntHealth() + healvalue > getMaxHealth() Then healvalue = getMaxHealth() - getIntHealth()
                TextEvent.pushLog((getName() & " heals herself!  +" & healvalue & " health!"))
                TextEvent.pushCombat((getName() & " heals herself for " & healvalue & " health!"))
                takeDMG(-healvalue, Nothing)

                turns_until_spell = 3
                Exit Sub
            End If
        End If

        TextEvent.pushLog((getName() & " slashes at you!"))
        TextEvent.pushCombat((getName() & " slashes at you!"))
        MyBase.attackCMD(target)
    End Sub

    Public Sub marissasEnchantment(ByRef p As Player)

        Dim d5 As Integer = 0

        While enchantment_inds_used.Contains(d5)
            d5 = Int(Rnd() * 5)
        End While

        enchantment_inds_used.Add(d5)

        If d5 = 0 Then
            If p.inv.getCountAt("Cat_Lingerie") < 1 Then p.inv.add("Cat_Lingerie", 1)
            EquipmentDialogBackend.armorChange(p, "Cat_Lingerie")

            TextEvent.pushAndLog("Your armor turns into a set of Cat_Lingerie!")

        ElseIf d5 = 1 Then
            If Not p.prt.sexBool Then
                p.MtF()
                TextEvent.pushAndLog("You are now female!")
            Else
                p.be()
            End If

        ElseIf d5 = 2 Then
            p.prt.setIAInd(pInd.ears, 1, p.prt.sexBool, False)
            TextEvent.pushAndLog("You now have cat ears!")

        ElseIf d5 = 3 Then
            p.prt.setIAInd(pInd.rearhair, 12, True, True)
            p.prt.setIAInd(pInd.midhair, 17, True, True)
            p.prt.setIAInd(pInd.fronthair, 1, True, False)
            TextEvent.pushAndLog("You now have long, straight hair!")

        ElseIf d5 = 4 Then
            p.prt.setIAInd(pInd.eyes, 13, True, True)
            TextEvent.pushAndLog("You now have kitten eyes!")

        End If

        p.drawPort()
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        If inv.getCountAt("Extra_Life") > 1 Then
            inv.item("Extra_Life").add(-1)
            health = 0.125 * inv.getCountAt("Extra_Life")
            TextEvent.pushAndLog("Mayue uses an Extra_Life!")
        ElseIf inv.getCountAt("Extra_Life") = 1 Then
            isDead = True
            MyBase.despawn("quest")
            TextEvent.push("Before you land the final blow, a shimmering barrier appears between Mayue and yourself.  You dart back, spotting a familiar figure as she joins the fray.", AddressOf die2)
        Else
            MyBase.die(cause)
        End If
    End Sub
    Private Sub die2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(101), "MARISSA THE ENCHANTRESS HAS REVIVED!" & DDUtils.RNRN &
                        """Well, well, well, if it isn't my old pal " & Game.player1.getName & ".  How's it been?""", AddressOf die3)
    End Sub
    Private Sub die3()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(98), """I've been out of it for a while, haven't I?  It definitely lookes like someone's been doing well..."" Marissa says, smirking.  ""For what it's worth, thanks for your help.""" & DDUtils.RNRN &
                          """But Lady Marissa, you don't need to-"" Mayue interjects, before Marissa holds up a hand, stopping her." & DDUtils.RNRN &
                          """Let it go, Mayue, we're leaving.""", AddressOf die4)
    End Sub
    Private Sub die4()
        TextEvent.push("Mayue pulls out a small piece of chalk, and swiftly draws a circle on the ground.  The circle flares with magical energy, and the two of them hop into the ring as a portal begins to form." & DDUtils.RNRN &
                          """Oh, and " & Game.player1.getName & "?  Keep on your toes.  There's all sorts of dangerous stuff out there.""", AddressOf die5)
    End Sub
    Private Sub die5()
        Dim c1 As Chest
        c1 = DDConst.BASE_CHEST.Create(inv, pos)
        Game.combat_engaged = True
        If inv.getSum > 0 Then c1.open()
        Game.combat_engaged = False
    End Sub
    Public Overrides Sub despawn(reason As String)
        If reason = "run" Then
            Game.player1.quests(qInd.nineLives).completeEntireQuest()
        End If
        MyBase.despawn(reason)
    End Sub
End Class
