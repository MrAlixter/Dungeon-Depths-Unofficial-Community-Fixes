Public Class VNightLingerie
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Val._Night_Lingerie")
        id = 78
        If DDDateTime.isValen Then tier = 2 Else tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.antiSlutVarInd = 79
        MyBase.value = 428

        '|Image Index|
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(252, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(117, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(118, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(119, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(192, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(193, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(194, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(195, True, True)

        '|Description|
        MyBase.setDesc("A lovely set of black, white, and red undergarments perfect for a romantic evening with a signifigant other." & DDUtils.RNRN &
                       getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
