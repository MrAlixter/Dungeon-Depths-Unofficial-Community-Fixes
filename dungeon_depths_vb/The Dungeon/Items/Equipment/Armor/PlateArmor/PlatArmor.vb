Public Class PlatArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Platinum_Armor")
        id = 265
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 266

        '|Stats|
        MyBase.dBoost = 45
        MyBase.count = 0
        MyBase.value = 5200

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(78, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(79, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(354, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(355, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(75, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(76, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(337, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(338, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(339, True, True)

        '|Description|
        MyBase.setDesc("A glistening set of full plate armor for those who want to be superbly safeguarded." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
