Public Class BookOSpecials
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Big_Book_O'_Specials")
        id = 243
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 0

        '|Description|
        MyBase.setDesc("A large manual that explains how to make the best use of certain skills, as long as you know the basics.")
    End Sub
    Overrides Sub use(ByRef p As Player)
        SpellSpecDescBackend.toPNLSpellSpecDesc(Nothing, Nothing, p, SpellOrSpec.SPECIAL)
    End Sub
End Class
