Public Class CombatManual
    Inherits Manual

    Public Const ITEM_NAME As String = "Combat_Manual"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 88
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A simple, leather-bound book that likely contains some skills specifically for combat.")
    End Sub

    Public Shared Shadows Function getSpecials() As String()
        Return New CombatManual().specials
    End Function
    Public Overrides Function specials() As String()
        Return {"Rapid Fire Jabs", "Focused Roundhouse", "Heavy Blow", "Focused Barrage", "Aura Cannon", "Dodge"}
    End Function
End Class
