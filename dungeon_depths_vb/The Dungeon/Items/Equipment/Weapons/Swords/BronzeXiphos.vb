Public Class BronzeXiphos
    Inherits Sword

    Sub New()
        '|ID Info|
        MyBase.setName("Bronze_Xiphos")
        id = 23
        tier = 3

        '|Item Flags|
        MyBase.setUsable(False)

        '|Stats|
        MyBase.aBoost = 25
        count = 0
        value = 900

        '|Description|
        MyBase.setDesc("A neat curved double-edged blade forged from bronze." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
