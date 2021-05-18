Public Class ScepterOfAsh
    Inherits Staff

    Sub New()
        setName("Scepter_of_Ash")
        setDesc("A polished staff of a light wood capped off by a gistening, vaugly woman shaped red gem.  While the ""Ash"" portion of its name might refer to the type of wood that its made of, it could also refer to the immense magical power it bears." &
                       DDUtils.RNRN & "+12 ATK, +42 Max Mana")
        id = 145
        tier = Nothing
        usable = false
        MyBase.m_boost = 42
        MyBase.a_boost = 12
        count = 0
        value = 2567
    End Sub
End Class
