Public Class FaeForgedRing
    Inherits Accessory

    Public Const ITEM_NAME As String = "Fae-Touched_Earrings"

    Private Shared soul_name As String
    Private Shared b_size As Integer
    Private Shared d_size As Integer
    Private Shared a_size As Integer
    Private Shared h_color As Color
    Private Shared s_color As Color

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 340
        tier = Nothing

        '|Item Flags|
        usable = False
        only_drop_one = True
        rando_inv_allowed = False

        '|Stats|
        count = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, True)

        '|Description|
        setDesc("A shiny pair of crystaline ear-wear that glint with a faint verdant sheen.  The patterns within the stone resemble a face, and while holding the ring it almost feels like someone- somewhere- is watching you..." & DDUtils.RNRN &
                getStatInformation())

        If DDUtils.fileExistsWC("items\", "*_" & id & ".itm") And soul_name = "" Then loadSavedItem(DDUtils.getSessionID(DDUtils.getPathUsingWC("items\", "*_" & id & ".itm")), id)
    End Sub

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If soul_name = "" Or Game.player1.inv.getCountAt(ITEM_NAME) > 0 Then Return Nothing

        Return 2
    End Function

    Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If Not soul_name = "" Then
            p.savePState()

            p.breastSize = b_size
            p.dickSize = d_size
            p.buttSize = a_size

            p.changeHairColor(h_color)
            p.changeSkinColor(s_color)

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

    Public Overrides Sub toSavedItem(ByRef ent As Entity)
        If ent.getPlayer Is Nothing Then
            MyBase.toSavedItem(ent)
        Else
            Dim output = CStr(
                ent.name & "*" &
                getAName() & "*" &
                id & "*" &
                Game.sessionID & "*" &
                Game.currFloor.floorCode & "*" &
                ent.getPlayer.breastSize & "*" &
                ent.getMaxHealth() & "*" &
                ent.getMaxMana() & "*" &
                ent.getPlayer.prt.haircolor.A & ":" & ent.getPlayer.prt.haircolor.R & ":" & ent.getPlayer.prt.haircolor.G & ":" & ent.getPlayer.prt.haircolor.B & "*" &
                ent.getPlayer.prt.skincolor.A & ":" & ent.getPlayer.prt.skincolor.R & ":" & ent.getPlayer.prt.skincolor.G & ":" & ent.getPlayer.prt.skincolor.B & "*" &
                ent.getPlayer.dickSize & "*" &
                ent.getPlayer.buttSize & "*")

            Dim writer As IO.StreamWriter
            Dim filename As String = "items\" & Game.sessionID & "_" & id & ".itm"
            For Each file In IO.Directory.GetFiles("items\", "*_" & id & ".itm")
                IO.File.Delete(file)
            Next
            writer = IO.File.CreateText(filename)
            writer.WriteLine(output)
            writer.Flush()
            writer.Close()
        End If
    End Sub

    Public Overrides Sub loadSavedItem(ByVal sessionID As String, ByVal itmid As Integer)
        Dim filename As String = "items\" & sessionID & "_" & itmid & ".itm"

        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(filename)

        Try
            Dim ring_array() As String = reader.ReadLine().Split("*")
            soul_name = ring_array(0)
            m_boost = (CInt(ring_array(6)) + CInt(ring_array(7))) / 2
            b_size = CInt(ring_array(5))
            d_size = CInt(ring_array(10))
            a_size = CInt(ring_array(11))

            Dim h_color_array() As String = ring_array(8).Split(":")
            h_color = Color.FromArgb(h_color_array(0), h_color_array(1), h_color_array(2), h_color_array(3))

            Dim s_color_array() As String = ring_array(9).Split(":")
            s_color = Color.FromArgb(s_color_array(0), s_color_array(1), s_color_array(2), s_color_array(3))
        Finally
            reader.Close()
        End Try
    End Sub
End Class
