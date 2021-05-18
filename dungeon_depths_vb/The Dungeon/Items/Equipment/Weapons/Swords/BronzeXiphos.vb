Public Class BronzeXiphos
    Inherits Sword

    Sub New()
        '|ID Info|
        setName("Bronze_Xiphos")
        id = 23
        tier = 3

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.a_boost = 25
        count = 0
        value = 900

        '|Description|
        setDesc("A neat curved double-edged blade forged from bronze." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
