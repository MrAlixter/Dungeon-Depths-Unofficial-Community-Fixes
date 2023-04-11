Public Class SoulBlade
    Inherits Sword

    Public Const ITEM_NAME As String = "Soul-Blade"

    Private soul_name As String

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 9
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        a_boost = 5
        count = 0
        value = 0

        '|Description|
        setDesc("A ornate sword forged from someone's soul." & DDUtils.RNRN &
                getStatInformation())

        If System.IO.File.Exists("items\" & Game.sessionID & "_" & id & ".itm") Then loadSavedItem(Game.sessionID, id)
    End Sub

    Public Overrides Function getName() As String
        Dim itemName = MyBase.getAName() & If(soul_name = "", "", " (" & soul_name & ")")

        If itemName.Length > ShopV3.P_ITEMNAME_LENGTH Then itemName = itemName.Substring(0, ShopV3.P_ITEMNAME_LENGTH - 1) & ".)"

        Return itemName
    End Function

    Public Sub Absorb(ByRef target As NPC)
        toSavedItem(target)

        soul_name = target.name

        a_boost = target.getATK()
        w_boost = target.getWIL()

        value = target.getMaxHealth

        target.toBlade()
    End Sub

    Public Overrides Sub loadSavedItem(ByVal sessionID As String, ByVal itmid As Integer)
        Dim filename As String = "items\" & sessionID & "_" & itmid & ".itm"

        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(filename)

        Try
            Dim sword_array() As String = reader.ReadLine().Split("*")
            soul_name = sword_array(0)
            value = CInt(sword_array(6))
            a_boost = CInt(sword_array(8))
            w_boost = CInt(sword_array(11))
        Finally
            reader.Close()
        End Try
    End Sub

    Public Overrides Function getDesc()
        Return "A ornate crystalline sword forged from " & If(soul_name = "", "someone", soul_name) & "'s soul.  Occasionally it pulses with an unnatural light..." & DDUtils.RNRN &
               getStatInformation()
    End Function
End Class
