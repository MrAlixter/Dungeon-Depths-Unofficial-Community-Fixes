Public NotInheritable Class ThrallTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "ThrallTF"
        MyBase.updateDuringCombat = False
        Game.player1.perks(perk.thrall) = 0
        nextStep = AddressOf shiftTowardsPrefForm
    End Sub
    Sub New()
        MyBase.New(1, Int(Rnd() * 10) + 10, 0, False)
        tfName = "ThrallTF"
        MyBase.updateDuringCombat = False
        Game.player1.perks(perk.thrall) = 11
        nextStep = AddressOf crystalSpawn
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "ThrallTF"
        MyBase.updateDuringCombat = False
        nextStep = getNextStep(cs)
    End Sub

    Sub shiftTowardsPrefForm()
        Dim p As player = Game.player1
        p.prefForm.shiftTowards(Game.player1)
        p.perks(perk.thrall) += 1
        If p.perks(perk.thrall) > 11 Then
            p.prefForm.snapShift(Game.player1)

        End If
        MyBase.currStep -= 1
    End Sub
    Sub crystalSpawn()
        Dim p As player = Game.player1
        If p.forcedPath Is Nothing And Not Game.combatmode And Not Game.npcmode Then

            Dim crystal = Game.currfloor.randPoint

            Game.currfloor.mBoard(crystal.Y, crystal.X).Tag = 2
            Game.currfloor.mBoard(crystal.Y, crystal.X).Text = "c"

            p.forcedPath = Game.currfloor.route(p.pos, crystal)

            Dim s As String = ""
            If p.getWIL() > 10 Then
                s = "you mock your instructions under your breath, before stiffly moving towards the crystal." + DDUtils.RNRN + """If only I could get this damn collar off..."""
            ElseIf p.getWIL() > 7 Then
                s = "you reluctantly start off towards the crystal." + DDUtils.RNRN + """Oh well, better me than one of their other idiots..."""
            ElseIf p.getWIL() > 4 Then
                s = "you jump immediately into action, happy to help the voice in your head with whatever it may need." + DDUtils.RNRN + """I'm gonna make quick work of this!"""
            Else
                s = "you mindlessly obey, moving towards the crystal with a vacant grin."
            End If
            Game.pushLblEvent("As your collar flares to life, you grimace as the location of a large mana crystal becomes clear in your mind." & DDUtils.RNRN &
                              """SERVANT!"", your controller's voice booms in your head, ""This is another of the crystals!  Recover it immediately!""" & DDUtils.RNRN & _
                              "As their voice leaves your head, " & s)
        End If

        stopTF()
    End Sub
    Shared Sub postLoadCrystalSpawn(ByVal e As Entity)
        Dim p = Game.player1
        Dim crystal As Point = New Point(p.forcedPath(0).X, p.forcedPath(0).Y)
        Game.currfloor.mBoard(crystal.Y, crystal.X).Text = "c"
        p.forcedPath = Game.currfloor.route(p.pos, crystal)
        p.nextCombatAction = Nothing
    End Sub

    Shared Sub fightSorc()
        Dim p As player = Game.player1
        Dim m As Monster
        m = Monster.monsterFactory(9)

        Monster.targetRoute(m)

        Game.toCombat()
        Game.pushLstLog((m.getName() & " attacks!"))
        Game.turn += 1
    End Sub
    Shared Sub fightSorc2()
        Dim p As player = Game.player1
        Game.lblEvent.Visible = False
        Dim m As Monster
        m = Monster.monsterFactory(8)

        Monster.targetRoute(m)

        Game.toCombat()
        Game.pushLstLog((m.getName() & " attacks!"))
        Game.turn += 1
    End Sub
    Shared Sub acceptSorc()
        Dim p As player = Game.player1
        p.perks(perk.thrall) = -1
        p.ongoingTFs.Add(New HalfSuccubusTF())
        p.update()
        Game.pushLblEvent("""Then I deem your task concluded as a success.  Go now, and take care not to fall under the spell of any others,"" your controller states.")
    End Sub
    Shared Sub betraySorc()
        Dim p As player = Game.player1
        Game.pushLblEvent("Brushing past you, your ""boss"" heads straight for the array.  As they begin fiddling with it, you take notice of their distraction and begin creeping into a position behind them.  As they chant over the array, you prepare to make your move.  " & _
                          "As their raving reaches its zenith and the runes enscribed on the crystal begin to glow you strike out, disrupting their ritual.  ""YOU!  DO YOU HAVE ANY IDEA ..."" screams the mage, and while they shout you realize you couldn't care less about them.  " & _
                          "Looking down, you see that your collar has gone dark and dangles open from your neck.  Grinning, your prepare to fight for your life.", AddressOf fightSorc2)


        Equipment.accChange(p, "Nothing")
        p.inv.add(69, -1)

        p.drawPort()
    End Sub
    Shared Sub waitSorc()
        Dim out = "You decide against making a move now, instead waiting to see what happens next.  Your controller doesn't seem to notice you, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and wait, are those horns sprouting out of their hair that seems to catch a non-existant wind?  With a flourish, they complete ... something ... and a blinding flash engulfs them.  Where once stood your human controller now stands a half-demon who only now seems to have taken notice of you." & DDUtils.RNRN &
                        """Well... It looks like you succeeded.  For that, I will give you an ultimatium.  Join me as my general, or die in these dungeons as my slave."
        Game.pushLblEvent(out, AddressOf acceptSorc, AddressOf fightSorc, "Do you accept?")
    End Sub

    Shared Sub thrallLN2()
        Dim ptype = "sister"
        If Int(Rnd() * 2) = 0 Then
            ptype = "brother"
        End If
        Game.pushLblEvent("""LISTEN UP, NEW SLAVE!  I have need of your services."" your new master begins, ""In this dungeon, there are several high-power mana arrays.  Only one of them, however, is capable of bestowing the power of a demon lord onto a mortal such as I.  Your task is to find and inspect these arrays, and report back to me with your findings.""  They snicker,  ""I'm sure you won't let me down, but I'm going to need to make a few changes to make you more ... uniform ... with the rest of your collegues.""" & DDUtils.RNRN & "        .....       " & DDUtils.RNRN & "With a final warning not to fail them, the foreign presence leaves your mind and you are once again alone with your thoughts, your new " & ptype & ", and your task.")
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.thrall) = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = Game.player1
        If p.perks(perk.thrall) = -1 Or p.formName.Equals("Half-Succubus") Then
            Return AddressOf stopTF
        ElseIf Not p.prefForm.playerMeetsForm(p) And Not p.perks(perk.thrall) > 10 Then
            Return AddressOf shiftTowardsPrefForm
        ElseIf p.prefForm.playerMeetsForm(p) Or p.perks(perk.thrall) > 10 Then
            Return AddressOf crystalSpawn
        End If
        Return Nothing
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 5
        turnsTilNextStep += generatWILResistance()
    End Sub
End Class
