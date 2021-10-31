Public Class CowArmor
    Inherits Armor

    Dim oldHat As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)

    Sub New()
        '|ID Info|
        setName("Cow_Print_Armor")
        id = 262
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = False
        show_underboob = True
        slut_var_ind = 71

        '|Stats|
        d_boost = 27
        s_boost = 10
        count = 0
        value = 3001

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(77, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(347, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(348, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(349, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(350, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(351, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(352, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(353, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(74, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(332, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(333, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(334, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(335, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(336, True, True)

        '|Description|
        setDesc("An adorable cat themed set of lightweight armor that also boosts attack. Nya." & DDUtils.RNRN &
                                      getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
