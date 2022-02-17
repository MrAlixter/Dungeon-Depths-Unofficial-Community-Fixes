Public Class ActiveCamoflage
    Inherits Accessory

    Public Const ITEM_NAME As String = "Active_Camoflage"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 141
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Image Index|


        '|Description|
        setDesc("Unimplemented")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        TextEvent.push("Unimplemented")
        MyBase.onEquip(p)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
    End Sub
End Class
