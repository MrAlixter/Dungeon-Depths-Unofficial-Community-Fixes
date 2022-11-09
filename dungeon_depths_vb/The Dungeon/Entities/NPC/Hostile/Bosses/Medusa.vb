Public Class Medusa
    Inherits Boss
    Dim hasAttackedFlag = False
    Dim pIsBlindCt = 3
    Sub New()
        '|ID Info|
        name = "Medusa, Gorgon of Myth"

        '|Stats|
        maxHealth = 200
        attack = 50
        defense = 35
        speed = 40
        xp_value = 1000
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount(OmniCharm.ITEM_NAME, 1)
        inv.setCount(MedusaEye.ITEM_NAME, 1)
        inv.setCount(SthenoSalve.ITEM_NAME, 1)

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) AndAlso CType(target, Player).perks(perk.blind) < 0 Then
            If Not hasAttackedFlag Then
                CType(target, Player).perks(perk.blind) = 2
                Game.zoom()
                hasAttackedFlag = True
                TextEvent.push("Medusa slaps her emerald tail violently, knocking a cloud of debris and small stones directly at your face.  Raising an arm to shield yourself, you aren't able to fully block the dust as it filters directly into your eyes.  You are temporarily blinded!")
                Exit Sub
            Else

                If Not CType(target, Player).formName.Contains("Gorgon") Then
                    target.currTarget = Me
                    target.die(Me)
                End If
            End If
        End If
        If CType(target, Player).perks(perk.blind) = 2 And pIsBlindCt >= 1 Then pIsBlindCt -= 1
        If pIsBlindCt = 0 And target.isDead = False Then
            CType(target, Player).perks(perk.blind) = -1
            Game.zoom()
            TextEvent.push("You can see again!")
        End If

        If target.GetType() Is GetType(Player) AndAlso Not CType(target, Player).prt.skincolor.Equals(Color.DarkGray) And Int(Rnd() * 20) = 0 Then
            TextEvent.push("Medusa casts Flesh to Basalt!")
            StoneFlesh()
        Else
            MyBase.attackCMD(target)
        End If
    End Sub
    Public Sub StoneFlesh()
        Dim p = Game.player1
        p.savePState()

        p.defense = 40

        Dim pturns = Int(Rnd() * 5) + 1
        p.petrify(Color.DarkGray, pturns)
        TextEvent.pushLog(CStr("Medusa chants an arcane incantation, and petrifies you for " & pturns - 1 & " turns!"))
        TextEvent.pushCombat(CStr("Medusa chants an arcane incantation, and petrifies you for " & pturns - 1 & " turns!"))
    End Sub
    Public Overrides Function reactToSpell(spell As String) As Boolean
        If spell.Equals("Petrify") Then
            TextEvent.push("The spell bounces off Medusa and strikes the ground!")
            Return False
        ElseIf spell.Equals("Polymorph Enemy") Then
            Dim pe = New EnemyPolymorph(Game.player1, Nothing)
            TextEvent.push("Medusa's eyes flash and a copy of your spell is cast back at you!")
            pe.backfire()
            Return False
        ElseIf spell.Equals("Turn to Cupcake") Then
            Dim ttc = New turnToCupcake(Game.player1, Nothing)
            TextEvent.push("Medusa's eyes flash and a copy of your spell is cast back at you!")
            ttc.backfire()
            Return False
        ElseIf spell.Equals("Uvona's Fugue") Then
            Dim uf = New UvonasFugue(Game.player1, Nothing)
            TextEvent.push("Medusa's eyes flash and a copy of your spell is cast back at you!")
            uf.backfire()
            Return False
        End If

        Return True
    End Function
    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()
        p.petrify(Color.White, 999999)
        TextEvent.push("Cackling with delight, Medusa coils around your weakened form, propping you upwards as she gently positions your head and peers intensely into your eyes.  For little more than an instant you meet her beautiful, deadly gaze, but that instant is all it takes to seal your fate." & DDUtils.RNRN &
                       "As you try to jolt yourself free of her scaly embrace, your legs become heavier and heavier as your lower body becomes a fine white marble.  The stoney texture creeps upwards, setting more and more of you into an eternal pose as you struggle in vain.  The cool stone reaches your fingertips, as your mind still races to desperately find a way out of this dire situation." & DDUtils.RNRN &
                       "In one last futile act of resistance, you try to shut your eyes and look away.  The marble is faster than your now-sluggish reflexes, and your efforts only serve to give a distant, vacant expression to the statue you've become." & DDUtils.RNRN &
                       "In mere moments, the cruel, stoney gaze of Medusa has left " & p.getName & " as nothing but another decoration adorning the hall of the mythical gorgon.", AddressOf DeathEffects.hardDeath)
    End Sub
End Class
