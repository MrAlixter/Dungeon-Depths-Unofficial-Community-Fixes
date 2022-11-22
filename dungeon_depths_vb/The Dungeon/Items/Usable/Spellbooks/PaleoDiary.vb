Public Class PaleoDiary
    Inherits Spellbook

    Public Shadows Const ITEM_NAME As String = "Paleomancer's_Diary"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 277
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 800

        '|Description|
        setDesc("A simple, leather-bound journal written by a wizard studying the past that likely contains something cool and magic.")
    End Sub

    Public Overrides Function spells() As String()
        Return {"Polymorph Enemy"}
    End Function
    Public Overrides Function selfPolyForms() As String()
        Return {}
    End Function
    Public Overrides Function enemPolyForms() As String()
        Return {"Trilobite"}
    End Function
End Class
