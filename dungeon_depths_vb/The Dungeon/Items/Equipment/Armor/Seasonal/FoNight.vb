Public Class FoNight
    Inherits Armor

    Dim oldHat As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Sub New()
        '|ID Info|
        setName("Frock_of_Night")
        id = 166
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.droppable = False
        MyBase.slut_var_ind = 250

        '|Stats|
        MyBase.d_boost = 3
        MyBase.m_boost = 20
        MyBase.s_boost = -3
        count = 0
        value = 200

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(59, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(226, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(227, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(228, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(229, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(43, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(141, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(142, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(143, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(144, True, True)

        '|Description|
        setDesc("A black dress commonly worn by those who aren't afraid of the dark." & DDUtils.RNRN &
                                    getSizeInformation() & vbcrlf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        oldHat = p.prt.iArrInd(pInd.hat)

        p.prt.setIAInd(pInd.hat, 11, True, True)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.prt.iArrInd(pInd.hat) = oldHat
    End Sub
End Class
