Public Class EImp
    Inherits ESuccubus

    Public Shadows Const BASE_NAME As String = "Imp"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 33
        attack = 16
        defense = 33
        speed = 66
        will = 13

        levelDrainThres = 2
        lustRaiseThres = 100
        levelsToDrain = Int(Rnd() * 2)
        lustToIncrease = Int(Rnd() * 20) + 6

        '|Inventory|
        setInventory({74, 168, 182, 194, 227, 451})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub sapLevel(ByRef t As Entity)
        If Not t.getPlayer Is Nothing Then sapPlayer(t.getPlayer) Else sapEntity(t)

        maxHealth *= 1.6
        attack *= 1.6
        defense *= 1.6
        speed *= 1.6

        TextEvent.fpushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " used Drain Soul!  " & levelsToDrain & " levels drained!")
    End Sub

    Public Overrides Sub sapPlayer(ByRef p As Player)
        drainedXP += p.deLevel(levelsToDrain)
        If Not explainedDrain Then TextEvent.pushAndLog("Defeat " & getNameWithTitle() & " to regain your lost XP!") : explainedDrain = True
    End Sub
    Public Overrides Sub sapEntity(ByRef e As Entity)
        e.maxHealth *= 0.8
        e.attack *= 0.8
        e.defense *= 0.8
        e.maxMana *= 0.8
        e.speed *= 0.8
        e.will *= 0.8
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        Dim p1 As Player = p

        TextEvent.fpush(DDUtils.capitalizeFirst(getNameWithTitle) & " cackles as you collapse, defeated." & DDUtils.RNRN &
                        """Wow, you sure didn't put up much of a fight.  Really know how to make an imp feel special, yeah?""" & DDUtils.RNRN &
                        DDUtils.capitalizeFirst(pronoun) & " looks to your belongings, with a cocky grin.  ""Now, let's see if you've got anything good on ya...""", Sub() playerDeathP2(p1))
    End Sub

    Public Sub playerDeathP2(ByRef p As Player)
        'turn vial of slime into pink slime, cover the player in it
        'turn cowbell/bimbell into ring of the cow
        Dim out As String = """Eh... so what's this here?""" & DDUtils.RNRN

        Dim selectedGum As Item = GumGun20mm.getSelectedGum(p)
        If p.inv.getCountAt(VialOfSlime.ITEM_NAME) > 0 Then
            out += DDUtils.capitalizeFirst(pronoun) & " holds up a " & VialOfSlime.ITEM_NAME & ", gently rotating the glass container.  As she watches the fluid within rotate, her smile widens into a sinister grin." & DDUtils.RNRN &
                "The teal of the slime bubbles into a brilliant pink." & DDUtils.RNRN &
                """Now that's the good stuff, yeah?  Don't be shy; this one's on me.""" & DDUtils.RNRN &
                "-1 " & VialOfSlime.ITEM_NAME & DDUtils.RNRN &
                "+1 " & VialOfPSlime.ITEM_NAME

            p.inv.item(VialOfSlime.ITEM_NAME).add(-1)
            p.inv.item(VialOfPSlime.ITEM_NAME).add(1)

            p.UIupdate()
        ElseIf selectedGum.count > 0 Then
            out += DDUtils.capitalizeFirst(pronoun) & " holds up a " & selectedGum.getAName() & ", squeezing it between " & p_pronoun & " fingers as " & p_pronoun & " smile widens." & DDUtils.RNRN &
                   """You got a sweet tooth or somethin'?  How'd you like to get a lil' taste..."" " & pronoun & " says, as the gum begins to spark and sizzle, ""...of something spicy; straight from hell?""" & DDUtils.RNRN &
                   DDUtils.capitalizeFirst(getNameWithTitle) & " brings it up to your lips, despite your feeble resistance.  ""Oh, don't worry... I'm sure you'll love it...""" & DDUtils.RNRN
            selectedGum.add(-1)

            If p.className.Contains("Bimbo") Then
                out += "You pout, before rolling your eyes and eating the stick of gum.  The warm taste of cinnamon coats your tounge, but you- like, basically feel the same."
            Else
                out += "Your eyes glaze over as something compels you to eat the stick of gum.  The warm taste of cinnamon fills your mouth, accompanied by a strange, dizzy calm..."

                p.ongoingTFs.add(New CinnamonBimboTF(2, 5, 0.25, True))
                p.perks(perk.bimbotf) = 0
            End If
        ElseIf p.inv.getCountAt(VialOfPSlime.ITEM_NAME) > 0 Then

        Else
            out = """Ugh, not seeing any gum or slime... How's that even possible?  Are ya getting rid of them, or something?""" & DDUtils.RNRN &
                   DDUtils.capitalizeFirst(getNameWithTitle) & " sighs, before drawing forth a silver flask and dropping it into your belongings." & DDUtils.RNRN &
                   """Doesn't matter, I guess." & DDUtils.RNRN &
                   "That draught's a little somethin' us imps brewed up for weirdos like you- just a sip or two oughta make you more fun."" " & pronoun & " says with a mischevious giggle." & DDUtils.RNRN &
                   """Give it a shot when it calls to ya, yeah?""" & DDUtils.RNRN & DDUtils.RNRN &
                   "+1 " & ImpsDraught.ITEM_NAME

            p.inv.add(ImpsDraught.ITEM_NAME, 1)
        End If

        TextEvent.fpush(out)
    End Sub
End Class
