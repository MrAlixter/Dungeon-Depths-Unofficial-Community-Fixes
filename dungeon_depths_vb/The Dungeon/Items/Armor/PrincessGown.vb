Public Class PrincessGown
    Inherits Armor
    Sub New()
        MyBase.setName("Regal_Gown")
        MyBase.setDesc("The frilly ballgown of a bonafide princess." & vbCrLf & "+2 MaxMana")
        id = 75
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(48, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(49, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(50, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
