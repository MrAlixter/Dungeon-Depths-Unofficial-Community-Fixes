Public Class MagGirlOutfitR
    Inherits Armor

    Sub New()
        MyBase.setName("Mag._Girl_Outfit_(R)")


        id = 210
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 25
        MyBase.mBoost = 17
        MyBase.aBoost = 15

        MyBase.count = 0
        MyBase.value = 100

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(296, True, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(297, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(298, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(299, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(217, True, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(218, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(219, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(220, True, True)

        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False

        MyBase.setDesc("A mysterious uniform worn by a mysterious protector with a fair bit of experience." & DDUtils.RNRN & _
                                     getSizeInformation() & vbCrLf & getStatInformation() &
                              "Magical girls can not remove this uniform.")
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
