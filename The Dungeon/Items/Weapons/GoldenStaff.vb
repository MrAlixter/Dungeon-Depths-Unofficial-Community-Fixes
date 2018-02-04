Public Class GoldenStaff
    Inherits Staff

    Sub New()
        MyBase.setName("Golden_Staff")
        MyBase.setDesc("A glowing runed staff for powerful spellcasters. +50 MANA")
        MyBase.setUsable(False)
        MyBase.mBoost = 50
        count = 0
        value = 1800
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
