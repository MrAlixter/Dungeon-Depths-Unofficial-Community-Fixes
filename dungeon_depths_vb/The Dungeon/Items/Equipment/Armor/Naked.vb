Public Class Naked
    Inherits Armor
    Sub New()
        '|ID Info|
        setName("Naked")
        id = Nothing
        tier = Nothing

        '|Item Flags|       
        usable = False
        droppable = False
        rando_inv_allowed = False
        compress_breast = False
        hide_dick = False
        adjust_sleeve_layer = False

        '|Stats|
        count = 0
        value = 100000

        '|Image Index|
        MyBase.bsizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)

        MyBase.usizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)

        '|Description|
        setDesc("NO CLOTHES")

    End Sub
End Class
