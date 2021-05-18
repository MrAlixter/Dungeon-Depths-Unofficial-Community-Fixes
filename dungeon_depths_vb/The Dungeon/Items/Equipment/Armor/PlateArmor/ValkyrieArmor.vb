Public Class ValkyrieArmor
    Inherits Armor

    Sub New()
        setName("Valkyrie_Armor")

        id = 95
        tier = Nothing
        usable = false
        MyBase.d_boost = 25
        count = 0
        value = 600

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(18, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(64, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(96, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(97, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(98, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(39, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(40, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(126, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(127, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(128, True, True)

        MyBase.compress_breast = True

        rando_inv_allowed = False

        setDesc("An etherial armor set crafted for a valiant defender." & DDUtils.RNRN & _
                             getSizeInformation() & vbCrLf & getStatInformation() & vbCrLf & _
                             "Valkyries can not remove this armor.")
    End Sub

    Overrides Sub discard()
        If Game.player1.className.Equals("Valkyrie") Then
            Game.pushLstLog("Your armor magically reappears!")
            Exit Sub
        End If
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
