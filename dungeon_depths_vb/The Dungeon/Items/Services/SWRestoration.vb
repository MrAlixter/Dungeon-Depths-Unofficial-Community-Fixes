Public Class SWRestoration
    Inherits Item

    Public Const ITEM_NAME As String = "Illicit_Restoration"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 359
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf restore

        '|Stats|
        count = 0
        value = 5000

        '|Description|
        setDesc("""Ah, did you find yourself on the wrong end of someone's spellbook?  Heh, I might be able to do something about that...""")
    End Sub

    Sub restore()
        Dim p = Game.player1
        Dim out = ""

        If Not isPlayerTFed(p) Then
            out = "Well... not much to change back yet, right?"
            Game.player1.inv.add(Gold.ITEM_NAME, value)
        ElseIf Not Transformation.canBeTFed(p) Then
            out = "No can do friend, looks like you've still got something going on..."
            Game.player1.inv.add(Gold.ITEM_NAME, value)
        Else
            out = "Alright, hold steady for a bit, I've got the perfect little charm to get you right back to normal."
            p.revertToSState()

            Dim tfed = False
            If p.breastSize < 1 Then p.breastSize = 1 : tfed = True
            If p.buttSize < 1 Then p.buttSize = 1 : tfed = True
            If p.dickSize > -1 Then p.dickSize = -1 : tfed = True
            out += DDUtils.RNRN & "Well, mostly back to normal..."
        End If

        Game.shopMenu.Close()

        TextEvent.pushNPCDialog(out)

        p.drawPort()
    End Sub

    Private Shared Function isPlayerTFed(ByRef p As Player) As Boolean
        If p Is Nothing Then Return False

        For i = 0 To Portrait.NUM_IMG_LAYERS
            If p.prt.iArrInd(i).Item1 <> p.sState.iArrInd(i).Item1 Or p.prt.iArrInd(i).Item2 <> p.sState.iArrInd(i).Item2 Or p.prt.iArrInd(i).Item3 <> p.sState.iArrInd(i).Item3 Then Return True
        Next

        Return False
    End Function
End Class
