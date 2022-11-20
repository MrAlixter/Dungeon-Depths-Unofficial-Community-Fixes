
Public Class CynnsMark
    Inherits Accessory

    Public Const ITEM_NAME As String = "Cynn's_Mark"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 253
        tier = Nothing

        '|Item Flags|
        usable = false
        cursed = True
        under_b_clothes = True
        rando_inv_allowed = False
        droppable = False

        '|Stats|
        a_boost = 5
        w_boost = 10
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)

        '|Description|
        setDesc("A glowing red tattoo that displays one's status as under the effect a particular demoness's magic." & DDUtils.RNRN &
               "During the ""Dark Pact"" quest, a transformation is triggered by raising lust or by killing opponents." & DDUtils.RNRN &
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
