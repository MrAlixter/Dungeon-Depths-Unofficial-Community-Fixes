Public Class MarissasNeophyte
    Inherits Monster

    Dim enchantment_inds_used As List(Of Integer)

    Public Const BASE_NAME As String = "Marissa's Student"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 150
        maxMana = 40
        attack = 12
        defense = 40
        speed = 40
        will = 40
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount("Gold", 300 + CInt(Rnd() * 300))

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        enchantment_inds_used = New List(Of Integer)
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) Then

            If health < 0.5 And mana > 3 Then
                Dim hdif = Math.Min(50, getMaxHealth() - getIntHealth())
                health += (hdif / getMaxHealth())
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " heals " & r_pronoun & "self for " & hdif & " health!")
                mana -= 3
                Exit Sub
            ElseIf mana > 17 Then
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Marissa's Enchantment!")
                marissasEnchantment(target.getPlayer)
                mana -= 17
                Exit Sub
            ElseIf mana > 5 Then
                attackSpell(target, "a lightning bolt", getWIL() * 0.75)
                mana -= 5
            End If
        End If

        TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " throws a sad punch!")
        MyBase.attackCMD(target)
    End Sub

    Public Sub marissasEnchantment(ByRef p As Player)

        Dim d4 As Integer = 0

        While enchantment_inds_used.Contains(d4)
            d4 = Int(Rnd() * 4)
        End While

        enchantment_inds_used.Add(d4)

        If d4 = 1 Then
            If Not p.prt.sexBool Then
                p.MtF()
                TextEvent.pushAndLog("You are now female!")
            Else
                p.be()
            End If

        ElseIf d4 = 2 Then
            p.prt.setIAInd(pInd.ears, 1, p.prt.sexBool, False)
            TextEvent.pushAndLog("You now have cat ears!")

        ElseIf d4 = 3 Then
            p.prt.setIAInd(pInd.rearhair, 12, True, True)
            p.prt.setIAInd(pInd.midhair, 17, True, True)
            p.prt.setIAInd(pInd.fronthair, 1, True, False)
            TextEvent.pushAndLog("You now have long, straight hair!")

        ElseIf d4 = 0 Then
            p.prt.setIAInd(pInd.eyes, 13, True, True)
            TextEvent.pushAndLog("You now have kitten eyes!")

        End If

        p.drawPort()
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        p.savePState()

        If p.breastSize < 1 Then p.breastSize = 0
        NekoTF.snapStep6(p)

        TextEvent.fpush("You stagger before the amateur witch, as " & pronoun & " scrambles to pull out a small notebook." & DDUtils.RNRN &
                        """Let's see..."" " & pronoun & " says, quickly flicking through the pages.  ""...if you ever beat so-and-so... cast the such-and-such...  Ok!""" & DDUtils.RNRN &
                        "The mage snaps the book shut, leveling an outstretched hand in your general direction.  ""Cataclysmic Polymorph!""" & DDUtils.RNRN &
                        DDUtils.capitalizeFirst(p_pronoun) & " spell hits you square, and you collapse to the ground in a plume of smoke as your " & DDUtils.amrOrClth(p) & " twists into cat-themed lingerie.  However, as you fall unconscious the enchanment breaks and Marissa's student jumps back with a sheepish *eep*." & DDUtils.RNRN &
                        """Umm... that was probably what was supposed to happen...  Right?""", AddressOf p.drawPort)

        TextEvent.pushLog("Marissa's Neophyte tries to transform you into a Kitty, but " & p_pronoun & " spell fails...")

        p.drawPort()
    End Sub
End Class
