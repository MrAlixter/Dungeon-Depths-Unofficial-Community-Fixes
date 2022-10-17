Public Class BracedHeadband
    Inherits Accessory

    Public Const ITEM_NAME As String = "Braced_Headband"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 139
        tier = 2

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 5
        d_boost = 5
        w_boost = 5
        count = 0
        value = 1100

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)

        '|Description|
        setDesc("A crimson length of cloth to be wrapped around the forehead of a fighter.  A riveted steel plate gives more protection than fabric alone can manage." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
