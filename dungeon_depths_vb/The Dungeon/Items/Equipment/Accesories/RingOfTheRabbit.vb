Public Class RingOfTheRabbit
    Inherits Accessory

    Public Const ITEM_NAME As String = "Ring_of_the_Rabbit"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 391
        tier = 3

        '|Item Flags|
        usable = False

        '|Stats|
        s_boost = 5
        count = 0
        value = 2000

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A black crystal ring that seems unassuming enough." & DDUtils.RNRN &
                "When the wearer dodges, restores 40% of their maximum health." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
