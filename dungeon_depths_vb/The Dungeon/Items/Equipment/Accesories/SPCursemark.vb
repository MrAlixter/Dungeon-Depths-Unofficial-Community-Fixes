Public Class SPCursemark
    Inherits Accessory

    Public Const ITEM_NAME As String = "Cryptic_Cursemark"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 389
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        under_b_clothes = True

        '|Stats|
        m_boost = 6
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(53, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(53, True, True)

        '|Description|
        setDesc("A glowing violet tattoo that displays one's status as under the effect of demonic magic." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub discard()
        TextEvent.push("You can't discard this!")
        TextEvent.pushLog("You can't discard this!")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.learnSpell("Raise Lust")
    End Sub
End Class
