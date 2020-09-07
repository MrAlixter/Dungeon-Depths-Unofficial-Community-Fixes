Public Class VSkimpyClothes
    Inherits Armor

    Sub New()
        MyBase.setName("Very_Skimpy_Clothes")
        MyBase.setDesc("A soft set of clothing that definitely seems crafted to show off its wearer's body." & DDUtils.RNRN &
                       "Fits sizes 2 to 6" & DDUtils.RNRN &
                       "+15 HP")
        id = 192
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.hBoost = 15
        MyBase.count = 0
        MyBase.value = 0
        MyBase.antiSlutVarInd = 191
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(177, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(178, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(179, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(180, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(181, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
