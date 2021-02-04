Public Class PlatinumStaff
    Inherits Staff

    Sub New()
        '|ID Info|
        MyBase.setName("Platinum_Staff")
        id = 257
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isMonsterDrop = False

        '|Stats|
        count = 0
        value = 5000
        MyBase.mBoost = 70
        MyBase.aBoost = 2


        '|Description|
        MyBase.setDesc("A glistening, jeweled staff crafted for supreme spellcasters." & DDUtils.RNRN &
                        getStatInformation())
    End Sub
End Class
