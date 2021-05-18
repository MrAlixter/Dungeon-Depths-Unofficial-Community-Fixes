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
        MyBase.compress_breast = False
        MyBase.slut_var_ind = 71

        '|Stats|
        MyBase.d_boost = 27
        MyBase.s_boost = 10
        count = 0
        value = 3001

        '|Image Index|
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(77, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(347, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(348, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(349, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(350, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(351, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(352, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(353, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(74, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(332, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(333, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(334, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(335, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(336, True, True)

        '|Description|
        setDesc("An adorable cat themed set of lightweight armor that also boosts attack. Nya." & DDUtils.RNRN &
                                      getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
