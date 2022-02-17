Public Class BronzeXiphos
    Inherits Sword

    Public Const ITEM_NAME As String = "Bronze_Xiphos"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
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
