Public Class FaeRose
    Inherits Accessory

    Public Const ITEM_NAME As String = "Fae-Touched_Rose"

    Private Shared soul_name As String
    Private Shared h_color As Color

    Private Shared img_ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 342
        tier = Nothing

        '|Item Flags|
        usable = False
        only_drop_one = True
        rando_inv_allowed = False

        '|Stats|
        h_boost = 35
        m_boost = 25
        count = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(31, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(32, True, True)

        '|Description|
        setDesc("A tiny flower, radiating with magical energy..." & DDUtils.RNRN &
                getStatInformation())

        If DDUtils.fileExistsWC("items\", "*_" & id & ".itm") And soul_name = "" Then loadSavedItem(DDUtils.getSessionID(DDUtils.getPathUsingWC("items\", "*_" & id & ".itm")), id)
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If soul_name = "" Then
            Equipment.accChange(p, "Nothing")
            count = 0
            TextEvent.pushAndLog("The rose crumbles to dust...")
        End If
    End Sub

    Public Overrides Function getDesc() As Object
        Return "A tiny " & Trim(Player.getColor(h_color)) & " flower, radiating with magical energy..." & DDUtils.RNRN &
               getStatInformation()
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
                ent.getSPD() & "*" &
                ent.getWIL() & "*")

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
            Dim item_array() As String = reader.ReadLine().Split("*")
            soul_name = item_array(0)
            value = item_array(6)

            Dim h_color_array() As String = item_array(8).Split(":")
            h_color = Color.FromArgb(h_color_array(0), h_color_array(1), h_color_array(2), h_color_array(3))
        Finally
            reader.Close()
        End Try

        makeAccImg()
    End Sub

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If soul_name = "" Or Game.player1.inv.getCountAt(ITEM_NAME) > 0 Then Return Nothing

        Return 2
    End Function

    Public Sub makeAccImg()
        Dim layer1 = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.accessory).getAt(fInd), h_color)
        Dim layer2 = Portrait.imgLib.atrs(pInd.accessory).getAt(mInd)

        Dim img = Portrait.CreateFullBodyBMP({layer1, layer2})

        img_ind = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count, True, False)
        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img)
    End Sub

    Public Overrides Function getAccIMG(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Return img_ind
    End Function
End Class
