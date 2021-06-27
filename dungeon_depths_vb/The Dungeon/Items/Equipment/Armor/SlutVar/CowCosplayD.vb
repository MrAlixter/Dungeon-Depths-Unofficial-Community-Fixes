Public Class CowCosplayD
    Inherits Armor

    Sub New()
        setName("Cow_Cosplay_(Demonic)")

        id = 221
        tier = Nothing
        usable = false
        MyBase.d_boost = 1
        count = 0
        value = 50
        MyBase.anti_slut_ind = 71

        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(315, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(316, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(317, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(318, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(319, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(239, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(240, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(241, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(242, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(243, True, True)
        MyBase.compress_breast = False
        MyBase.hide_dick = True

        setDesc("An unholy outfit for busty bovine demons.  While it grants its wearer an undenyable charm, it does make it harder for other succubi to take them seriously as anything other than a pet." & DDUtils.RNRN &
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
