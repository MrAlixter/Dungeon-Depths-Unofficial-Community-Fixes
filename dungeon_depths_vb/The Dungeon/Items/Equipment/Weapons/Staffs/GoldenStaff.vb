Public Class GoldenStaff
    Inherits Staff

    Sub New()
        setName("Golden_Staff")
        setDesc("A glowing runed staff for powerful spellcasters. +50 MANA")
        id = 41
        tier = Nothing
        usable = false
        MyBase.m_boost = 50
        MyBase.a_boost = 10
        count = 0
        value = 3200
    End Sub
End Class
