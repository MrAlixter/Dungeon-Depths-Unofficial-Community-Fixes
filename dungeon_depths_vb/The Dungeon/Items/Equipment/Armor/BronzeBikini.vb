Public Class BronzeBikini
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Bronze_Bikini")
        id = 85
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.antiSlutVarInd = 83

        '|Stats|
        MyBase.dBoost = 3
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 250

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(30, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(31, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(128, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(129, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(130, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(24, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(25, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(68, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(69, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(70, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(71, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(72, True, True)

        '|Description|
        MyBase.setDesc("A bronze bikini covered in a fine mail of bronze rings.  While it won't stop very many hits, it is also lightweight enough to move around freely." & DDUtils.RNRN &
                                   getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
