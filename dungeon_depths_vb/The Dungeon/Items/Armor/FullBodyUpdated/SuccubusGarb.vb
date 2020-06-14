Public Class SuccubusGarb
    Inherits Armor
    Sub New()
        MyBase.setName("Succubus_Garb")
        MyBase.setDesc("The scanty clothes of a succubus." & vbCrLf & "+2 ATK")
        id = 74
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(91, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(92, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(122, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(123, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(124, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(125, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
