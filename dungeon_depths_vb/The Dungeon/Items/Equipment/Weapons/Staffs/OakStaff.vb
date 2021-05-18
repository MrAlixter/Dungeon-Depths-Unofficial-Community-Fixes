Public Class OakStaff
    Inherits Staff

    Sub New()
        setName("Oak_Staff")
        setDesc("A simple oak staff for casing spells." & vbCrLf &
                       "+15 Mana" & vbCrLf &
                       "+4 ATK")
        id = 21
        tier = Nothing
        usable = false
        MyBase.m_boost = 15
        MyBase.a_boost = 4
        count = 0
        value = 125
    End Sub
End Class
