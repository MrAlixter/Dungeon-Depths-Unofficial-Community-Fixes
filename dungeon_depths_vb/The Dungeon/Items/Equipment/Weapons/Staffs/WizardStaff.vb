Public Class WizardStaff
    Inherits Staff

    Public Const ITEM_NAME As String = "Wizard_Staff"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 22
        tier = 3

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 30
        a_boost = 7
        count = 0
        value = 900

        '|Description|
        setDesc("A ornate wooden staff for casting advanced spells." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
