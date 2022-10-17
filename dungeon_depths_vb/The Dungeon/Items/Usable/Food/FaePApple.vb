Public Class FaePApple
    Inherits Food

    Public Const ITEM_NAME As String = "Apple​​"

    Private soul_name As String
    Private b_size As Integer
    Private h_color As Color
    Private s_color As Color

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 341
        tier = Nothing

        '|Item Flags|
        usable = True
        only_drop_one = True
        rando_inv_allowed = False

        '|Stats|
        count = 0

        '|Description|
        setDesc("An ""normal"" purple apple with sinister aura that seems out of line with what you'd expect of fruit.")

        If DDUtils.fileExistsWC("items\", "*_" & id & ".itm") Then loadSavedItem(DDUtils.getSessionID(DDUtils.getPathUsingWC("items\", "*_" & id & ".itm")), id)
    End Sub

    Public Overrides Function getTier() As Integer
        Return If(soul_name = "" Or Game.player1.inv.getCountAt(ITEM_NAME) > 0, Nothing, 2)
    End Function

    Public Overrides Sub effect(ByRef p As Player)
        If Not soul_name = "" Then
            p.savePState()

            p.breastSize = Math.Min(1, b_size)
            p.reverseAllRoute()

            p.changeHairColor(h_color)
            p.changeSkinColor(s_color)
        End If

        If Game.combat_engaged = True Or Game.shop_npc_engaged = True Or Not p.canMoveFlag Then
            FaePrincessTF.step3()
        Else
            FaePrincessTF.step1()
        End If
    End Sub

    Public Overrides Function getDesc() As Object
        Return "An ""normal"" purple apple with sinister aura that seems in line with what you'd expect of fruit." &
                If(soul_name = "", "", DDUtils.RNRN & "+" & getCalories() & " Stamina")
    End Function

    Public Shared Sub appleTF()
        Game.player1.inv.item(ITEM_NAME).toSavedItem(Game.player1)

        TextEvent.push("With little more than an *eep*, you vanish in a poof of pixie dust." & DDUtils.RNRN &
                       "You've been turned into an apple by the fae!", AddressOf Game.player1.die)
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
            setCalories(CInt(item_array(6)))
            b_size = CInt(item_array(5))

            Dim h_color_array() As String = item_array(8).Split(":")
            h_color = Color.FromArgb(h_color_array(0), h_color_array(1), h_color_array(2), h_color_array(3))

            Dim s_color_array() As String = item_array(9).Split(":")
            s_color = Color.FromArgb(s_color_array(0), s_color_array(1), s_color_array(2), s_color_array(3))
        Finally
            reader.Close()
        End Try
    End Sub
End Class
