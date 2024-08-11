Public Class ForgetSpecial
    Inherits Item

    Public Const ITEM_NAME As String = "Forget_Special"
    Public Const COST As Integer = 230

    Public Shared selectedSpell As String = ""

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
        onBuy = AddressOf teach

        '|Stats|
        count = 0
        value = COST

        '|Description|
        setDesc("""If your mind is clogged up with specials you never plan on using, I can free it up... with a brief trance...""")
    End Sub

    Sub teach()
        count = 0

        Game.shopMenu.Close()
        Game.hideNPCButtons()

        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        For Each i In getSpecials(Game.player1)
            options.Add(New Tuple(Of String, Action)(i, Sub() forget(i)))
        Next

        TextEvent.noAction = AddressOf cancel
        TextEvent.pushManySelect("Forget what?", options)
    End Sub

    Shared Sub cancel()
        Game.player1.gold += COST
        CType(Game.hteach, HypnoTeach).back()

        Game.player1.UIupdate()
    End Sub

    Shared Sub forget(ByVal special As String)
        Game.player1.knownSpecials.Remove(special)

        TextEvent.pushLog(special & " special forgotten!")

        CType(Game.hteach, HypnoTeach).hypnotize("""Very well.  Please focus on this pendant." & DDUtils.RNRN & "Back... and forth... and back... and forth...""" & DDUtils.RNRN & "*SNAP*", AddressOf CType(Game.hteach, HypnoTeach).back)
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
