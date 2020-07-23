Public Class MagGirlOutfitD
    Inherits Armor

    Sub New()
        MyBase.setName("Mag._Girl_Outfit_(D)")
        MyBase.setDesc("A mysterious uniform worn by a mysterious ""protector"" that has embraced the dark side." & vbCrLf & _
                       "Fits Magical Girls" & vbCrLf & _
                       "+13 HP" & vbCrLf & _
                       "+13 DEF" & vbCrLf & _
                       "+26 MANA" & vbCrLf & _
                       "+13 ATK" & vbCrLf & _
                       "+13 SPD" & vbCrLf & _
                       "+13 WIL" & vbCrLf & _
                       "Magical girls can not remove this uniform.")

        id = 208
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.hBoost = 13
        MyBase.dBoost = 13
        MyBase.mBoost = 26
        MyBase.aBoost = 13
        MyBase.sBoost = 13
        MyBase.wboost = 13

        MyBase.count = 0
        MyBase.value = 100

        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(284, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(285, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(286, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(287, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(196, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(197, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(198, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(199, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(200, True, True)

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
