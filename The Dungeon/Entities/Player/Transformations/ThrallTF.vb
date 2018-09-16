Public Class ThrallTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "ThrallTF"
        Game.player.perks("thrall") = 0
        nextStep = AddressOf shiftTowardsPrefForm
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "thrall"
        nextStep = getNextStep(cs)
    End Sub

    Sub shiftTowardsPrefForm()
        Dim p = Game.player
        p.prefForm.shiftTowards(Game.player)
        p.perks("thrall") += 1
        'MsgBox("1")
        If p.perks("thrall") > 11 Then
            MsgBox("2")
            p.prefForm.snapShift(Game.player)
        End If
        MyBase.currStep -= 1
    End Sub
    Sub crystalSpawn()
        Dim p = Game.player
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
            If p.getWillpower() > 10 Then
                s = "you mock your instructions under your breath, before stiffly moving towards the crystal." + vbCrLf + "𝘐𝘧 𝘰𝘯𝘭𝘺 𝘐 𝘤𝘰𝘶𝘭𝘥 𝘨𝘦𝘵 𝘵𝘩𝘪𝘴 𝘥𝘢𝘮𝘯 𝘤𝘰𝘭𝘭𝘢𝘳 𝘰𝘧𝘧..."
            ElseIf p.getWillpower() > 7 Then
                s = "you reluctantly start off towards the crystal." + vbCrLf + "𝘖𝘩 𝘸𝘦𝘭𝘭, 𝘣𝘦𝘵𝘵𝘦𝘳 𝘮𝘦 𝘵𝘩𝘢𝘯 𝘰𝘯𝘦 𝘰𝘧 𝘵𝘩𝘦𝘪𝘳 𝘰𝘵𝘩𝘦𝘳 𝘪𝘥𝘪𝘰𝘵𝘴."
            ElseIf p.getWillpower() > 4 Then
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

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("thrall") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p = Game.player
        If p.perks("thrall") = -1 Or p.pForm.name.Equals("Half-Succubus") Then
            Return AddressOf stopTF
        ElseIf Not p.prefForm.playerMeetsForm(p) Then
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
