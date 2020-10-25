Public Class ProMagGirlOutfitR
    Inherits Armor

    Sub New()
        MyBase.setName("Pro_Mag._G._Outfit_(R)")

        id = 211
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False
        MyBase.dBoost = 30
        MyBase.mBoost = 40
        MyBase.aBoost = 20

        MyBase.count = 0
        MyBase.value = 100

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(300, True, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(301, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(302, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(303, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(221, True, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(222, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(223, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(224, True, True)

        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False

        MyBase.setDesc("A mysterious uniform worn by a mysterious protector with a fair bit of experience." & DDUtils.RNRN & _
                         getSizeInformation() & vbCrLf & getStatInformation() &
                            "Magical girls can not remove this uniform.")
    End Sub

    Overrides Sub discard()
        If Game.player1.className.Equals("Magical Girl") Then
            Game.pushLstLog("You can't just drop your uniform!")
            Exit Sub
        End If
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

End Class
