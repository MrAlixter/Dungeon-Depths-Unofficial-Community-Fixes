Public Class KitsuneRobe
    Inherits Armor

    Public Const ITEM_NAME As String = "Kitsune's_Robes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 183
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True

        '|Stats|
        h_boost = 10
        d_boost = 5
        m_boost = 20
        count = 0
        value = 7777

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(253, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(254, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(255, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(256, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(172, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(173, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(174, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(175, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(176, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(177, True, True)

        cloak = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)

        '|Description|
        setDesc("A snazzy robe that identifies its wearer as the guardian of a long forgotten shrine." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.prt.setIAInd(pInd.hairacc, 5, True, False)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.prt.setIAInd(pInd.hairacc, 0, True, False)
    End Sub
End Class
