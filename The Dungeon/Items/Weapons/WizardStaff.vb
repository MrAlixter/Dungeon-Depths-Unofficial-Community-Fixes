Public Class WizardStaff
    Inherits Staff

    Sub New()
        MyBase.setName("Wizard_Staff")
        MyBase.setDesc("A ornate wooden staff for casting advanced spells. +30 mana")
        MyBase.setUsable(False)
        MyBase.mBoost = 30
        count = 0
        value = 900
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
