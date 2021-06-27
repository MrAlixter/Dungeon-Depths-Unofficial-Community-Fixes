Public Class ProMagGirlOutfit
    Inherits Armor

    Sub New()
        setName("Pro_Mag._Girl_Outfit")

        id = 201
        tier = Nothing
        usable = false
        MyBase.droppable = False
        rando_inv_allowed = False

        MyBase.d_boost = 30
        MyBase.s_boost = 20
        MyBase.m_boost = 40

        count = 0
        value = 100

        slut_var_ind = 10

        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(288, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(289, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(290, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(291, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(201, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(202, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(203, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(204, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(205, True, True)

        MyBase.compress_breast = True

        rando_inv_allowed = False

        setDesc("A mysterious uniform worn by a mysterious protector with a fair bit of experience." & DDUtils.RNRN & _
                                getSizeInformation() & vbcrlf & getStatInformation() &
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
