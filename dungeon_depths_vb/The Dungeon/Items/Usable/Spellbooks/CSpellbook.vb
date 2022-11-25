Public Class CSpellbook
    Inherits Spellbook

    Public Shadows Const ITEM_NAME As String = "Crimson_Spellbook"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 226
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 666

        '|Description|
        setDesc("A smoldering leather-bound book that contains something magic written by a succubus.")
    End Sub

    Public Overrides Function spells() As String()
        Return {"Raise Lust", "Puff Up", "Hellfireball", "Reductive Mending"}
    End Function
    Public Overrides Function selfPolyForms() As String()
        Return {}
    End Function
    Public Overrides Function enemPolyForms() As String()
        Return {}
    End Function

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If DDDateTime.isValen Then Return 2

        Return MyBase.getTier(floor_num)
    End Function
End Class
