Public NotInheritable Class BimboPlusTF
    Inherits BimboTF

    Private Const TF_IND As tfind = tfind.bimboplus

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimboyellow1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub
    Public Overrides Sub s1TFText(ByRef p As Player)
        TextEvent.fpush("You pause to rub your temples, as you begin to develop a massive headache." & DDUtils.RNRN &
                        "While taking a few minutes to recover, you notice that your center of balance is... off.  Hmm, you hypothesize that perhaps the vial you drank might be causing these effects." & DDUtils.RNRN &
                        "You may be able to just walk this off...")
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        haircolor = "platinum blonde"
        If Not p.prt.sexBool Then
            out += "In a moment of profound mental clarity, you look down to see breasts blossoming from your chest.  You smirk; despite looking like a typical brainless bimbo you seem to be far more intellegent than you were before." & DDUtils.RNRN &
                   "As your dainty hands move down your body, you discover that you no longer have a cock and balls, finding instead a tight and moist pussy.  Your hair lengthens, becoming a " & haircolor & ", as your " & DDUtils.amrOrClth(p) & " warps and reweaves itself to match your new figure." & DDUtils.RNRN &
                   "While your transformation supports your hypothesis that BIM_II is used in those ""magic"" sticks of gum, your increased IQ hints that there may be another compound involved..."
            p.MtF()
        ElseIf p.prt.sexBool And p.breastSize < 3 Then
            out += "In a moment of profound mental clarity, you look down at your tits as they swell and jiggle.  You smirk; despite looking like a typical brainless bimbo you seem to be far more intellegent than you were before." & DDUtils.RNRN &
                   "Your hair lengthens, becoming a " & haircolor & ", as your " & DDUtils.amrOrClth(p) & " warps and reweaves itself to match your new figure." & DDUtils.RNRN &
                   "While your transformation supports your hypothesis that BIM_II is used in those ""magic"" sticks of gum, your increased IQ hints that there may be another compound involved..."
        ElseIf p.prt.sexBool And p.breastSize >= 3 Then
            out += "In a moment of profound mental clarity, you smirk; despite looking like a typical brainless bimbo you seem to be far more intellegent than you were before.  Your hair lengthens, becoming a " & haircolor & ", as your " & DDUtils.amrOrClth(p) & " warps and reweaves itself to match your new figure." & DDUtils.RNRN &
                   "While your transformation supports your hypothesis that BIM_II is used in those ""magic"" sticks of gum, your increased IQ hints that there may be another compound involved..."
        End If
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimboyellow2
        p.prt.setIAInd(pInd.rearhair, 6, True, True)
        p.prt.setIAInd(pInd.midhair, 6, True, True)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        If p.name <> "Targax" Then
            p.prt.setIAInd(pInd.eyes, 34, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 16, True, True)
        End If

        p.prt.setIAInd(pInd.mouth, 6, True, True)
        If p.inv.getCountAt("Small_Glasses") < 1 Then p.inv.add("Small_Glasses", 1)
        EquipmentDialogBackend.glassesChange(p, "Small_Glasses")
    End Sub
    Overrides Sub s2WrapUp(ByRef p As Player, ByRef out As String)
        p.changeClass("Bimbo++")
        p.textColor = Color.FromArgb(255, 255, 235, 240)
        p.perks(perk.bimbotf) = -1
        'p.drawPort()
        TextEvent.fpush(out)
    End Sub

    'Alternate Step 2
    Overrides Sub step2alt()
        Dim p As Player = Game.player1

        '| -- Body TF -- |
        p.breastSize = 3
        p.addLust(10)

        '| -- Hair TF -- |
        p.prt.haircolor = Color.FromArgb(255, 255, 250, 205)
        p.prt.setIAInd(pInd.rearhair, 10, True, True)
        p.prt.setIAInd(pInd.midhair, 10, True, True)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)

        '| -- Face TF -- |
        p.prt.setIAInd(pInd.ears, 0, True, True)
        p.prt.setIAInd(pInd.mouth, 6, True, True)
        p.prt.setIAInd(pInd.eyes, 34, True, True)

        '| -- Misc TF -- |
        p.prt.setIAInd(pInd.hairacc, 3, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, True)
        If p.inv.getCountAt("Small_Glasses") < 1 Then p.inv.add("Small_Glasses", 1)
        EquipmentDialogBackend.equipGlasses(p, "Small_Glasses")
        If p.inv.getCountAt("Magical_Slut_Outfit") < 1 Then p.inv.add("Magical_Slut_Outfit", 1)
        EquipmentDialogBackend.equipArmor(p, "Magical_Slut_Outfit")

        TextEvent.fpush("You immediately feel funny, as the increased concentration of magic in your system reacts swiftly with the chemical." & DDUtils.RNRN &
                        "In a moment of profound mental clarity, you smirk; despite looking like a typical brainless bimbo you are far more intellegent than you were before.  Your hair shifts colors to a platinum blonde, as your " & DDUtils.amrOrClth(p) & " warps and reweaves itself to match your new figure." & DDUtils.RNRN &
                        "While your transformation supports your hypothesis that BIM_II is used in those ""magic"" sticks of gum, your increased IQ hints that there may be another compound involved...")
        p.TextColor = Color.HotPink
        p.perks(perk.bimbotf) = -1
        stopTF()
    End Sub
End Class
