Public Class SoulBlade
    Inherits Sword

    Public Const ITEM_NAME As String = "Soul-Blade"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 9
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False
        stores_inanimate_ent = True

        '|Stats|
        a_boost = 13
        count = 0
        value = 100

        '|Description|
        setDesc("A ornate sword forged from someone's soul." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getName() As String
        Dim itemName = MyBase.getAName() & If(getInanimateEnt(True) Is Nothing, "", " (" & getInanimateEnt(True).name & ")")

        If itemName.Length > ShopV3.P_ITEMNAME_LENGTH Then itemName = itemName.Substring(0, ShopV3.P_ITEMNAME_LENGTH - 1) & ".)"

        Return itemName
    End Function
    Public Overrides Function getDescription()
        Return "An ornate, crystalline sword forged from " & If(getInanimateEnt() Is Nothing, "someone", getInanimateEnt().name) & "'s soul.  Occasionally, it pulses with an unnatural glow..." & DDUtils.RNRN &
               getStatInformation()
    End Function

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        Return If(getInanimateEnt(True) Is Nothing, 0, getInanimateEnt(True).atk)
    End Function
    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        Return If(getInanimateEnt(True) Is Nothing, 0, getInanimateEnt(True).wil)
    End Function
    Public Overrides Function getValue() As Integer
        Return If(getInanimateEnt(True) Is Nothing, 0, getInanimateEnt(True).max_health)
    End Function
End Class
