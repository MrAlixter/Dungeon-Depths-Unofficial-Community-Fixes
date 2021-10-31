Public Class CatLingerie
    Inherits Armor
    'CatLingerie is a cosmetic armor that doesn't provide a defense bonus
    Sub New()
        '|ID Info|
        setName("Cat_Lingerie")
        id = 12
        tier = Nothing

        '|Item Flags|
        usable = False
        anti_slut_ind = 146
        compress_breast = True
        show_underboob = True

        '|Stats|
        d_boost = 0
        count = 0
        value = 300

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(38, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(39, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(40, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(41, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(85, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(86, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(87, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(88, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(89, True, True)

        '|Description|
        setDesc("A skimpy, pink, cat themed set of underwear. Nya." & DDUtils.RNRN &
                getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
