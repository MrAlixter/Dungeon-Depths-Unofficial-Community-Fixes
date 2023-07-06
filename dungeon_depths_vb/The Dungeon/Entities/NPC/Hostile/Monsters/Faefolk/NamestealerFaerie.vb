Public Class NamestealerFaerie
    Inherits FaerieEnemy

    Public Shadows Const BASE_NAME As String = "Namestealer Faerie"

    Private deducedName As String = ""
    Private testedName As Boolean = False

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 60
        attack = 5
        defense = 20
        speed = 60
        will = 30

        '|Inventory|
        Dim r As Integer = Int(Rnd() * 3)
        inv.add(VialOfManyNames.ITEM_NAME, r + 1)
        If Int(Rnd() * 3) = 0 Then inv.add(Tulip.ITEM_NAME, 1)

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Protected Overrides Function pDeathEffect(ByRef p As Player) As String
        If Transformation.canBeTFed(p) And Not p.formName.Contains("Fae") Then
            Dim oldform = p.formName.ToString

            p.ongoingTFs.add(New FaerieTF())
            p.update()

            Return """Oh!  How about we swap?  I'll be the " & oldform & ", and you'll be the Faerie!  That's perfect! ~♥"" " & pronoun & " exclaims, flying around you in a tight spiral of twinkly dust." & DDUtils.RNRN &
             "The fairy cackles as her spell begins its work, the world seeming to rise up around you as you dwindle in height and " & pronoun & " grows larger and larger.  With a sparkly shimmer, her wings vanish into mist as you suddenly find yourself flitting upwards on a pair of your own." & DDUtils.RNRN &
             """Hey, big- er, little " & If(p.sex.Equals("Male"), "guy", If(p.sex.Equals("Female"), "gal", "pal")) & ", you look way better from up here!"""
        Else
            p.name = Polymorph.rndBimName(p)
            p.UIupdate()
            Return """Yep, this is a toughie...  Not much I can do to you at the moment any way I look at it...""" & DDUtils.RNRN &
                   DDUtils.capitalizeFirst(pronoun) & " snaps her tiny fingers, flashing you a smug grin." & DDUtils.RNRN &
                   """Well, not much apart from- heh, this.  A more fitting name for someone like you, no?"""
        End If
    End Function

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If deducedName.Equals(target.name) And Not testedName Then
            TextEvent.push("""" & DDUtils.capitalizeFirst(target.name) & ", " & DDUtils.capitalizeFirst(target.name) & ", huh?  If you're really " & DDUtils.capitalizeFirst(target.name) & "..."" says the " & BASE_NAME & ", ""... take off your clothes!""")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " tests the name " & pronoun & " deduced...")

            Game.player1.nextCombatAction = AddressOf PerkEffects.namestealerStun

            testedName = True

            Exit Sub
        ElseIf deducedName.Equals(target.name) Then
            Game.fromCombat()
            TextEvent.push("The " & BASE_NAME & " cackles maniacally." & DDUtils.RNRN &
                           """" & target.getName.ToUpper & "!  BOW TO YOUR NEW GODDESS!""", AddressOf pDeath)
            Exit Sub
        End If

        MyBase.attackCMD(target)
    End Sub

    Private Sub pDeath()
        Game.player1.die(Me)
    End Sub

    Public Overrides Function shouldCastSpell(ByRef p As Player) As Boolean
        Return perks(npc_perk.tfdur) < 1 And Game.turn Mod 2 = 0
    End Function

    Public Overrides Sub castSpell(ByRef p As Player)
        Dim deduction = p.name.Substring(deducedName.Length, Math.Min(2, p.name.Length - deducedName.Length))

        If p.perks(perk.vofmanynames) > 0 Then
            Dim falseDeduction = DDUtils.rndAlpha & DDUtils.rndAlpha

            While falseDeduction.Equals(deduction)
                falseDeduction = DDUtils.rndAlpha & DDUtils.rndAlpha
            End While

            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!  " & DDUtils.capitalizeFirst(pronoun) & " learned that your name contains """ & falseDeduction & """" & DDUtils.RNRN &
                           """Nah, that isn't right...""")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!")

            p.perks(perk.vofmanynames) -= 1

            Exit Sub
        ElseIf p.perks(perk.vofmanynames) <> -1 Then
            p.perks(perk.vofmanynames) = -1
        End If

        TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!  " & DDUtils.capitalizeFirst(pronoun) & " learned that your name contains """ & deduction & """")
        TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!")

        deducedName += deduction
    End Sub
End Class
