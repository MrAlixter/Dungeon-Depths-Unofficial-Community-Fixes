Public Class ForgetSpell
    Inherits HypnoService

    Public Const ITEM_NAME As String = "Forget_Spell"
    Public Const COST As Integer = 230

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 441
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False
        can_be_stolen = False
        onBuy = Sub() teach(h_ind.forgetspell)

        '|Stats|
        count = 0
        value = COST

        '|Description|
        setDesc("""If your mind is clogged up with spells you never plan on casting, I can free it up... with a brief trance...""")
    End Sub

    '| - OUTCOMES - |
    Protected Overrides Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        'Don't do anything
    End Sub
    Protected Overrides Function doHypnosis(ByRef plr As Player, ByVal i As h_ind, Optional ByVal hypnoDesc As String = "") As Boolean
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        For Each spl In getSpells(Game.player1)
            options.Add(New Tuple(Of String, Action)(spl, Sub() forget(spl)))
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
        Return p.knownSpells.Count() > 0
    End Function

    Shared Sub cancel()
        Game.player1.gold += getRefundAmount(Game.hteach, COST)
        CType(Game.hteach, HypnoTeach).back()

        Game.player1.UIupdate()
    End Sub
    Shared Sub forget(ByVal spell As String)
        Dim p As Player = Game.player1

        CType(Game.hteach, HypnoTeach).hypnotize("""Very well.  Please focus on this pendant." & DDUtils.RNRN & "Back... and forth... and back... and forth...""" & DDUtils.RNRN & "*SNAP*", p, h_ind.forgetspell, AddressOf CType(Game.hteach, HypnoTeach).back)
        HypnosisEffect.trigger(p, h_ind.forgetspell, spell)
    End Sub
    Shared Function getSpells(ByRef p As Player) As List(Of String)
        Dim l = p.knownSpells.ToArray.ToList

        'Don't allow the player to remove their ctrl-selected spell.
        For Each i In p.knownSpells
            If i = p.selectedSpell Then l.Remove(i) : Exit For
        Next

        Return l
    End Function
End Class
