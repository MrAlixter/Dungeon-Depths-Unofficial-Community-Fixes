Public Class FaeLingerie
    Inherits Armor

    Public Const ITEM_NAME As String = "Fae-Touched_Lingerie"

    Private Shared soul_name As String
    Private Shared h_color As Color

    Private Shared img_ind_bsizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_bsize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_bsize1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_bsize2 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_bsize3 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

    Private Shared img_ind_usizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize2 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize3 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Private Shared img_ind_usize4 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 343
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        only_drop_one = True
        rando_inv_allowed = False

        '|Stats|
        d_boost = 25
        w_boost = 15
        count = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(97, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(448, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(449, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(450, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(451, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(94, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(436, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(437, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(438, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(439, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(440, True, True)

        '|Description|
        setDesc("A slinky set of underwear, radiating with magical energy.  Stitched into the bustier is the name """"..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())

        If DDUtils.fileExistsWC("items\", "*_" & id & ".itm") And soul_name = "" Then loadSavedItem(DDUtils.getSessionID(DDUtils.getPathUsingWC("items\", "*_" & id & ".itm")), id)
    End Sub

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If soul_name = "" Or Game.player1.inv.getCountAt(ITEM_NAME) > 0 Then Return Nothing

        Return 2
    End Function

    Public Overrides Function getDesc() As Object
        Return "A slinky set of underwear, radiating with magical energy.  Stitched into the bustier is the name """ & soul_name & """..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation()
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If soul_name = "" Then
            Equipment.clothesChange(p, "Naked")
            count = 0
            TextEvent.pushAndLog("The lingerie crumbles to dust...")
        End If
    End Sub

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

        makeClothesImg()
    End Sub

    Public Sub makeClothesImg()
        Dim img_bneg1 = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothes).getAt(bsizeneg1), h_color)
        Dim img_b0 = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothes).getAt(bsize0), h_color)
        Dim img_b1 = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothes).getAt(bsize1), h_color)
        Dim img_b2 = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothes).getAt(bsize2), h_color)
        Dim img_b3 = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothes).getAt(bsize3), h_color)

        Dim img_uneg1 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothesbtm).getAt(usizeneg1), h_color), Portrait.imgLib.atrs(pInd.hairacc).getAt(15)})
        Dim img_u0 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothesbtm).getAt(usize0), h_color), Portrait.imgLib.atrs(pInd.hairacc).getAt(16)})
        Dim img_u1 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothesbtm).getAt(usize1), h_color), Portrait.imgLib.atrs(pInd.hairacc).getAt(17)})
        Dim img_u2 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothesbtm).getAt(usize2), h_color), Portrait.imgLib.atrs(pInd.hairacc).getAt(18)})
        Dim img_u3 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothesbtm).getAt(usize3), h_color), Portrait.imgLib.atrs(pInd.hairacc).getAt(19)})
        Dim img_u4 = Portrait.CreateFullBodyBMP({Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.clothesbtm).getAt(usize4), h_color), Portrait.imgLib.atrs(pInd.hairacc).getAt(20)})

        If img_ind_bsizeneg1.Item1 <> 0 Then
            Portrait.imgLib.atrs(pInd.clothes).getF().RemoveAt(img_ind_bsize3.Item1)
            Portrait.imgLib.atrs(pInd.clothes).getF().RemoveAt(img_ind_bsize2.Item1)
            Portrait.imgLib.atrs(pInd.clothes).getF().RemoveAt(img_ind_bsize1.Item1)
            Portrait.imgLib.atrs(pInd.clothes).getF().RemoveAt(img_ind_bsize0.Item1)
            Portrait.imgLib.atrs(pInd.clothes).getF().RemoveAt(img_ind_bsizeneg1.Item1)
        End If

        Portrait.imgLib.atrs(pInd.clothes).getF().Add(img_bneg1)
        Portrait.imgLib.atrs(pInd.clothes).getF().Add(img_b0)
        Portrait.imgLib.atrs(pInd.clothes).getF().Add(img_b1)
        Portrait.imgLib.atrs(pInd.clothes).getF().Add(img_b2)
        Portrait.imgLib.atrs(pInd.clothes).getF().Add(img_b3)

        img_ind_bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothes).getF().Count - 5, True, False)
        img_ind_bsize0 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothes).getF().Count - 4, True, False)
        img_ind_bsize1 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothes).getF().Count - 3, True, False)
        img_ind_bsize2 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothes).getF().Count - 2, True, False)
        img_ind_bsize3 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothes).getF().Count - 1, True, False)

        If img_ind_usizeneg1.Item1 <> 0 Then
            Portrait.imgLib.atrs(pInd.clothesbtm).getF().RemoveAt(img_ind_usize4.Item1)
            Portrait.imgLib.atrs(pInd.clothesbtm).getF().RemoveAt(img_ind_usize3.Item1)
            Portrait.imgLib.atrs(pInd.clothesbtm).getF().RemoveAt(img_ind_usize2.Item1)
            Portrait.imgLib.atrs(pInd.clothesbtm).getF().RemoveAt(img_ind_usize1.Item1)
            Portrait.imgLib.atrs(pInd.clothesbtm).getF().RemoveAt(img_ind_usize0.Item1)
            Portrait.imgLib.atrs(pInd.clothesbtm).getF().RemoveAt(img_ind_usizeneg1.Item1)
        End If

        Portrait.imgLib.atrs(pInd.clothesbtm).getF().Add(img_uneg1)
        Portrait.imgLib.atrs(pInd.clothesbtm).getF().Add(img_u0)
        Portrait.imgLib.atrs(pInd.clothesbtm).getF().Add(img_u1)
        Portrait.imgLib.atrs(pInd.clothesbtm).getF().Add(img_u2)
        Portrait.imgLib.atrs(pInd.clothesbtm).getF().Add(img_u3)
        Portrait.imgLib.atrs(pInd.clothesbtm).getF().Add(img_u4)

        img_ind_usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothesbtm).getF().Count - 6, True, False)
        img_ind_usize0 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothesbtm).getF().Count - 5, True, False)
        img_ind_usize1 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothesbtm).getF().Count - 4, True, False)
        img_ind_usize2 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothesbtm).getF().Count - 3, True, False)
        img_ind_usize3 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothesbtm).getF().Count - 2, True, False)
        img_ind_usize4 = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.clothesbtm).getF().Count - 1, True, False)

    End Sub

    Public Overrides Function getClothesIMGTop(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.breastSize
            Case -1
                Return img_ind_bsizeneg1
            Case 0
                Return img_ind_bsize0
            Case 1
                Return img_ind_bsize1
            Case 2
                Return img_ind_bsize2
            Case 3
                Return img_ind_bsize3
            Case Else
                Return MyBase.getClothesIMGTop(p)
        End Select
    End Function
    Public Overrides Function getClothesIMGBtm(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
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
            Case Else
                Return MyBase.getClothesIMGBtm(p)
        End Select

        Return Nothing
    End Function
End Class
