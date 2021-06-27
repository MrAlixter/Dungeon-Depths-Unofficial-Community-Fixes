Public NotInheritable Class MagMimicTF
    Inherits MagSlutTF

    Protected Shadows Const className As String = "Magical Slut"
    Private Const TF_IND As tfind = tfind.maggirlmimic

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub step1dialog(ByRef p As Player)
        Dim out = "Swinging your wand, you are engulfed in a rain of hearts. As the light around your body grows blinding and your clothes disolve into the aether, you become a increadibly busty young woman wearing next to nothing!  "

        out += "Scoffing, you tug at your outfit, unable to remove it.  You try to throw the wand across the dungeon, only for a tendril to flick out and wrap itself around your hand.  Grumbling to yourself, you stomp your feet before setting back out, tugging down on your new skirt in a failing attempt to preserve some of your dignity."

        Game.pushLblEvent(out, AddressOf step2)
        p.TextColor = Game.lblEvent.ForeColor
    End Sub

    Overrides Sub tfBody(ByRef p As Player)
        p.prt.haircolor = Color.FromArgb(255, 105, 58, 132)

        p.prt.setIAInd(pInd.rearhair, 20, True, True)
        p.prt.setIAInd(pInd.midhair, 10, True, True)
        p.prt.setIAInd(pInd.fronthair, 30, True, True)

        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.face, 0, True, False)

        p.prt.setIAInd(pInd.eyes, 26, True, True)
        p.prt.setIAInd(pInd.mouth, 20, True, True)

        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)

        p.prt.setIAInd(pInd.hat, 0, True, False)
    End Sub
    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(170).count < 1 Then p.inv.add(170, 1)

        Equipment.accChange(p, "Nothing")
        Equipment.clothesChange(p, "Magical_Slut_Outfit")
    End Sub

    Overrides Sub setSpells(ByRef p As Player)
        If Not p.knownSpells.Contains("Tentacle Crushcannon") Then p.knownSpells.Add("Tentacle Crushcannon")
        Game.pushLstLog("'Tentacle Crushcannon' spell learned!")
    End Sub

    Public Overrides Sub fullTF(ByRef p As Player)
        p.equippedWeapon.onUnequip(p)

        tfBody(p)
        tfClothes(p)
        setSpells(p)

        p.equippedWeapon = p.inv.item("Magical_Mimic_Wand​")
    End Sub
End Class
