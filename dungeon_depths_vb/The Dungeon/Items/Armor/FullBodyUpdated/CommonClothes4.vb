Public Class CommonClothes4
    Inherits Armor

    Sub New()
        MyBase.setName("Ordinary_Clothes")
        MyBase.setDesc("Ordinary clothes for a ordinary adventurer." & vbCrLf & vbCrLf &
                       "Fits sizes -1 to 2" & vbCrLf & vbCrLf &
                       "+1 Max Mana" & vbCrLf &
                       "+1 SPD")
        id = 188
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 1
        MyBase.sBoost = 1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(4, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(261, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(4, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(103, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(8, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(9, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(9, True, False)
    End Sub
End Class
