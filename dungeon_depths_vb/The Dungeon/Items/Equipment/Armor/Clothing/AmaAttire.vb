
Public Class AmaAttire
    Inherits Armor

    Public Const ITEM_NAME As String = "Amazonian_Attire"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 99
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        hide_dick = False
        anti_slut_ind = 302

        '|Stats|
        a_boost = 20
        s_boost = 20
        count = 0
        value = 1500

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(36, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(136, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(137, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(138, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(17, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(25, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(26, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(27, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(28, True, True)

        '|Description|
        setDesc("Apparel that aptly accentuates all an Amazon's adventageous attributes amazingly.  Alliteration!" & DDUtils.RNRN &
                                      getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
