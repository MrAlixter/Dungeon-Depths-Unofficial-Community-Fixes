Public NotInheritable Class DragonTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.dragonpolymorph

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
        Dim p As player = Game.player1
        turns_until_next_step = Math.Max(5, (Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL)) * 0.15)
    End Sub

    Public Overrides Sub step1()
        Dim p As player = Game.player1

        'unequips
        p.changeForm("Dragon")
        EquipmentDialogBackend.armorChange(p, "Naked") 

        'dragon transformation
        p.learnSpell("Dragon's Breath")

        'transformation description push
        p.TextColor = Color.LightGreen
    End Sub

    Public Overrides Function getTFText() As String
        Return "Green scales begin to cover your arms; spreading in waves across the rest of your body with a surge of mana.  As your new scales begin to thicken, you are forced down onto all fours." & DDUtils.RNRN &
               "A quick glance back over your shoulder confirms that you now have grown considerably.  A thick reptilian tail and a proper set of dragon wings take shape on your back, each colored the same color green as the rest of your body." & DDUtils.RNRN &
               "After your face extends into a snout and the last of the changes reach their end, it hits you:" & DDUtils.RNRN &
               "You are now a dragon."
    End Function

    Public Sub step1Full()
        Dim p As Player = Game.player1
        Dim out = ""

        'unequips
        EquipmentDialogBackend.armorChange(p, "Naked")
     
        'dragon transformation
        p.learnSpell("Dragon's Breath")

        'transformation description push
        p.textColor = Color.LightGreen
        out += getTFText()

        TextEvent.push(out)

        Game.player1.changeForm("Dragon")
    End Sub

    Public Shared Sub halfDragonRTF()
        Game.player1.changeForm("Half-Dragon (R)")
        Game.player1.changeHairColor(BroodmotherTF.hc)
        Game.player1.changeSkinColor(BroodmotherTF.sc)
    End Sub
End Class
