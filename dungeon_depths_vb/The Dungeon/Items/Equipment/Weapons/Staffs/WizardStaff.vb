Public Class WizardStaff
    Inherits Staff

    Sub New()
        setName("Wizard_Staff")
        setDesc("A ornate wooden staff for casting advanced spells. +30 mana")
        id = 22
        tier = 3
        usable = false
        MyBase.m_boost = 30
        MyBase.a_boost = 7
        count = 0
        value = 900
    End Sub
End Class
