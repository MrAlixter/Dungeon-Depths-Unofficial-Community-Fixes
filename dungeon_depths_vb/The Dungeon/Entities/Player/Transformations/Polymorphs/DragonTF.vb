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
        turns_until_next_step = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getmaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As player = Game.player1
        Dim out = ""

        'unequips
        EquipmentDialogBackend.armorChange(p, "Naked")
        EquipmentDialogBackend.weaponChange(p, "Fists")

        'dragon transformation
        p.learnSpell("Dragon's Breath")

        'transformation description push
        p.TextColor = Color.LightGreen
        out += "You can feel green scales begin to cover most of your body, as another wave of mana washes over you.  As your new scales begin to thicken, you are forced down onto all fours, and a quick glance back confirms that you now have grown considerably, as well as now have a thick reptilian tail, an a proper set of dragon wings, colored the same color green as the rest of your body. After your face finishes extending into a snout, and you feel the last of the changes stop, it finally hits you. You are now a dragon."

        TextEvent.push(out)
    End Sub

    Public Sub step1Full()
        Dim p As Player = Game.player1
        Dim out = ""

        'unequips
        EquipmentDialogBackend.armorChange(p, "Naked")
     
        'dragon transformation
        p.learnSpell("Dragon's Breath")

        'transformation description push
        p.textColor = Color.LightGreen
        out += "You can feel green scales begin to cover most of your body, as another wave of mana washes over you.  As your new scales begin to thicken, you are forced down onto all fours, and a quick glance back confirms that you now have grown considerably, as well as now have a thick reptilian tail, an a proper set of dragon wings, colored the same color green as the rest of your body. After your face finishes extending into a snout, and you feel the last of the changes stop, it finally hits you. You are now a dragon."

        TextEvent.push(out)

        Game.player1.changeForm("Dragon")
    End Sub

    Public Shared Sub halfDragonRTF()
        Game.player1.changeHairColor(BroodmotherTF.hc)
        Game.player1.changeSkinColor(BroodmotherTF.sc)
        Game.player1.changeForm("Half-Dragon (R)")
    End Sub
End Class
