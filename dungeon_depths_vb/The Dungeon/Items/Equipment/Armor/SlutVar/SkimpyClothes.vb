Public Class SkimpyClothes
    Inherits Armor

    Public Const ITEM_NAME As String = "Skimpy_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 191
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        slut_var_ind = 192
        anti_slut_ind = 184

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(25, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(26, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(7, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(20, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(16, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(18, True, True)

        '|Description|
        setDesc("A soft set of clothing that seems almost crafted to show off its wearer's body." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
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
