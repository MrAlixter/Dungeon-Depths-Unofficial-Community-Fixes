Public Class BunnySuit
    Inherits Armor

    Public Const ITEM_NAME As String = "Bunny_Suit"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 16
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        slut_var_ind = 129

        '|Stats|
        d_boost = 1
        s_boost = 7
        count = 0
        value = 325

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(33, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(34, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(42, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(43, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(44, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(45, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(18, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(29, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(30, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(31, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(32, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(33, True, True)

        '|Description|
        setDesc("A sultry outfit worn by waitresses in a club. " & DDUtils.RNRN &
                                      getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
