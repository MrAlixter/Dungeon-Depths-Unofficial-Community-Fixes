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
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(55, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(219, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(220, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(221, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(222, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(67, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(297, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(298, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(299, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(300, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(301, True, True)

        '|Description|
        setDesc("A poofy pink dress." & DDUtils.RNRN &
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
