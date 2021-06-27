Public Class KitsuneRobe
    Inherits Armor

    Sub New()
        setName("Kitsune's_Robes")

        id = 183
        tier = Nothing
        usable = false
        h_boost = 10
        MyBase.d_boost = 5
        MyBase.m_boost = 20
        count = 0
        value = 7777

        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(253, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(254, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(255, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(256, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(172, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(173, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(174, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(175, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(176, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(177, True, True)

        MyBase.cloak = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)

        MyBase.compress_breast = True

        setDesc("A snazzy robe that identifies its wearer as the guardian of a long forgotten shrine." & DDUtils.RNRN & _
                                  getSizeInformation() & vbcrlf & getStatInformation())
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
