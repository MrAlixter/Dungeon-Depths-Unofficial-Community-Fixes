Public Class ThrallLoss
    Inherits Quest

    Sub New()
        MyBase.New("Enthralled")

        quest_index = qInd.enthralled

        objectives.Add(New FindCrystal)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Dim p As Player = Game.player1
        If p.forcedPath Is Nothing And Not Game.combat_engaged And Not Game.shop_npc_engaged Then

            Dim crystal = Game.currFloor.randPoint

            Game.currFloor.mBoard(crystal.Y, crystal.X).Tag = DDConst.TILE_SEEN
            Game.currFloor.mBoard(crystal.Y, crystal.X).Text = "c"

            p.forcedPath = Game.currFloor.route(p.pos, crystal)

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

            TextEvent.push("As your collar flares to life, you grimace as the location of a large purple gem forces itself into your mind." & DDUtils.RNRN &
                              """SERVANT!"", your controller's voice booms in your head, ""What you're seeing is another of the crystals I am seeking!  Recover it immediately!""" & DDUtils.RNRN &
                              "As their voice leaves your head, " & s)
        End If
    End Sub

    Public Overrides Sub completeEntireQuest()
        completed = True
        active = False
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive()
    End Function
End Class

Friend Class FindCrystal
    Inherits Objective

    Sub New()
        MyBase.New("Find the crystal's location.")
    End Sub

    Public Overrides Sub complete()
        If Int(Rnd() * 3) <> 1 Then
            Dim out = "You've found one of the crystals your controller is seeking!  As you circle it, you feel a familiar presence enter your mind." & DDUtils.RNRN &
                """Yes!  You've found it!"" your overseer states exitedly, ""I'll be over shortly, don't go anywhere and don't touch that crystal.""" & DDUtils.RNRN &
                "Obeying, you take a seat and wait for a few minutes before a violet portal opens up near the crystal and your master steps out."
            If Game.player1.getWIL > 7 Then
                out += "  In their attention to the crystal, they don't seem to notice you at all giving you a few minutes to yourself." & DDUtils.RNRN & "Wait... if they aren't paying attention to you..." & DDUtils.RNRN & "You fiddle around with your collar, and they still don't seem to notice your actions, so you leverage your thumb in the collars joint."
                TextEvent.push(out, AddressOf ThrallTF.betraySorc, AddressOf ThrallTF.waitSorc, "Break off your collar?")
            Else
                out += "  Despite your excitement, they don't seem to notice you, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and wait, are those horns sprouting out of their hair that seems to catch a non-existant wind?  With a flourish, they complete... something... and a blinding flash engulfs them.  Where once stood your human controller now stands a half-demon who only now seems to have taken notice of you." & _
                    """Well... It looks like you succeeded.  For that, I will give you an ultimatium.  Join me as my general, or die in these dungeons as my slave."
                TextEvent.push(out, AddressOf ThrallTF.acceptSorc, AddressOf ThrallTF.fightSorc, "Accept their offer?")
            End If

        Else
            TextEvent.push("You've found one of the crystals your controller is seeking!  As you circle it, you feel a familiar presence enter your mind.  " & _
                """No, that isn't it."" your overseer states disappointedly, ""Well, I guess you can go back to your business now.""")
            Game.player1.ongoingTFs.add(New ThrallTF())
            Game.player1.quests(qInd.enthralled).goToStep(1)
        End If

        MyBase.complete()

    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & 1 & "/1]"
    End Function

    Public Overrides Function isComplete() As Boolean


        Return True
    End Function
End Class

