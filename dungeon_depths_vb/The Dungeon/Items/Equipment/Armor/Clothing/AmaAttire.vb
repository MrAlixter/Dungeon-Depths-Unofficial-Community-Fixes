
Public Class AmaAttire
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Amazonian_Attire")
        id = 99
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.hide_dick = False

        '|Stats|
        MyBase.a_boost = 20
        MyBase.s_boost = 20
        count = 0
        value = 1500

        '|Image Index|
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(36, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(136, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(137, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(138, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(17, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(25, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(26, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(27, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(28, True, True)

        '|Description|
        setDesc("Apparel that aptly accentuates all an Amazon's adventageous attributes amazingly.  Alliteration!" & DDUtils.RNRN &
                                      getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
