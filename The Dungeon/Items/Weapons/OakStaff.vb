Public Class OakStaff
    Inherits Staff

    Sub New()
        MyBase.setName("Oak_Staff")
        MyBase.setDesc("A simple oak staff for casing spells. +15 Mana")
        MyBase.setUsable(False)
        MyBase.mBoost = 15
        count = 0
        value = 125
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
