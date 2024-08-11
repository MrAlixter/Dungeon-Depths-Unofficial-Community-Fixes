Public Class AAAAAASpecs
    Inherits Spellbook

    Public Shadows Const ITEM_NAME As String = "AAAAAA_Specification"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 279
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 200

        '|Description|
        setDesc("A small paper pamphlet containing a diagam of a sextuple-A battery.  On its back, a simple incantation is scrawled in ink.")
    End Sub

    Public Overrides Function spells() As String()
        Return {"Summon Battery"}
    End Function
    Public Overrides Function selfPolyForms() As String()
        Return {}
    End Function
    Public Overrides Function enemPolyForms() As String()
        Return {}
    End Function

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Return tier
    End Function
End Class
