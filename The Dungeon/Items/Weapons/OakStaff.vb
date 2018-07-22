Public Class OakStaff
    Inherits Staff

    Sub New()
        MyBase.setName("Oak_Staff")
        MyBase.setDesc("A simple oak staff for casing spells. +15 Mana")
        id = 21
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 15
        MyBase.aBoost = 4
        count = 0
        value = 125
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
