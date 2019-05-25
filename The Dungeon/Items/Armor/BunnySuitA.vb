Public Class BunnySuitA
    Inherits Armor
    Sub New()
        MyBase.setName("Armored_Bunny_Suit")
        MyBase.setDesc("Once a sultry outfit worn by waitresses in a club, this bunny suit has been modified to provide more defence, and to improve mobility." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+16 DEF, +5 SPD")
        id = 94
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 16
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 2534
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(35, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(133, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(134, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(135, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
