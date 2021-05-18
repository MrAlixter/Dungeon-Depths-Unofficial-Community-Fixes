Public Class BunnySuit
    Inherits Armor
    'the BunnySuit is a cosmetic armor that provides +1 defense
    Sub New()
        '|ID Info|
        setName("Bunny_Suit")
        id = 16
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 129

        '|Stats|
        MyBase.d_boost = 1
        count = 0
        value = 325

        '|Image Index|
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

        '|Description|
        setDesc("A sultry outfit worn by waitresses in a club. " & DDUtils.RNRN &
                                      getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
