Public NotInheritable Class LolitaSTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.slolita

    Sub New()
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()
        'Author Credit: Big Iron Red

        Dim p As Player = Game.player1
        Dim out = ""

        '| -- Class TF -- |
        If Not p.pClass.revertPassage.Equals("") Then out = p.pClass.revertPassage & DDUtils.RNRN
        p.changeClass("Maiden")

        '| -- TF Text -- |
        out += "As you snack on yet another cupcake, you notice that your bites into them have become smaller and smaller.  Pulling yourself out of your reverie, you notice a crimson stain on the inside of your most recent pastry." & DDUtils.RNRN &
               """Am I bleeding?"" you think, pulling the cupcake back.  That shade of red, you realize, it looks more like... lipstick?  As your hand moves further into view, you notice it is now clad in pink satin!  "

        If (p.equippedArmor.getSlutVarInd <> -1) And Not p.className.Equals("Maiden") And Not p.className.Equals("Princess") Then
            out += "Panicking, you look down; only to find your sight obscured by fluffy blonde locks and a mass of pastel-colored frills and ribbons." & DDUtils.RNRN &
                   """E-E-EEEEEEEK!""" & DDUtils.RNRN
        Else
            out += "You look down to see what else has changed; only to find your sight obscured by fluffy blonde locks and a mass of pastel-colored frills and ribbons." & DDUtils.RNRN &
                   """E-E-EEEEEEEK!""" & DDUtils.RNRN
        End If

        If p.prt.sexBool = False And p.sex.Equals("Male") And p.sState.sex.Equals("Male") And p.isUnwilling Then
            out += "You let out a shrill, girlish cry, and cover your mouth in surprise at your voice; no longer a manly baritone, but a high-pitched soprano, like some sort of little girl!  You look downward again in trepidation, to examine your new wardrobe..." & DDUtils.RNRN &
                   "Your new dress is quite possibly the most feminine thing you've ever seen, covered in bows, ribbons, and lace.  The top wraps comfortably around your new pair of modest breasts.  ""That’s all?"" you think, then realize that you were just disappointed at the size of your bust.  Trying to banish such thoughts, you look downwards further." & DDUtils.RNRN &
                   "The dress expands out into an voluminously poofy skirt, which, after a closer inspection, you find is concealing a pair of snugly fit panties emblazoned with hearts and ribbons.  Upon closer inspection, the lack of resistance all but confirms your fears." & DDUtils.RNRN &
                   """Oh, gods.  I’m a girl now...  What if I can’t change back?  I can’t live looking like this!""" & DDUtils.RNRN &
                   "Trying to distract yourself from the potenial future, you continue your inspection.  Your legs are tightly wrapped by pink sheer stockings, leading down to a pair of white heels; perfectly matching the lace of your dress.  Despite the height added by the heels, you notice your eyeline is lower than before.  You weren't exceptionally tall as a man, but now you're petite even in heels!" & DDUtils.RNRN &
                   "As you reach behind you, you find something blocking your way. You failed to realize that your transformation also gave you an absurdly large and feminine pair of twin-tails, topped off by ribbons as big as your head." & DDUtils.RNRN &
                   "Pulling out a pocket mirror to get a closer inspection, you realize that your face is covered in makeup!  You look like a model, with unguents, powders and cosmetics applied in every way possible, enhancing your newfound femininity.  You can’t even blink without your fake eyelashes fluttering, feeling the weight of them as you do.  As a final insult, any attempt to remove your new trappings is met with an invisible resistance, leaving you quite literally locked in lace!" & DDUtils.RNRN &
                   """I'm stuck in this dress?! I can't even run away now, if I try to return home looking like this, I'll be mistaken for a wayward nobles daughter... or a slightly oversized doll..."" you think, your face almost as pink as your dress due to your humiliation." & DDUtils.RNRN &
                   "You attempt to continue on, finally finding that your new body forces you to sashay your hips to move properly with your new center of gravity..."
        ElseIf p.prt.sexBool = False And p.sex.Equals("Male") And p.sState.sex.Equals("Male") Then
            out += "You let out a shrill, girlish cry and cover your mouth in surprise at your voice, which seems a full octave higher than it used to be!  You look downward again in trepidation, to examine your new wardrobe..." & DDUtils.RNRN &
                   "Your new dress is quite possibly the most feminine thing you've ever seen, covered in bows, ribbons, and lace.  The top wraps comfortably around your new pair of modest breasts.  ""That’s all?"" you think, then realize that you were just disappointed at the size of your bust.  Trying to banish such thoughts, you look downwards further." & DDUtils.RNRN &
                   "The dress expands out into an voluminously poofy skirt, which, after a closer inspection, you find is concealing a pair of snugly fit panties emblazoned with hearts and ribbons." & DDUtils.RNRN &
                   "Your legs are tightly wrapped by pink sheer stockings, leading down to a pair of white heels; perfectly matching the lace of your dress." & DDUtils.RNRN &
                   "As you reach behind you, you find something blocking your way. You failed to realize that your transformation also gave you an absurdly large and feminine pair of twin-tails, topped off by ribbons as big as your head." & DDUtils.RNRN &
                   "Pulling out a pocket mirror to get a closer inspection, you realize that your face is covered in makeup!  You look like a model, with unguents, powders and cosmetics applied in every way possible, enhancing your newfound femininity.  You can’t even blink without your fake eyelashes fluttering, feeling the weight of them as you do." & DDUtils.RNRN &
                   "You attempt to continue on, finally finding that your new body forces you to sashay your hips to move properly with your new center of gravity..."
        Else
            out += "You let out a shrill cry and cover your mouth in surprise at your voice, which seems a full octave higher than it used to be!  You look downward again in trepidation, to examine your new wardrobe..." & DDUtils.RNRN &
                   "Your new dress is quite possibly the most feminine thing you've ever seen, covered in bows, ribbons, and lace. The top wraps comfortably around your pair of "

            If p.breastSize < 1 Then
                out += "modest breasts.  Although you don't strip down to check, from the sensation of squirming fabric you can only assume that you are also now wearing an equally frilly bra.  Trying to banish such thoughts, you look farther past your chest." & DDUtils.RNRN
            Else
                out += "now-modest breasts.  As your outfit continues to morph, you can only assume that your bra is now frilly as well.  It begins to tighten, and a quick flash of dissapointment crosses your mind.  Trying to banish such thoughts, you look farther past your chest." & DDUtils.RNRN
            End If

            out += "The dress expands out into an voluminously poofy skirt, which, after a closer inspection, you find conceals a pair of snugly fit panties emblazoned with hearts and ribbons.  Your legs are tightly wrapped by pink sheer stockings, leading down to a pair of white heels; perfectly matching the lace of your dress.  While femininity isn't exactly new for you, between your new voice, poofy dress, and bashful demeanor you're far ""girlier"" than before." & DDUtils.RNRN

            If p.isUnwilling Then
                out += """Hopefully I don't need to run anywhere anytime soon..."" you grumble as you grasp your dress, pulling it off the floor and setting back out on your way."
            Else
                out += """Ooh, it would be such a shame to ruin such a pretty outfit..."" you sigh as you grasp your dress, pulling it off the floor and setting back out on your way with newfound grace."
            End If
        End If

        TextEvent.fpush(out)

        '| -- Hair TF -- |
        p.prt.haircolor = Color.FromArgb(255, 227, 201, 153)
        p.prt.setIAInd(pInd.rearhair, 28, True, True)
        p.prt.setIAInd(pInd.fronthair, 29, True, True)
        p.prt.setIAInd(pInd.hairacc, 1, True, False)

        '| -- Face TF -- |
        p.prt.setIAInd(pInd.face, 7, True, True)
        p.prt.setIAInd(pInd.midhair, 31, True, True)

        If p.isUnwilling Or (p.prt.sexBool = False And p.sex.Equals("Male") And p.sState.sex.Equals("Male")) Then
            p.prt.setIAInd(pInd.mouth, 19, True, True)
            p.prt.setIAInd(pInd.eyes, 37, True, True)
        Else
            p.prt.setIAInd(pInd.mouth, 6, True, True)
            p.prt.setIAInd(pInd.eyes, 41, True, True)
        End If

        '| -- Body TF -- |
        If p.sex.Equals("Male") Then p.MtF()
        p.breastSize = 0
        p.buttSize = 0

        '| -- Misc TF -- |
        p.addLust(70)
        If p.inv.getCountAt(SLolitaDress.ITEM_NAME) < 1 Then p.inv.add(SLolitaDress.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, SLolitaDress.ITEM_NAME)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
