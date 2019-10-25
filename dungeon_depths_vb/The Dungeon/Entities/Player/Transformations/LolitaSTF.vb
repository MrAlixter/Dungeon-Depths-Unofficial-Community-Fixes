Public Class LolitaSTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "LolitaSTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "LolitaSTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()

        Dim p As Player = Game.player

        Dim out = ""

        p.pClass.revert()
        out = p.pClass.revertPassage & vbCrLf & vbCrLf
        p.pClass = p.classes("Maiden")

        'transformation description push
        If p.prt.sexBool = False Then
            'Credit for this passage goes to Big Iron Red
            out += "As your repeated snackings on cupcakes continue, you notice that your bites into them have become smaller and smaller. As you pull yourself out of your reverie, you notice a stain on the bitemark of your most recent snack.\n\n" &
                   """Am I bleeding?"" you think, pulling the cupcake back. As you do, you realize it looks like... lipstick? As your view widens, you notice your hand is clad in pink satin! Panicking, you look down, and find your view obscured by fluffy blonde locks, and filled with enough pink to make a unicorn puke!\n\n" &
                   """E-E-EEEEEEEK!""\n\n" &
                   "You let out a shrill, girlish cry, and cover your mouth in surprise at your voice, no longer a manly baritone, but a high-pitched soprano, like some sort of little girl! You look downward again in trepidation, to examine your new wardrobe.\n\n" &
                   "Your new dress is quite possibly the most feminine thing you've ever seen, covered in bows, ribbons, and lace. The top is covering a pair of modest breasts. ""That’s all?"" you think, then realize that you were just disappointed at the size of your breasts. Trying to banish the thought, you look farther past them.\n\n" &
                   "The dress expands out into an expansively fluffy skirt, which, after a closer inspection, you find is concealing a pair of snugly fit panties emblazoned with hearts and ribbons. Upon closer inspection, the lack of resistance all but confirms your fears.\n\n" &
                   """Oh, gods. I’m a girl now… What if I can’t change back? I can’t live looking like this!""\n\n" &
                   "Trying not to think about your future, you continue your inspection. Your legs are tightly wrapped by pink sheer stockings, finally topped off with a pair of white heels, perfectly matching the lace of your dress. Despite the heels, you notice your view is lower than average. You weren't even that tall as a man, now you're barely pushing five foot in heels!\n\n" &
                   "As you reach behind you, you find something blocking your way. You failed to realize that your transformation also gave you an absurdly large and feminine pair of twin-tails, topped off by ribbons as big as your head!\n\n" &
                   "Pulling out a mirror to get a closer inspection, you realize that your face is covered in makeup! You look like a model, with unguents, powders and cosmetics applied in every way possible, enhancing your newfound femininity. You can’t even blink without your fake eyelashes fluttering, feeling the weight of them as you do. As a final insult, any attempt to remove your new trappings is met with an invisible resistance, leaving you quite literally locked in lace!\n\n" &
                   """I'm stuck in this dress?! I can't even run away now, if I try to return home looking like this, I'll be mistaken for a wayward nobles daughter... or a slightly oversized doll..."" you think, your face almost as pink as your dress from humiliation. As you attempt to continue on, you find your new gender is forcing you to sashay your hips to move properly with your new center of gravity...\n\n"
        Else
            'Partial credit for this passage goes to Big Iron Red
            out += "As your repeated snackings on cupcakes continue, you notice that your bites into them have become smaller and smaller. As you pull yourself out of your reverie, you notice a stain on the bitemark of your most recent snack.\n\n" &
                   """Am I bleeding?"" you think, pulling the cupcake back. As you do, you realize it looks like... lipstick? As your view widens, you notice your hand is clad in pink satin! Panicking, you look down, and find your view obscured by fluffy blonde locks, and filled with enough pink to nearly blind you!\n\n" &
                   """E-E-EEEEEEEK!""\n\n" &
                   "You let out a shrill cry and cover your mouth in surprise at your voice, which is a full octave higher than it used to be! You look downward again in trepidation, to examine your new wardrobe.\n\n" &
                   "Your new dress is quite possibly the most feminine thing you've ever seen, covered in bows, ribbons, and lace. The top is covering your pair of"
            If p.breastSize < 1 Then
                out += " modest breasts.  Although you don't strip down to check, from its squirming you can only assume that you are now wearing an equally frilly bra."
            Else
                out += " now modest breasts.  As your bra reshapes and tightens, a quick flash of dissapointment crosses your mind and as your outfit continues to morph, you can only assume that your bra is now equally frilly."
            End If
            out += "  Trying to banish the thought, you look farther past your chest.\n\n" &
                   "The dress expands out into an expansively fluffy skirt, which, after a closer inspection, you find conceals a pair of snugly fit panties emblazoned with hearts and ribbons.  While femininity isn't exactly new for you, between your new voice, poofy dress, and bashful demeanor you're far ""girlier"" than before.\n\n" &
                   """Hopefully  I don't need to run anywhere anytime soon..."" you grumble as you grasp your dress, pulling it off the floor and setting back out on your way."
        End If

        'equip clothes
        p.inv.add("Lolita_Dress_(Sweet)", 1)
        Equipment.clothesChange("Lolita_Dress_(Sweet)")
        'maiden transformation
        p.prt.haircolor = Color.FromArgb(255, 227, 201, 153)
        p.prt.setIAInd(1, 28, True, True)
        p.prt.setIAInd(4, 7, True, True)
        p.prt.setIAInd(5, 31, True, True)
        p.prt.setIAInd(8, 19, True, True)
        p.prt.setIAInd(9, 37, True, True)
        p.prt.setIAInd(15, 29, True, True)
        p.breastSize = 0
        p.reverseBSRoute()
        p.prt.hBowInd = 1
        p.lust = 70

        'End If
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
