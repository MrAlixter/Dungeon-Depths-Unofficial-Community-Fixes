Public Class MagGirlOutfitC
    Inherits Armor

    Sub New()
        MyBase.setName("Mag._Girl_Outfit_(C)")
        MyBase.setDesc("A mysterious uniform worn by a mysterious protector with a bovine flair." & vbCrLf & _
                       "Fits Magical Girls" & vbCrLf & _
                       "+50 HP" & vbCrLf & _
                       "+5 DEF" & vbCrLf & _
                       "+25 MANA" & vbCrLf & _
                       "Magical girls can not remove this uniform.")

        id = 216
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 5
        MyBase.mBoost = 25
        MyBase.hBoost = 50

        MyBase.count = 0
        MyBase.value = 100

        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(304, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(305, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(306, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(307, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(308, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(309, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(225, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(226, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(227, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(228, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(229, True, True)

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
