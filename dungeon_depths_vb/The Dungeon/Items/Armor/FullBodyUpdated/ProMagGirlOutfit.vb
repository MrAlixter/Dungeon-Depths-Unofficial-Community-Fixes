Public Class ProMagGirlOutfit
    Inherits Armor

    Sub New()
        MyBase.setName("Pro_Mag._Girl_Outfit")
        MyBase.setDesc("A mysterious uniform worn by a mysterious protector with a fair bit of experience." & vbCrLf & _
                       "Fits Magical Girls" & vbCrLf & _
                       "+20 DEF" & vbCrLf & _
                       "+17 SPD" & vbCrLf & _
                       "+10 MANA" & vbCrLf & _
                       "Magical girls can not remove this uniform.")

        id = 201
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 25
        MyBase.sBoost = 17
        MyBase.mBoost = 10

        MyBase.count = 0
        MyBase.value = 100

        slutVarInd = 10

        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(288, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(289, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(290, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(291, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(201, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(202, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(203, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(204, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(205, True, True)

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
