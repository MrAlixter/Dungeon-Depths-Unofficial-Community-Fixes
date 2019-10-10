Public Class MaidOutfit
    Inherits Armor
    Sub New()
        MyBase.setName("Maid_Outfit")
        MyBase.setDesc("A stereotypical French maid's outfit." & vbCrLf & "+2 ATK")
        id = 72
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.sBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(58, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(59, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(60, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(61, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
