Public Class FaeStockings
    Inherits Accessory

    Public Const ITEM_NAME As String = "Fae-Touched_Stockings"

    Private Shared soul_name As String
    Private Shared h_color As Color

    Private Shared img_ind_usizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize2 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize3 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize4 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize5 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 346
        tier = Nothing

        '|Item Flags|
        usable = False
        only_drop_one = True
        rando_inv_allowed = False
        under_b_clothes = True

        '|Stats|
        h_boost = 35
        m_boost = 25
        count = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A pair of soft, black stockings with a small ribbon." & DDUtils.RNRN &
                getStatInformation())

        If DDUtils.fileExistsWC("items\", "*_" & id & ".itm") And soul_name = "" Then loadSavedItem(DDUtils.getSessionID(DDUtils.getPathUsingWC("items\", "*_" & id & ".itm")), id)
    End Sub

    Public Overrides Function getDesc() As Object
        Return "A pair of soft, black stockings with a small " & Trim(Player.getColor(h_color)) & " ribbon." & DDUtils.RNRN &
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

    Public Overrides Function getTier() As Integer
        If soul_name = "" Or Game.player1.inv.getCountAt(ITEM_NAME) > 0 Then Return Nothing

        Return 2
    End Function

    Public Sub makeAccImg()
        Dim img_uneg1 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.hairacc).getAt(21), h_color), Portrait.imgLib.atrs(pInd.accessory).getAt(New Tuple(Of Integer, Boolean, Boolean)(40, True, True))})
        Dim img_u0 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.hairacc).getAt(22), h_color), Portrait.imgLib.atrs(pInd.accessory).getAt(New Tuple(Of Integer, Boolean, Boolean)(41, True, True))})
        Dim img_u1 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.hairacc).getAt(23), h_color), Portrait.imgLib.atrs(pInd.accessory).getAt(New Tuple(Of Integer, Boolean, Boolean)(42, True, True))})
        Dim img_u2 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.hairacc).getAt(24), h_color), Portrait.imgLib.atrs(pInd.accessory).getAt(New Tuple(Of Integer, Boolean, Boolean)(43, True, True))})
        Dim img_u3 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.hairacc).getAt(25), h_color), Portrait.imgLib.atrs(pInd.accessory).getAt(New Tuple(Of Integer, Boolean, Boolean)(44, True, True))})
        Dim img_u4 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.hairacc).getAt(26), h_color), Portrait.imgLib.atrs(pInd.accessory).getAt(New Tuple(Of Integer, Boolean, Boolean)(45, True, True))})
        Dim img_u5 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.hairacc).getAt(27), h_color), Portrait.imgLib.atrs(pInd.accessory).getAt(New Tuple(Of Integer, Boolean, Boolean)(46, True, True))})

        If img_ind_usizeneg1.Item1 <> 0 Then
            Portrait.imgLib.atrs(pInd.accessory).getF().RemoveAt(img_ind_usize5.Item1)
            Portrait.imgLib.atrs(pInd.accessory).getF().RemoveAt(img_ind_usize4.Item1)
            Portrait.imgLib.atrs(pInd.accessory).getF().RemoveAt(img_ind_usize3.Item1)
            Portrait.imgLib.atrs(pInd.accessory).getF().RemoveAt(img_ind_usize2.Item1)
            Portrait.imgLib.atrs(pInd.accessory).getF().RemoveAt(img_ind_usize1.Item1)
            Portrait.imgLib.atrs(pInd.accessory).getF().RemoveAt(img_ind_usize0.Item1)
            Portrait.imgLib.atrs(pInd.accessory).getF().RemoveAt(img_ind_usizeneg1.Item1)
        End If

        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img_uneg1)
        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img_u0)
        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img_u1)
        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img_u2)
        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img_u3)
        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img_u4)
        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img_u5)

        img_ind_usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count - 7, True, False)
        img_ind_usize0 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count - 6, True, False)
        img_ind_usize1 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count - 5, True, False)
        img_ind_usize2 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count - 4, True, False)
        img_ind_usize3 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count - 3, True, False)
        img_ind_usize4 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count - 2, True, False)
        img_ind_usize5 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count - 1, True, False)
    End Sub

    Public Overrides Function getAccIMG(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.buttSize
            Case -1
                Return img_ind_usizeneg1
            Case 0
                Return img_ind_usize0
            Case 1
                Return img_ind_usize1
            Case 2
                Return img_ind_usize2
            Case 3
                Return img_ind_usize3
            Case 4
                Return img_ind_usize4
            Case 5
                Return img_ind_usize5
            Case Else
                Return mInd
        End Select
    End Function
End Class
