Public Class Medusa
    Inherits Boss
    Dim hasAttackedFlag = False
    Dim pIsBlindCt = 3
    Sub New()
        name = "Medusa, Gorgon of Myth"
        maxHealth = 200
        attack = 50
        defence = 35
        speed = 40

        inv.setCount("Omni_Charm", 1)

        setupMonsterOnSpawn()

        title = " "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"

        xpValue = 1000
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) AndAlso CType(target, Player).perks("blind") < 0 Then
            If Not hasAttackedFlag Then
                CType(target, Player).perks("blind") = 2
                Game.zoom()
                hasAttackedFlag = True
                Game.pushLblEvent("Medusa slaps her emerald tail violently, knocking a cloud of debris and small stones directly at your face.  Raising an arm to shield yourself, you aren't able to fully block the dust as it filters directly into your eyes.  You are temporarily blinded!")
                Exit Sub
            Else

                If Not CType(target, Player).pForm.name.Contains("Gorgon") Then
                    target.currTarget = Me
                    target.die(Me)
                End If
            End If
        End If
        If CType(target, Player).perks("blind") = 2 And pIsBlindCt >= 1 Then pIsBlindCt -= 1
        If pIsBlindCt = 0 Then
            CType(target, Player).perks("blind") = -1
            Game.zoom()
            Game.pushLblEvent("You can see again!")
        End If

        If target.GetType() Is GetType(Player) AndAlso Not CType(target, Player).prt.skincolor.Equals(Color.DarkGray) And Int(Rnd() * 20) = 0 Then
            Game.pushLblEvent("Medusa casts Flesh to Basalt!")
            StoneFlesh()
        Else
            MyBase.attackCMD(target)
        End If
    End Sub
    Public Sub StoneFlesh()
        Dim p = Game.player
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        p.defence = 40

        Dim pturns = Int(Rnd() * 5) + 1
        p.petrify(Color.DarkGray, pturns)
        Game.pushLstLog(CStr("Medusa chants an arcane incantation, and petrifies you for " & pturns - 1 & " turns!"))
        Game.pushLblCombatEvent(CStr("Medusa chants an arcane incantation, and petrifies you for " & pturns - 1 & " turns!"))
    End Sub
    Public Overrides Function reactToSpell(spell As String) As Boolean
        If spell.Equals("Petrify") Then
            Game.pushLblEvent("The spell bounces off Medusa and strikes the ground!")
            Return False
        ElseIf spell.Equals("Polymorph Enemy") Then
            Dim pe = New EnemyPolymorph(Game.player, Nothing)
            Game.pushLblEvent("Medusa's eyes flash and a copy of your spell is cast back at you!")
            pe.backfire()
            Return False
        ElseIf spell.Equals("Turn to Cupcake") Then
            Dim ttc = New turnToCupcake(Game.player, Nothing)
            Game.pushLblEvent("Medusa's eyes flash and a copy of your spell is cast back at you!")
            ttc.backfire()
            Return False
        ElseIf spell.Equals("Uvona's Fugue") Then
            Dim uf = New UvonasFugue(Game.player, Nothing)
            Game.pushLblEvent("Medusa's eyes flash and a copy of your spell is cast back at you!")
            uf.backfire()
            Return False
        End If

        Return True
    End Function
End Class
