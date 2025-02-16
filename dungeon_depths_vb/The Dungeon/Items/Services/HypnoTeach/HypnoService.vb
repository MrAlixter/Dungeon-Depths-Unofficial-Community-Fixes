Public MustInherit Class HypnoService
    Inherits Item

    Protected Overridable Sub teach(ByVal i As h_ind)
        count = 0

        Dim p = Game.player1

        Game.shopMenu.Close()
        Game.hideNPCButtons()

        If Not passesPreCheck(p) Then Exit Sub

        If doHypnosis(p, i) Then doTrigger(p, i)
    End Sub
    Protected Overridable Function passesPreCheck(ByRef p As Player) As Boolean
        If Not canHypnotize(p) Then
            failToHypno(p)
            Return False
        End If

        Return True
    End Function

    '| - OUTCOMES - |
    Protected Overridable Function doHypnosis(ByRef plr As Player, ByVal i As h_ind, Optional ByVal hypnoDesc As String = "") As Boolean
        Dim p = plr

        If DDUtils.isEmpty(hypnoDesc) Then
            hypnoDesc = getHypnoDesc(p)
        End If

        p.pState.save(p)
        p.sState.save(p)

        If Not CType(Game.hteach, HypnoTeach).hypnotize(hypnoDesc, p, i, Sub() wakeup(p)) Then
            failToHypno(p)

            Return False
        End If

        Return True
    End Function
    Protected Overridable Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        HypnosisEffect.trigger(p, i)
    End Sub
    Protected Overridable Sub failToHypno(ByRef p As Player, Optional ByVal pushText As Boolean = True)
        p.gold += getRefundAmount(Game.hteach, value)
        p.UIupdate()

        If pushText Then TextEvent.pushNPCDialog("""Alas, it does not appear that I will be able to help you at the moment.  You have my apologies, and a full refund.""" & DDUtils.PAKTC, AddressOf CType(Game.hteach, HypnoTeach).back)
    End Sub
    Protected Overridable Sub wakeup(ByRef p As Player, Optional ByVal noticedChanges As String = "")
        TextEvent.fpush("*SNAP!*" & DDUtils.RNRN &
                       "Startled, you jerk back to your senses; settling your focus on the teacher's fingers.  ""Very well, " & Game.player1.name & "; it seems that we're done here."" she says with a knowing grin." & DDUtils.RNRN &
                       "Done?  Right!" & DDUtils.RNRN & getNoticedChanges(p), AddressOf CType(Game.hteach, HypnoTeach).back)

        p.UIupdate()
        p.drawPort()
    End Sub

    '| - MISC - |
    Protected Overridable Function canHypnotize(ByRef p As Player) As Boolean
        Return True
    End Function
    Protected Shared Function getHypnoDesc(ByRef p As Player) As String
        Return """Perfect!" & DDUtils.RNRN &
               "Speaking of perfection, have you seen my pendant?  I know it may seem a bit clichéd, but does seeing it swing back and forth not just relax you so... perfectly?" & DDUtils.RNRN &
               "Back... and forth... watch it glisten in the light..." & DDUtils.RNRN &
               "Feel yourself go deeper and deeper... deeper... and deeper... until you just..." & DDUtils.RNRN &
               "*SNAP*" & DDUtils.RNRN &
               "...drift away..."""
    End Function
    Protected Overridable Function getNoticedChanges(ByRef p As Player) As String
        Return "Your hypnosis session... did " & Game.hteach.pronoun & "... already do it?  Hmm... but... you don't feel any different..." & DDUtils.RNRN &
               "You give the hypnotist with a suspicious look.  If " & Game.hteach.pronoun & " was going to rip you off, your mistress could have done a better job of hiding it..."
    End Function
    Protected Shared Function getRefundAmount(ByRef e As ShopNPC, ByVal value As Integer) As Integer
        Return (value - (value * e.discount))
    End Function
End Class
