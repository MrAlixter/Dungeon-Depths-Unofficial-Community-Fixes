Public Class SkimpyClothes
    Inherits Armor

    Sub New()
        MyBase.setName("Skimpy_Clothes")
        MyBase.setDesc("A soft set of clothing that seems almost crafted to show off its wearer's body." & vbCrLf & vbCrLf &
                       "Fits sizes -1 to 4")
        id = 191
        tier = Nothing
        MyBase.setUsable(False)

        MyBase.count = 0
        MyBase.value = 0
        MyBase.slutVarInd = 192
        MyBase.antiSlutVarInd = 184
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(25, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(26, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(7, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(20, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(16, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(18, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Public Overrides Function getAntiSlutVarInd() As Object
        Select Case wearer.sState.iArrInd(pInd.clothes).Item1
            Case 0
                Return 184
            Case 1
                Return 185
            Case 2
                Return 186
            Case 3
                Return 187
            Case 4
                Return 188
            Case 5
                Return 189
            Case 6
                Return 190
            Case Else
                Return 184
        End Select
    End Function
End Class
