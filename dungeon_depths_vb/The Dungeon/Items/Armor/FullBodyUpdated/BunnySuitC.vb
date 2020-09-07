Public Class BunnySuitC
    Inherits Armor
    'the BunnySuit is a cosmetic armor that provides +1 defense
    Sub New()
        MyBase.setName("Bunny_Suit_(Classic)")
        MyBase.setDesc("A sultry outfit worn by waitresses in a club.  This particular bunny suit is from the far off age of ""2017""." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+100 Max HP" & vbCrLf & _
                       "+40 SPD")
        id = 222
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.hBoost = 100
        MyBase.dBoost = 40
        MyBase.count = 0
        MyBase.value = 0

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(68, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(325, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(321, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(322, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(323, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(324, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(55, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(247, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(248, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(249, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(250, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(251, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
