Public NotInheritable Class ThrallTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.thrall

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        MyBase.update_during_combat = False
        Game.player1.perks(perk.thrall) = 0
        next_step = AddressOf shiftTowardsPrefForm
    End Sub
    Sub New()
        MyBase.New(1, Int(Rnd() * 10) + 10, 0, False)
        tf_name = TF_IND
        MyBase.update_during_combat = False
        Game.player1.perks(perk.thrall) = 11
        next_step = AddressOf crystalSpawn
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        MyBase.update_during_combat = False
        next_step = getNextStep(cs)
    End Sub

    Sub shiftTowardsPrefForm()
        Dim p As Player = Game.player1

        p.prefForm.shiftTowards(Game.player1)

        p.perks(perk.thrall) += 1
        If p.perks(perk.thrall) > 11 Then
            p.prefForm.snapShift(Game.player1)
        End If

        MyBase.curr_step -= 1
    End Sub

    Sub crystalSpawn()
        Dim p As player = Game.player1
        If p.forcedPath Is Nothing And Not Game.combat_engaged And Not Game.shop_npc_engaged Then

            Dim crystal = Game.currfloor.randPoint

            Game.currfloor.mBoard(crystal.Y, crystal.X).Tag = 2
            Game.currfloor.mBoard(crystal.Y, crystal.X).Text = "c"

            p.forcedPath = Game.currfloor.route(p.pos, crystal)

            Dim s As String = ""
            If p.getWIL() > 40 Then
                s = "you mock your instructions under your breath, before stiffly moving towards the crystal." + DDUtils.RNRN + "'If only I could get this damn collar off...'"
            ElseIf p.getWIL() > 15 Then
                s = "you reluctantly start off towards the crystal." + DDUtils.RNRN + "'Oh well, better me than one of their other idiots...'"
            ElseIf p.getWIL() > 4 Then
                s = "you jump immediately into action, eager to help the voice in your head with whatever it may need." + DDUtils.RNRN + "'I'm going to make quick work of this!'"
            Else
                s = "you mindlessly obey, moving towards the crystal with a vacant grin."
            End If
            TextEvent.push("SNAP!" & DDUtils.RNRN &
                           "You pause in your tracks, mind once again blank as your surroundings fade away.  As it ripples into focus, you become aware of a large, glyph-covered jewel located nearby." & DDUtils.RNRN &
                           """SERVANT!"",  a familiar voice booms through your trance, ""THIS SHALL BE YOUR NEXT OBJECTIVE!""" & DDUtils.RNRN &
                           "As their presence leaves, " & s)
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
        m = Monster.monsterFactory(mInd.enth_demon)

        Monster.targetRoute(m)
        Game.toCombat(m)

        TextEvent.pushLog((m.getName() & " attacks!"))
    End Sub
    Shared Sub fightSorc2()
        Dim p As player = Game.player1
        Game.lblEvent.Visible = False
        Dim m As Monster
        m = Monster.monsterFactory(mInd.enrage_sorc)

        Monster.targetRoute(m)
        Game.toCombat(m)

        TextEvent.pushLog((m.getName() & " attacks!"))
    End Sub
    Shared Sub acceptSorc()
        Dim p As player = Game.player1
        p.perks(perk.thrall) = -1
        p.ongoingTFs.Add(New HalfSuccubusTF())
        p.update()
        TextEvent.push("""Then I deem your task concluded as a success.  Go now, and try not to fall under the spell of anyone else...""")
    End Sub
    Shared Sub betraySorc()
        Dim p As player = Game.player1
        TextEvent.push("Your master doesn't seem to notice your dilemma, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and... wait, are those horns sprouting out from under their hair?" & DDUtils.RNRN &
                       "Once the collar's clasp is broken, you creep behind them and prepare to make your move.  The runes enscribed on the crystal begin to shine brighter as the sorcerer's raving reaches its zenith, and in that moment you strike the back of their head!  They stagger forward, cursing under their breath as the ritual is disrupted and the crystal shatters into pieces." & DDUtils.RNRN &
                       """YOU!  HOW?  WHY?  DO YOU HAVE ANY IDEA..."" screams the mage, before they gasp at the sight of your now-bare neck." & DDUtils.RNRN &
                       "Grinning, your prepare to fight for your life and for your freedom.", AddressOf fightSorc2)

        Equipment.accChange(p, "Nothing")
        If p.inv.getCountAt(ThrallCollar.ITEM_NAME) > 0 Then p.inv.add(ThrallCollar.ITEM_NAME, -1)

        p.drawPort()
    End Sub
    Shared Sub waitSorc()
        Dim p As Player = Game.player1
        Dim out = "You decide against making a move now..." & DDUtils.RNRN &
                  "Your master doesn't seem to notice your dilemma, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and... wait, are those horns sprouting out from under their hair?" & DDUtils.RNRN &
                  "With a flourish, they complete their ritual, and with a deafening hum you are both engulfed by a blinding light that flashes out from the crystal!" & DDUtils.RNRN &
                  "As the dungeon fades back in, you glance around nervously.  Where once stood a mere human now stands a much-taller demon, clad in the tatters of their former clothes.  They cackle maniacally as a realization washes over you..." & DDUtils.RNRN &
                  "The collar around your neck has been reduced to ash!"

        Equipment.equipAcce(p, "Nothing", False)
        If p.inv.getCountAt(ThrallCollar.ITEM_NAME) > 0 Then p.inv.add(ThrallCollar.ITEM_NAME, -1)

        TextEvent.push(out, AddressOf waitSorc2)
    End Sub
    Shared Sub waitSorc2()
        Dim p As Player = Game.player1
        TextEvent.push("""Well, well, well..."" the smug demon says, with a toothy grin." & DDUtils.RNRN &
                       """It seems like someone is finally free...  For the time being, at least.""" & DDUtils.RNRN &
                       "They flare their wings, and a jet black aura of crackling energy erupts around them.  ""Hmm, you were a loyal minion, though...""" & DDUtils.RNRN &
                       "LISTEN AND LISTEN WELL, I have an ultimatium for you.  Join me as a vessel for my infernal power, or... die.  Understand?""", AddressOf acceptSorc, AddressOf fightSorc, "Do you accept?")
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.thrall) = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1

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
        turns_until_next_step = 30 + Int(Rnd() * 5)
        turns_until_next_step += generatWILResistance()
    End Sub
End Class
