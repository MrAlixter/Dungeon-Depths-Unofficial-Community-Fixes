Public Class MaidOutfit
    Inherits Armor
    Sub New()
        MyBase.setName("Maid_Outfit")
        MyBase.setDesc("A stereotypical French maid's outfit." & vbCrLf & "+2 SPD")
        id = 72
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.sBoost = 2
        MyBase.count = 0
        MyBase.value = 0

        slutVarInd = 169

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(58, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(59, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(60, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(61, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(21, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(59, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(60, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(61, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(62, True, True)
        'MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(63, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
