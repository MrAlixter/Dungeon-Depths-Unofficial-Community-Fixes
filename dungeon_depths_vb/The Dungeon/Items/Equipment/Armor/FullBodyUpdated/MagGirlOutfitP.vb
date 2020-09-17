Public Class MagGirlOutfitP
    Inherits Armor

    Sub New()
        MyBase.setName("Mag._Girl_Outfit_(P)")

        id = 202
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 17
        MyBase.mBoost = 25
        MyBase.hBoost = 35

        MyBase.count = 0
        MyBase.value = 100

        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(292, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(293, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(294, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(295, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(206, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(207, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(208, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(209, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(210, True, True)

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
