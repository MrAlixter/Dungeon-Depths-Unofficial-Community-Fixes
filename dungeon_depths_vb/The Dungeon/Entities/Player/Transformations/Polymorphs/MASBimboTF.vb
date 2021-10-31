Public NotInheritable Class MASBimboTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.marissasbimbo

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As Player = Game.player1
        turns_until_next_step = Int(Rnd() * 30) - Int(Rnd() * p.getWIL)
        If turns_until_next_step < 5 Then turns_until_next_step = 5
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1
        Dim out = ""

        'unequips
        If p.inv.item(147).count < 1 Then p.inv.add(147, 1)
        EquipmentDialogBackend.armorChange(p, "Skimpy_Tube_Top")

        'bimbo transformation
        If Not p.prt.sexBool Then
            out += "In your haze, you look down to see breasts blossoming from your chest. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. As your dainty hands move down your body, you discover that you no longer have a cock and balls, and insted have a tight moist cunt.  Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
            p.MtF()
        ElseIf p.prt.sexBool And p.breastSize < 3 Then
            out += "In your haze, you look down at your tits. You, like, never noticed how round and big they had got. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
        ElseIf p.prt.sexBool And p.breastSize >= 3 Then
            out += "In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure."
        End If

        p.prt.haircolor = Color.FromArgb(255, 255, 245, 200)
        p.prt.setIAInd(pInd.rearhair, 14, True, True)
        If p.breastSize < 3 Then p.breastSize = 3
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 6, True, True)
        p.prt.setIAInd(pInd.ears, 1, True, False)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 6, True, True)
        p.prt.setIAInd(pInd.eyes, 8, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 19, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        'transformation description push
        TextEvent.push(out)
    End Sub
    Public Sub step2()
        Game.fromCombat()

        Dim p As Player = Game.player1
        p.prt.setIAInd(pInd.rearhair, 12, True, True)
        p.prt.setIAInd(pInd.midhair, 17, True, True)
        p.prt.setIAInd(pInd.fronthair, 1, True, False)
        p.prt.setIAInd(pInd.ears, 1, p.prt.sexBool, False)
        p.prt.setIAInd(pInd.mouth, 9, True, True)
        If p.breastSize > 0 And p.breastSize < 4 Then
            If p.inv.item("Cat_Lingerie").count < 1 Then p.inv.add("Cat_Lingerie", 1)
            EquipmentDialogBackend.armorChange(p, "Cat_Lingerie")
        End If
        TextEvent.push("In your weakened state, you are helpless to defend yourself as Marissa charges up a glowing ball of magic.\n\n" &
                          """This is a little curse I've been working on..."" she states, gesturing at your prone body with the tip of her staff.  ""I haven't used the finished version of it on anyone yet, but I have a feeling that you're going to be my perfect little test kitty!""\n\n" &
                          "With that, she flicks her staff your direction, and a tingling sensation erupts throughout your body.  Blushing, you can feel a burning between your legs, and as a lustful haze settles over your weakened mind, the tingling just ... stops.  Confused, you glance behind you at Marissa with an expectant glare.  She, to your surprise, also seems to be confused about this turn of events.  As you begin to pull yourself to your feet, her gaze turns cold and she mutters something about you probably not making a cute kitty anyway before storming off.\n\n" &
                          "As you watch her walk off, part of you wants to get down on your hands and knees and follow her, although the majority is glad this version of Marissa seemed to be so inexperienced.")
        p.drawPort()
    End Sub
End Class
