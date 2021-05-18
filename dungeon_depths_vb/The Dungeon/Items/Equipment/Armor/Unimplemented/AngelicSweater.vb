Public Class AngelicSweater
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Angelic_Sweater")
        id = 199
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.droppable = False
        rando_inv_allowed = False
        MyBase.compress_breast = True
        MyBase.hide_dick = False

        '|Stats|
        h_boost = 10
        MyBase.d_boost = 5
        MyBase.m_boost = 20
        count = 0
        value = 7777

        '|Image Index|
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(280, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(281, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(282, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(283, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(178, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(179, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(180, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(181, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(182, True, True)

        '|Description|
        setDesc("A glittering, heavenly soft sweater." & DDUtils.RNRN &
                                     getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
