Public Class GoldArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Gold_Armor")
        id = 38
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 39

        '|Stats|
        MyBase.dBoost = 30
        MyBase.count = 0
        MyBase.value = 3800

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(51, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(52, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(53, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(59, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(264, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(264, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(265, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(266, True, True)

        '|Description|
        MyBase.setDesc("A expensive looking armor set made for the wealthy." & DDUtils.RNRN &
                                          getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
