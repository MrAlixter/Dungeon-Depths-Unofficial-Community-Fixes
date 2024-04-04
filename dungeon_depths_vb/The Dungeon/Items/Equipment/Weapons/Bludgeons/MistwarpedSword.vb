Public Class MistwarpedSword
    Inherits Bludgeon

    Public Const ITEM_NAME As String = "Mistwarped_Sword"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 426
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 6
        count = 0
        value = 138

        '|Description|
        setDesc("A wobbly pink phallus, about the length of a single-handed sword.  It doesn't have an edge, but it seems to have enough heft to do some damage." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
