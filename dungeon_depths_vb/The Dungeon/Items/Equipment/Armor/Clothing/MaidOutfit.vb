Public Class MaidOutfit
    Inherits Armor
    Sub New()
        '|ID Info|
        setName("Maid_Outfit")
        id = 72
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        slut_var_ind = 169
        anti_slut_ind = 322

        '|Stats|
        s_boost = 2
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(58, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(59, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(60, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(61, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(21, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(59, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(60, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(61, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(62, True, True)
        'usize4 = New Tuple(Of Integer, Boolean, Boolean)(63, True, True)

        '|Description|
        setDesc("A stereotypical French maid's outfit." & DDUtils.RNRN & _
                                    getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
