Public NotInheritable Class CynnTonicTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.cynntonic

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Public Shared Sub blowupCynnTFAlt()
        Dim p = Game.player1

        p.pClass = New Classless
        p.changeForm("Blow-Up Cynn")

        p.perks(perk.polymorphed) = p.perks(perk.cynnstonic) / 6

        TextEvent.push("Your arms and legs return, along with your ability to move!" & DDUtils.RNRN &
                       "Despite the less restrictive form, you are still a succubus-shaped sex doll, though...")

        p.currState.save(p)
    End Sub
    Public Shared Sub blowupCynnTF()
        Dim p = Game.player1

        p.pClass = New Classless
        p.changeForm("Blow-Up Cynn")

        p.perks(perk.polymorphed) += p.perks(perk.cynnstonic) / 6

        TextEvent.push("The charged XP surges into you..." & DDUtils.RNRN &
                       "With a sudden *poof*, you fall to the ground as a succubus-shapped sex doll!  Fortunately you can still pick yourself up...")

        p.drawPort()
        p.UIupdate()
    End Sub

    Public Shared Sub cynnOnaholeTF()
        Dim p = Game.player1

        p.changeForm("Succubus")
        p.changeClass("Cynn Onahole")

        p.petrify(Color.Pink, 6)

        TextEvent.push("The overcharged XP surges into you..." & DDUtils.RNRN &
                       "With a sudden *poof*, you fall to the ground as a succubus-shapped sex toy!  Without arms or legs, all you can do is lie there...")

        p.drawPort()
        p.UIupdate()
    End Sub

    Public Shared Sub onaholeTF()
        Dim p = Game.player1

        p.changeClass("Onahole")
        p.deLevel(p.level)
        p.xp = 0

        Dim metCynn As Boolean = p.perks(perk.cynnsq1ct2) > -1
        TextEvent.push("The overcharged XP surges into you, and with a sudden *poof* you are transformed into an inanimate sex toy!" & DDUtils.RNRN &
                       "You plop into the waiting hand of a " & If(metCynn, "familiar ", "") & "scarlet demoness, who now towers over you.  She giggles, hefting your pink new body." & DDUtils.RNRN &
                       """Aww, did someone drink too much?"" she says, raising your " & If(p.dickSize < 0, "", "new ") & "pussy up for a closer inspection.  ""Eh, it happens to the best of us.  In fact, I'm a little thirsty myself...""" & DDUtils.RNRN &
                       "Her tongue flicks into your synthetic folds, and with a burst of ecstatic pleasure you can feel your XP begin to drain." & DDUtils.RNRN &
                       "On some level, you know you should be worried, but her lips; her twisting tongue, they just feel so... perfect.  Waves of needy warmth wash through you, becoming more and more intense as your arousal overwhelms what senses you have left.  Finally, as you feel the heat building, burning, becoming more than you can bear... she stops." & DDUtils.RNRN &
                       "No release comes, and she simply licks her lips before tossing you away.", AddressOf onaholeTF2)

        p.drawPort()
        p.UIupdate()
    End Sub
    Private Shared Sub onaholeTF2()
        If Game.player1.perks(perk.cynnsq1ct2) > -1 Then
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(150), """Hmm... So much for being a useful asset...""" & DDUtils.RNRN &
                                                                  "Cynn struts off, leaving you transformed and helpless; little more than an artificial vagina." & DDUtils.RNRN &
                                                                  """Well, a useful asset to me, at least...""" & DDUtils.RNRN &
                                                                  "GAME OVER!", AddressOf Game.player1.die)
        Else
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(76), """Hmm... Coulda used a few more levels...""" & DDUtils.RNRN &
                                                                  "Cynn chuckles, leaving you transformed and helpless on the dungeon floor." & DDUtils.RNRN &
                                                                  """Don't worry, I'm sure you'll find a loving owner... sooner or later...  Hey, maybe they'll even be able to turn you back, right?""" & DDUtils.RNRN &
                                                                   """'Course... there's also a lot of horny monsters roaming around...""" & DDUtils.RNRN &
                                                                  "GAME OVER!", AddressOf Game.player1.die)
        End If

    End Sub
End Class
