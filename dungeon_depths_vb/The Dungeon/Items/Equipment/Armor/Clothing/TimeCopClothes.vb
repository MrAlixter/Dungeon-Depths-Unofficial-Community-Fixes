
Public Class TimeCopClothes
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Time_Cop_Clothes")
        id = 282
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        rando_inv_allowed = False

        '|Stats|
        w_boost = 2
        MyBase.s_boost = 2
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(81, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(82, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(360, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(361, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(362, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(78, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(79, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(344, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(345, True, True)

        '|Description|
        setDesc("Tactical clothes that are standard issue for a time cop." & DDUtils.RNRN &
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
