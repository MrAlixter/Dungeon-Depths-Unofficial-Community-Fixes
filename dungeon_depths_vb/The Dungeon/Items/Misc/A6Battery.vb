Public Class A6Battery
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("AAAAAA_Battery")
        id = 261
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 2

        '|Description|
        MyBase.setDesc("A small, standardized battery cell roughly the length of a gold coin.  While on its own it is more or less useless, in the right futuristic technology this battery can accomplish nearly anything.")
    End Sub
End Class
