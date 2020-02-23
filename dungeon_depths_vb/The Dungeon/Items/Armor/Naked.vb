Public Class Naked
    Inherits Armor
    Sub New()
        MyBase.setName("Naked")
        MyBase.setDesc("NO CLOTHES")
        id = Nothing
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        MyBase.count = 0
        MyBase.value = 100000
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        MyBase.compressesBreasts = False
    End Sub
End Class
