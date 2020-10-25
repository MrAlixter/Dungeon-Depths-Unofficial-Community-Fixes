Public Class Spellcyclopedia
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Spellcyclopedia")
        id = 242
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 0

        '|Description|
        MyBase.setDesc("TFng")
    End Sub
    Overrides Sub use(ByRef p As Player)

    End Sub
End Class
