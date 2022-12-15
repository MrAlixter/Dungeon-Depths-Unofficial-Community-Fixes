Public Class CatArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Cat_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 146
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        slut_var_ind = 12

        '|Stats|
        d_boost = 15
        a_boost = 7
        s_boost = 33
        count = 0
        value = 2456

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(54, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(211, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(212, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(213, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(214, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(26, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(73, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(74, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(75, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(76, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(77, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(78, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        cloak = New Tuple(Of Integer, Boolean, Boolean)(34, True, False)

        '|Description|
        setDesc("An adorable, cat-themed set of lightweight armor that also boosts one's attack.  Nya." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
