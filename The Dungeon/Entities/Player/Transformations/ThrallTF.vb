Public Class ThrallTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "ThrallTF"
        MyBase.updateDuringCombat = False
        Game.player.perks("thrall") = 0
        nextStep = AddressOf shiftTowardsPrefForm
    End Sub
    Sub New()
        MyBase.New(1, Int(Rnd() * 10) + 10, 0, False)
        tfName = "ThrallTF"
        MyBase.updateDuringCombat = False
        Game.player.perks("thrall") = 11
        nextStep = AddressOf crystalSpawn
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "ThrallTF"
        MyBase.updateDuringCombat = False
        nextStep = getNextStep(cs)
    End Sub

    Sub shiftTowardsPrefForm()
        Dim p As player = game.player
        p.prefForm.shiftTowards(Game.player)
        p.perks("thrall") += 1
        If p.perks("thrall") > 11 Then
            p.prefForm.snapShift(Game.player)

        End If
        MyBase.currStep -= 1
    End Sub
    Sub crystalSpawn()
        Dim p As player = game.player
        If p.forcedPath Is Nothing And Not Game.combatmode And Not Game.npcmode Then
            Dim crystalX As Integer
            Dim crystalY As Integer
            Do While (Game.mBoard(crystalY, crystalX).Tag < 1 Or Game.mBoard(crystalY, crystalX).Text <> "" Or (crystalX.Equals(p.pos.X) And crystalY.Equals(p.pos.Y)))
                'MsgBox(CBool(Game.mBoard(crystalY, crystalX).Tag < 1) & "-" & CBool(Game.mBoard(crystalY, crystalX).Text <> "") & "-" & CBool(crystalX.Equals(p.pos.X) And crystalY.Equals(p.pos.Y)))
                crystalX = CInt(Int(Rnd() * Game.mBoardWidth))
                crystalY = CInt(Int(Rnd() * Game.mBoardHeight))
            Loop
            Dim crystal = New Point(crystalX, crystalY)

            Game.mBoard(crystalY, crystalX).Tag = 2
            Game.mBoard(crystalY, crystalX).Text = "c"

            p.forcedPath = Game.route(p.pos, crystal)

            Dim s As String = ""
            If p.getWIL() > 10 Then
                s = "you mock your instructions under your breath, before stiffly moving towards the crystal." + vbCrLf + "𝘐𝘧 𝘰𝘯𝘭𝘺 𝘐 𝘤𝘰𝘶𝘭𝘥 𝘨𝘦𝘵 𝘵𝘩𝘪𝘴 𝘥𝘢𝘮𝘯 𝘤𝘰𝘭𝘭𝘢𝘳 𝘰𝘧𝘧..."
            ElseIf p.getWIL() > 7 Then
                s = "you reluctantly start off towards the crystal." + vbCrLf + "𝘖𝘩 𝘸𝘦𝘭𝘭, 𝘣𝘦𝘵𝘵𝘦𝘳 𝘮𝘦 𝘵𝘩𝘢𝘯 𝘰𝘯𝘦 𝘰𝘧 𝘵𝘩𝘦𝘪𝘳 𝘰𝘵𝘩𝘦𝘳 𝘪𝘥𝘪𝘰𝘵𝘴."
            ElseIf p.getWIL() > 4 Then
                s = "you jump immediatly into action, happy to help the voice in your head with whatever it may need." + vbCrLf + "𝘐'𝘮 𝘨𝘰𝘪𝘯𝘨 𝘵𝘰 𝘮𝘢𝘬𝘦 𝘲𝘶𝘪𝘤𝘬 𝘸𝘰𝘳𝘬 𝘰𝘧 𝘵𝘩𝘪𝘴 𝘵𝘢𝘴𝘬!"
            Else
                s = "you mindlessly obey, moving towards the crystal with a vacant grin."
            End If
            Game.pushLblEvent("As your collar flares to life, you grimace as the location of a large mana crystal becomes clear in your mind." & _
                              "'SERVANT!', your controller's voice booms in your head, 'This is another of the crystals!  Recover it immediately!'" & vbCrLf & _
                              "As their voice leaves your head, " & s)
        End If

        stopTF()
    End Sub
    Shared Sub postLoadCrystalSpawn(ByVal e As Entity)
        Dim p = Game.player
        Dim crystal As Point = New Point(p.forcedPath(0).X, p.forcedPath(0).Y)
        Game.mBoard(crystal.Y, crystal.X).Text = "c"
        p.forcedPath = Game.route(p.pos, crystal)
        p.nextCombatAction = Nothing
    End Sub

    Shared Sub fightSorc()
        Dim p As player = game.player
        Dim m As Monster
        m = New Monster(9)

        Monster.targetRoute(m)

        Game.toCombat()
        Game.pushLstLog((m.getName() & " attacks!"))
        Game.turn += 1
    End Sub
    Shared Sub fightSorc2()
        Dim p As player = game.player
        Game.lblEvent.Visible = False
        Dim m As Monster
        m = New Monster(8)

        Monster.targetRoute(m)

        Game.toCombat()
        Game.pushLstLog((m.getName() & " attacks!"))
        Game.turn += 1
    End Sub
    Shared Sub acceptSorc()
        Dim p As player = game.player
        p.perks("thrall") = -1
        p.ongoingTFs.Add(New HalfSuccubusTF())
        p.update()
        Game.pushLblEvent("""Then I deem your task concluded as a success.  Go now, and take care not to fall under the spell of any others,"" your controller states.")
    End Sub
    Shared Sub betraySorc()
        Dim p As player = game.player
        Game.pushLblEvent("Brushing past you, your ""boss"" heads straight for the array.  As they begin fiddling with it, you take notice of their distraction and begin creeping into a position behind them.  As they chant over the array, you prepare to make your move.  " & _
                          "As their raving reaches its zenith and the runes enscribed on the crystal begin to glow you strike out, disrupting their ritual.  ""YOU!  DO YOU HAVE ANY IDEA ..."" screams the mage, and while they shout you realize you couldn't care less about them.  " & _
                          "Looking down, you see that your collar has gone dark and dangles open from your neck.  Grinning, your prepare to fight for your life.", AddressOf fightSorc2)


        Equipment.accChange("Nothing")
        p.inv.add(69, -1)

        p.createP()
    End Sub
    Shared Sub waitSorc()
        Dim out = "You decide against making a move now, instead waiting to see what happens next.  Your controller doesn't seem to notice you, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and wait, are those horns sprouting out of their hair that seems to catch a non-existant wind?  With a flourish, they complete ... something ... and a blinding flash engulfs them.  Where once stood your human controller now stands a half-demon who only now seems to have taken notice of you." & _
                        """Well... It looks like you succeeded.  For that, I will give you an ultimatium.  Join me as my general, or die in these dungeons as my slave."
        Game.pushLblEvent(out, AddressOf acceptSorc, AddressOf fightSorc, "Do you accept?")
    End Sub

    Shared Sub thrallLN2()
        Dim ptype = "sister"
        If Int(Rnd() * 2) = 0 Then
            ptype = "brother"
        End If
        Game.pushLblEvent("""LISTEN UP, NEW SLAVE!  I have need of your services."" your new master begins, ""In this dungeon, there are several high-power mana arrays.  Only one of them, however, is capable of bestowing the power of a demon lord onto a mortal such as I.  Your task is to find and inspect these arrays, and report back to me with your findings.""  They snicker,  ""I'm sure you won't let me down, but I'm going to need to make a few changes to make you more ... uniform ... with the rest of your collegues.""" & vbCrLf & vbCrLf & "        .....       " & vbCrLf & vbCrLf & "With a final warning not to fail them, the foreign presence leaves your mind and you are once again alone with your thoughts, your new " & ptype & ", and your task.")
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("thrall") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        If p.perks("thrall") = -1 Or p.pForm.name.Equals("Half-Succubus") Then
            Return AddressOf stopTF
        ElseIf Not p.prefForm.playerMeetsForm(p) And Not p.perks("thrall") > 10 Then
            Return AddressOf shiftTowardsPrefForm
        ElseIf p.prefForm.playerMeetsForm(p) Or p.perks("thrall") > 10 Then
            Return AddressOf crystalSpawn
        End If
        Return Nothing
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 5
        turnsTilNextStep += generatWILResistance()
    End Sub
End Class
