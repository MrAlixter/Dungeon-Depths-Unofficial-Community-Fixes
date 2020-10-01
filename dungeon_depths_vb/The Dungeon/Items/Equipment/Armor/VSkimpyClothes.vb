Public Class VSkimpyClothes
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Very_Skimpy_Clothes")
        id = 192
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.antiSlutVarInd = 191

        '|Stats|
        MyBase.hBoost = 15
        MyBase.count = 0
        MyBase.value = 0

        '|Image Index|
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(177, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(178, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(179, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(180, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(181, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(276, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(277, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(278, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(279, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(280, True, True)

        '|Description|
        MyBase.setDesc("A soft set of clothing that definitely seems crafted to show off its wearer's body." & DDUtils.RNRN &
                               getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
