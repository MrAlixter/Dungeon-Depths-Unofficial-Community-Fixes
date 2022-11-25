Public Class UtilityManual
    Inherits Manual

    Public Const ITEM_NAME As String = "Utility_Manual"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 89
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A simple, leather-bound book that likely contains some helpful skills.")
    End Sub

    Public Shared Shadows Function getSpecials() As String()
        Return New UtilityManual().specials
    End Function
    Public Overrides Function specials() As String()
        Return {"Ritual of Mana", "Cleanse", "Spot Fusion", "Uvona's Blessing", "Charm"}
    End Function
End Class
