Public Class PlatArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Platinum_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 265
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 266

        '|Stats|
        MyBase.d_boost = 45
        count = 0
        value = 5200

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(78, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(79, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(354, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(355, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(75, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(76, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(337, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(338, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(339, True, True)

        '|Description|
        setDesc("A glistening set of full plate armor for those who want to be superbly safeguarded." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
