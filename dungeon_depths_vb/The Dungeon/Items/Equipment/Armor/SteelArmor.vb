Public Class SteelArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Steel_Armor")
        id = 5
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 7

        '|Stats|
        MyBase.dBoost = 12
        MyBase.count = 0
        MyBase.value = 564

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(34, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(34, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(105, True, True)

        '|Description|
        MyBase.setDesc("A basic armor set forged from steel." & DDUtils.RNRN & _
                              getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
