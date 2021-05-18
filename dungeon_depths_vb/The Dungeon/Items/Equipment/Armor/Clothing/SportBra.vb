Public Class SportBra
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Sports_Bra")
        id = 47
        tier = 3

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True

        '|Stats|
        MyBase.d_boost = 1
        MyBase.s_boost = 5
        count = 0
        value = 400

        '|Image Index|
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(62, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(63, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(64, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(65, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(129, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(130, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(131, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(132, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(133, True, True)

        '|Description|
        setDesc("A sports bra made of a strechy matierial that allows it to fit many different bust sizes." & DDUtils.RNRN & _
                              getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
