
Public Class CynnsMark
    Inherits Accessory
    Sub New()
        '|ID Info|
        setName("Cynn's_Mark")
        id = 253
        tier = Nothing

        '|Item Flags|
        usable = false
        cursed = True
        underClothes = True
        rando_inv_allowed = False
        MyBase.droppable = False

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)

        '|Description|
        setDesc("A glowing red tattoo that displays one's status as under the effect a particular demoness's magic." & DDUtils.RNRN &
                       "Transformation triggered by raising lust or by killing opponents." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Overrides Sub discard()
        Game.pushLblEvent("You can't discard this!")
        Game.pushLstLog("You can't discard this!")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
    End Sub
End Class
