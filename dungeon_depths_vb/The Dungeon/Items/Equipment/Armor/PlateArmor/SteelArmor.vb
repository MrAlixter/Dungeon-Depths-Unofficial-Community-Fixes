Public Class SteelArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Steel_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 5
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 7

        '|Stats|
        MyBase.d_boost = 12
        count = 0
        value = 564

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(104, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(34, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(105, True, True)

        '|Description|
        setDesc("A basic armor set forged from steel." & DDUtils.RNRN & _
                              getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
