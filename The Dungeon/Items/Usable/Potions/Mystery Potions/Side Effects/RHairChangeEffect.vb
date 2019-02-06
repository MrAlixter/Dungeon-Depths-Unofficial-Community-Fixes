Public Class RHairChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If

        Game.pushLblEvent("You now have a new hairstyle!")

        Dim r = Int(Rnd() * 2)
        Dim moF As Boolean = True
        If r = 0 Then moF = False

        If moF Then
            Dim r1 = Int(Rnd() * Game.imgLib.atrs("RearHair2").ndoF)
            Dim r2 = Int(Rnd() * Game.imgLib.atrs("FrontHair").ndoF)

            p.setIAInd(1, r1, True, False)
            p.setIAInd(5, r1, True, False)
            p.setIAInd(15, r2, True, False)
        Else
            Dim r1 = Int(Rnd() * Game.imgLib.atrs("RearHair2").ndoM)
            Dim r2 = Int(Rnd() * Game.imgLib.atrs("FrontHair").ndoM)

            p.setIAInd(1, r1, False, False)
            p.setIAInd(5, r1, False, False)
            p.setIAInd(15, r2, False, False)
        End If

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
