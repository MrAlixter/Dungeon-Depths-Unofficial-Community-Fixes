Public Class AnniverseryClothes
    Inherits Armor

    Sub New()
        MyBase.setName("Anniversery_Armor")
        MyBase.setDesc("An armor set designed to commemorate the anniversery of a specific game." & vbCrLf & _
                       "+30 DEF, +10 SPD, +8 Mana")
        id = 5
        If Date.Now.Month.Equals(9) And (Date.Now.Day.Equals(9) Or Date.Now.Day.Equals(10) Or Date.Now.Day.Equals(11)) Then
            tier = 3
        Else
            tier = Nothing
        End If

        MyBase.setUsable(False)
        MyBase.dBoost = 30
        MyBase.sBoost = 10
        MyBase.mBoost = 8
        MyBase.count = 0
        MyBase.value = 2017

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(6, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(13, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(14, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(15, True)
    End Sub
End Class
