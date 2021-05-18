Public Class VDayClothes
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Val._Day_Suit")
        id = 79
        If DDDateTime.isValen Then tier = 2 Else tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.droppable = False
        rando_inv_allowed = False

        '|Stats|
        MyBase.d_boost = 10
        count = 0
        value = 428
        MyBase.slut_var_ind = 78

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(24, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(23, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(120, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(121, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(122, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(80, True, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(81, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(346, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(347, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(348, True, True)

        '|Description|
        setDesc("A handsome black, white, and red suit perfect for a romantic dinner with a signifigant other." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
