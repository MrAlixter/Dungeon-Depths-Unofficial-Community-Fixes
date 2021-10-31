Public Class SportBra
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Sports_Bra")
        id = 47
        tier = 3

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True

        '|Stats|
        d_boost = 1
        s_boost = 5
        count = 0
        value = 400

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(62, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(63, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(64, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(65, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(129, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(130, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(131, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(132, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(133, True, True)

        '|Description|
        setDesc("A sports bra made of a strechy matierial that allows it to fit many different bust sizes." & DDUtils.RNRN & _
                              getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
