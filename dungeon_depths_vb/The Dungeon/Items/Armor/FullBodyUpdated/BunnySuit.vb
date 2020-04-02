Public Class BunnySuit
    Inherits Armor
    'the BunnySuit is a cosmetic armor that provides +1 defence
    Sub New()
        MyBase.setName("Bunny_Suit")
        MyBase.setDesc("A sultry outfit worn by waitresses in a club. " & vbCrLf & _
                       "Fits sizes -1 through 5" & vbCrLf & _
                       "+1 DEF")
        id = 16
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 325

        MyBase.slutVarInd = 129

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(33, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(34, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(42, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(43, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(44, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(45, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(46, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(18, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(29, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(30, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(31, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(32, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(33, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
