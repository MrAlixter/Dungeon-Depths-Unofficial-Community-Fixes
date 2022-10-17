Public Class BunnySuitA
    Inherits Armor

    Public Const ITEM_NAME As String = "Armored_Bunny_Suit"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 94
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 129

        '|Stats|
        d_boost = 16
        s_boost = 5
        count = 0
        value = 2534

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(35, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(264, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(133, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(134, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(135, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(20, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(54, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(55, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(56, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(57, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(58, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)

        '|Description|
        setDesc("Once a sultry outfit worn by waitresses in a club, this bunny suit has been modified to provide more defense, and to improve mobility." & DDUtils.RNRN &
                                     getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
