Public Class CowCosplay
    Inherits Armor

    Sub New()
        MyBase.setName("Cow_Cosplay")

        id = 196
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 50
        MyBase.antiSlutVarInd = 31

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(66, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(267, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(268, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(269, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(270, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(271, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(272, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(273, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(274, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(46, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(158, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(159, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(160, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(161, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(162, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(163, True, True)
        MyBase.compressesBreasts = False
        MyBase.hidesDick = False

        MyBase.setDesc("A cow print bra created to hold cow sized breasts." & DDUtils.RNRN &
                                     getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
