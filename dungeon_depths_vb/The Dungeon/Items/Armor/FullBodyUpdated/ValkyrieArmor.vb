Public Class ValkyrieArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Valkyrie_Armor")
        MyBase.setDesc("An etherial armor set crafted for a valiant defender." & vbCrLf & _
                       "Fits sizes -1 to 3" & vbCrLf & _
                       "+25 DEF" & vbCrLf & _
                       "Valkyries can not remove this armor.")
        id = 95
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 25
        MyBase.count = 0
        MyBase.value = 600

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

        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub discard()
        If Game.player1.pClass.name.Equals("Valkyrie") Then
            Game.pushLstLog("Your armor magically reappears!")
            Exit Sub
        End If
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
