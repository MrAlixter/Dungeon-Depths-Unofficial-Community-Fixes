Public Class SkimpyClothesD
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Skimpy_Clothes_(D)")
        id = 220
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(310, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(311, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(312, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(313, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(314, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(234, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(235, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(236, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(237, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(238, True, True)

        '|Description|
        setDesc("A demonic set of clothing that seems almost crafted to show off its wearer's body." & DDUtils.RNRN & _
                              getSizeInformation() & vbcrlf & getStatInformation())
    End Sub

    Public Overrides Function getAntiSlutInd() As Object
        Select Case owner.sState.iArrInd(pInd.clothes).Item1
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
