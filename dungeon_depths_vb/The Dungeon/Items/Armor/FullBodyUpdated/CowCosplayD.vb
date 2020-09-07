Public Class CowCosplayD
    Inherits Armor

    Sub New()
        MyBase.setName("Cow_Cosplay_(Demonic)")
        MyBase.setDesc("An unholy outfit for busty bovine demons.  While it grants its wearer an undenyable charm, it does make it harder for other succubi to take them seriously as anything other than a pet." & vbCrLf & _
                       "Fits sizes 3 through 7" & vbCrLf & _
                       "+1 DEF")
        id = 221
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 50
        MyBase.antiSlutVarInd = 31

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
        MyBase.compressesBreasts = False
        MyBase.hidesDick = True
    End Sub
End Class
