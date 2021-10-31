Public Class AnniverseryClothes
    Inherits Armor

    Sub New()
        setName("Anniversery_Armor")
        setDesc("An armor set designed to commemorate the anniversery of a specific game." & vbCrLf & _
                       "+30 DEF, +10 SPD, +8 Mana")
        id = 5
        If Date.Now.Month.Equals(9) And (Date.Now.Day.Equals(9) Or Date.Now.Day.Equals(10) Or Date.Now.Day.Equals(11)) Then
            tier = 3
        Else
            tier = Nothing
        End If

        usable = false
        MyBase.d_boost = 30
        MyBase.s_boost = 10
        MyBase.m_boost = 8
        count = 0
        value = 2017

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
    End Sub
End Class
