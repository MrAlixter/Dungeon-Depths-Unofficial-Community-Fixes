Public Class VDayClothes
    Inherits Armor

    Sub New()
        MyBase.setName("Val._Day_Suit")
        MyBase.setDesc("" & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+10 DEF") '& vbCrLf & _
        '("Can not attack " & immune)
        id = 79
        If DDDateTime.isValen Then tier = 2 Else tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 10
        MyBase.count = 0
        MyBase.value = 428
        MyBase.slutVarInd = 78
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(24, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(23, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(120, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(121, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(122, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.compressesBreasts = True
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False
    End Sub
End Class
