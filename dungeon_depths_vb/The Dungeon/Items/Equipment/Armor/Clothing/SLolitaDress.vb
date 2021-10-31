Public Class SLolitaDress
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Lolita_Dress_(Sweet)")
        id = 151
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.cursed = True

        '|Stats|
        MyBase.d_boost = 5
        MyBase.s_boost = -5
        count = 0
        value = 2000

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(55, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(219, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(220, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(221, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(222, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(67, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(297, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(298, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(299, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(300, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(301, True, True)

        '|Description|
        setDesc("A poofy pink dress." & DDUtils.RNRN &
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
