Public Class FaeForgedRing
    Inherits Accessory

    Public Const ITEM_NAME As String = "Fae-Touched_Earrings"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 340
        tier = Nothing

        '|Item Flags|
        usable = False
        only_drop_one = True
        rando_inv_allowed = False
        stores_inanimate_ent = True

        '|Stats|
        count = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, True)

        '|Description|
        setDesc("A shiny pair of crystaline ear-wear that glint with a faint verdant sheen.  The patterns within the stone resemble a face, and while holding the ring it almost feels like someone- somewhere- is watching you..." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If getInanimateEnt() Is Nothing OrElse Game.player1.inv.getCountAt(ITEM_NAME) > 0 Then Return Nothing

        Return 2
    End Function

    Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If Not getInanimateEnt() Is Nothing Then
            p.savePState()

            p.breastSize = getInanimateEnt().extra2
            p.dickSize = getInanimateEnt().extra3
            p.buttSize = getInanimateEnt().extra4

            p.changeHairColor(getInanimateEnt().prt.haircolor)
            p.changeSkinColor(getInanimateEnt().prt.skincolor)

            TextEvent.pushAndLog("As you put on the earrings, a tiny giggle flits from seemingly nowhere...")
        End If
    End Sub

    Public Overrides Function getAccIMG(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        If p Is Nothing OrElse p.prt Is Nothing Then Return mInd

        If p.prt.checkFemInd(pInd.ears, 1) Or p.prt.checkFemInd(pInd.ears, 2) Or p.prt.checkFemInd(pInd.ears, 4) Or p.prt.checkNDefFemInd(pInd.ears, 7) Or
           p.prt.checkNDefFemInd(pInd.ears, 10) Or p.prt.checkNDefFemInd(pInd.ears, 11) Or p.prt.checkNDefFemInd(pInd.ears, 13) Or p.prt.checkFemInd(pInd.ears, 1) Or p.prt.checkFemInd(pInd.ears, 2) Or p.prt.checkFemInd(pInd.ears, 4) Or p.prt.checkNDefFemInd(pInd.ears, 7) Or
           p.prt.checkNDefFemInd(pInd.ears, 10) Or p.prt.checkNDefFemInd(pInd.ears, 11) Or p.prt.checkNDefFemInd(pInd.ears, 13) Or
           p.prt.checkMalInd(pInd.ears, 1) Or p.prt.checkMalInd(pInd.ears, 2) Or p.prt.checkMalInd(pInd.ears, 4) Or p.prt.checkNDefFemInd(pInd.ears, 6) Then

            Return mInd
        End If

        Return fInd
    End Function

    Public Overrides Sub setInanimateEnt(ByRef ent As InanimateEntity, ByRef source As Entity)
        If Not source.getPlayer() Is Nothing Then
            Dim p = source.getPlayer()

            ent.extra2 = p.breastSize
            ent.extra3 = p.dickSize
            ent.extra4 = p.buttSize
        End If

        MyBase.setInanimateEnt(ent, source)
    End Sub
End Class
