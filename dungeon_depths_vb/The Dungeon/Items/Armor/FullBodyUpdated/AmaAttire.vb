
Public Class AmaAttire
    Inherits Armor

    Sub New()
        MyBase.setName("Amazonian_Attire")
        MyBase.setDesc("Apparel that aptly accentuates all an Amazon's adventageous attributes amazingly.  Alliteration!" & vbCrLf & _
                       "Fits sizes 0 through 3" & vbCrLf & _
                       "+20 ATK, + 20 SPD")
        id = 99
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 20
        MyBase.sBoost = 20
        MyBase.count = 0
        MyBase.value = 1500
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(36, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(136, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(137, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(138, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(17, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(25, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(26, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(27, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(28, True, True)
        MyBase.compressesBreasts = True
        MyBase.hidesDick = False
    End Sub
End Class
