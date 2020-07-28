Public Class GoddessGown
    Inherits Armor
    Sub New()
        MyBase.setName("Goddess_Gown")
        MyBase.setDesc("A gown worn by a goddess." & vbCrLf & "+2 Max Mana")
        id = 73
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(89, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(90, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(49, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(50, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(51, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(52, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(53, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
