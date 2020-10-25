Public Class WizardStaff
    Inherits Staff

    Sub New()
        MyBase.setName("Wizard_Staff")
        MyBase.setDesc("A ornate wooden staff for casting advanced spells. +30 mana")
        id = 22
        tier = 3
        MyBase.setUsable(False)
        MyBase.mBoost = 30
        MyBase.aBoost = 7
        count = 0
        value = 900
    End Sub
End Class
