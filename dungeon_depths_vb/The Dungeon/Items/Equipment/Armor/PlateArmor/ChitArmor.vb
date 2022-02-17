Public Class ChitArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Chitin_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 64
        tier = 3

        '|Item Flags|
        droppable = True
        usable = False
        compress_breast = True
        show_underboob = True

        '|Stats|
        d_boost = 15
        s_boost = 10
        count = 0
        value = 346

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(17, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(265, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(93, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(94, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(95, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(35, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(110, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(111, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(112, True, True)

        '|Description|
        setDesc("A set of armor built out of discarded chitin, commonly made and used by arachne huntresses." & DDUtils.RNRN &
                                       getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class

