Public Class OakStaff
    Inherits Staff

    Sub New()
        MyBase.setName("Oak_Staff")
        MyBase.setDesc("A simple oak staff for casing spells." & vbCrLf &
                       "+15 Mana" & vbCrLf &
                       "+4 ATK")
        id = 21
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 15
        MyBase.aBoost = 4
        count = 0
        value = 125
    End Sub
End Class
