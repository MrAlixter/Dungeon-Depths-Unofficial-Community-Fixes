
Public Class AlizasMark
    Inherits Accessory

    Public Const ITEM_NAME As String = "Aliza's_Mark"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 456
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        under_b_clothes = True
        rando_inv_allowed = False
        droppable = False

        '|Stats|
        m_boost = 99
        w_boost = -999
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(60, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(60, True, True)

        '|Description|
        setDesc("A glowing violet tattoo that displays one's status as under the effect a particular demoness's magic." & DDUtils.RNRN &
               getStatInformation())
    End Sub

    Public Overrides Sub discard()
        TextEvent.pushAndLog("You can't discard this item!")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
    End Sub
End Class
