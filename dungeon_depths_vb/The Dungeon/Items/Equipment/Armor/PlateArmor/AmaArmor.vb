
Public Class AmaArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Amazonian_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 302
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        hide_dick = False
        slut_var_ind = 99

        '|Stats|
        a_boost = 20
        d_boost = 20
        s_boost = 20
        count = 0
        value = 2500

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(390, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(391, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(392, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(393, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(394, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(374, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(375, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(376, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(377, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(378, True, True)

        '|Description|
        setDesc("An aegis that aptly accentuates all an Amazon's adventageous attributes amazingly.  Alliteration!" & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
