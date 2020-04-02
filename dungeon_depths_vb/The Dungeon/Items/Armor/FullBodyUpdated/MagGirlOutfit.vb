Public Class MagGirlOutfit
    Inherits Armor

    Sub New()
        MyBase.setName("Magical_Girl_Outfit")
        MyBase.setDesc("A mysterious uniform worn by a mysterious protector." & vbCrLf & _
                       "Fits Magical Girls" & vbCrLf & _
                       "+10 DEF" & vbCrLf & _
                       "Magical girls can not remove this uniform.")
        id = 10
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 10
        MyBase.count = 0
        MyBase.value = 100

        slutVarInd = 170

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(60, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(230, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(231, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(232, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(32, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(33, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(100, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(101, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(102, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(103, True, True)

        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub discard()
        If Game.player1.pClass.name.Equals("Magical Girl") Then
            Game.pushLstLog("You can't just drop your uniform!")
            Exit Sub
        End If
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

End Class
