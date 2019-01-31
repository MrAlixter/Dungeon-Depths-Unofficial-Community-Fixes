Public Class NekoTF
    Inherits Transformation

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Neko"
        Game.player.perks("nekocurse") = 0
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Neko"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As player = game.player
        p.iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(1, p.sexBool, False)
        Game.pushLblCombatEvent("Your ears twitch, becoming feline while Marissa gives you a malicious grin.  ""I'm sure you tell where this is going,"" she giggles." & vbCrLf & "  You now have cat ears!")
        p.lust += 5
        p.will -= 1
    End Sub
    Sub step2()
        Dim p As player = game.player
        p.iArrInd(4) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        Game.pushLblCombatEvent("Your facial structure softens, and now you have a feminine face!")
        p.lust += 5
    End Sub
    Sub step3()
        Dim p As player = game.player
        p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
        p.will -= 1
        Game.pushLblCombatEvent("Your hair grows down to your ass, straightening out as it lengthens.  You now have long, straight hair!")
    End Sub
    Sub step4()
        Dim p As player = game.player
        p.iArrInd(7) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        Game.pushLblCombatEvent("You wince and close your eye as a burning sensation flows through them. You now have kitten eyes!")
        p.lust += 5
    End Sub
    Sub step5()
        Dim p As player = game.player
        If Not p.sexBool Then
            p.MtF()
            p.be()
            p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
            Game.pushLblCombatEvent("Your body slims down, and your chest inlates, giving you average sized breasts.  Soon after, your cock and balls shift into a vagina. You are now female!")
        Else
            p.be()
            currStep += 1
        End If
        p.lust += 5
    End Sub
    Sub step6()
        Dim p As player = game.player

        If p.pClass.name.Equals("Magic Girl") Then
            step6alt()
            Exit Sub
        End If

        p.be()
        p.iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(40, True, True)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        p.will -= 2
        Equipment.clothesChange("Cat_Lingerie")
        Game.pushLblCombatEvent("Your tits expand, your clothes shift, and you feel your will grow weaker. You are now permenantly a cat girl!  Soon you will be Marissa's pet! ")
    End Sub
    Sub step6alt()
        Dim p As player = game.player
        Equipment.weaponChange("Fists")
        Equipment.clothesChange("Cat_Lingerie")
        p.be()
        p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
        p.iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(40, True, True)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        Game.pushLblCombatEvent("Your hair grows down to your ass, straightening out as it lengthens.  You now have long, straight hair!  Your tits expand, your clothes shift, and you feel your will grow weaker. You are now a cat girl!  Soon you will be Marissa's pet! ")
    End Sub
    Sub step7()
        Dim p As player = game.player
        If p.will < 5 Then
            If p.sex = "Male" Then
                p.MtF()
                p.be()
                p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
            End If
            p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
            p.iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(6, True, True)
            p.iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(40, True, True)
            p.iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        End If
        p.pClass = p.classes("Kitty")
        p.be()

        Equipment.clothesChange("Cat_Lingerie")

        Game.fromCombat()
        Game.pushLblEvent("As the last of your resistance drains away, all you can find yourself doing is focusing on your new mistress's voice as she orders you down onto all fours.  You happily oblige, purring softly, and she giggles.  ""Come on kitty, lets go!"" she orders and the two of you, with her leading, wander off into the darkness.  GAME OVER!", AddressOf p.die)
        p.perks("nekocurse") = -1
    End Sub

    Sub resist()
        Game.pushLblCombatEvent("You are able to resist the curse, but you can feel your resolve wavering...")
        Game.player.will -= 1
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("nekocurse") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Game.player.perks("nekocurse") = -1 Then
            Return AddressOf stopTF
        ElseIf Game.player.pClass.name.Equals("Magic Girl") And stage < 6 Then
            Return AddressOf resist
        End If

        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case 2
                Return AddressOf step3
            Case 3
                Return AddressOf step4
            Case 4
                Return AddressOf step5
            Case 5
                Return AddressOf step6
            Case 6
                Return AddressOf step7
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 1
        turnsTilNextStep += generatWILResistance()
    End Sub
End Class
