Public Class ForgetSpecial
    Inherits HypnoService

    Public Const ITEM_NAME As String = "Forget_Special"
    Public Const COST As Integer = 230

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 442
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False
        can_be_stolen = False
        onBuy = Sub() teach(h_ind.forgetspecial)

        '|Stats|
        count = 0
        value = COST

        '|Description|
        setDesc("""If your mind is clogged up with specials you never plan on using, I can free it up... with a brief trance...""")
    End Sub

    '| - OUTCOMES - |
    Protected Overrides Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        'Don't do anything
    End Sub
    Protected Overrides Function doHypnosis(ByRef plr As Player, ByVal i As h_ind, Optional ByVal hypnoDesc As String = "") As Boolean
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        For Each spec In getSpecials(Game.player1)
            options.Add(New Tuple(Of String, Action)(spec, Sub() forget(spec)))
        Next

        If options.Count < 1 Then
            cancel()
            Return False
        End If

        TextEvent.noAction = AddressOf cancel
        TextEvent.pushManySelect("Forget what?", options)

        Return True
    End Function

    '| - MISC - |
    Protected Overrides Function canHypnotize(ByRef p As Player) As Boolean
        Return p.knownSpecials.Count() > 0
    End Function

    Shared Sub cancel()
        Game.player1.gold += getRefundAmount(Game.hteach, COST)
        CType(Game.hteach, HypnoTeach).back()

        Game.player1.UIupdate()
    End Sub
    Shared Sub forget(ByVal special As String)
        Dim p As Player = Game.player1

        CType(Game.hteach, HypnoTeach).hypnotize("""Very well.  Please focus on this pendant." & DDUtils.RNRN & "Back... and forth... and back... and forth...""" & DDUtils.RNRN & "*SNAP*", p, h_ind.forgetspecial, AddressOf CType(Game.hteach, HypnoTeach).back)
        HypnosisEffect.trigger(p, h_ind.forgetspecial, special)
    End Sub
    Shared Function getSpecials(ByRef p As Player) As List(Of String)
        Dim l = p.knownSpecials.ToArray.ToList

        'Don't allow the player to remove their ctrl-selected spell.
        For Each i In p.knownSpecials
            If i = p.selectedSpecial Then l.Remove(i) : Exit For
        Next

        Return l
    End Function
End Class
