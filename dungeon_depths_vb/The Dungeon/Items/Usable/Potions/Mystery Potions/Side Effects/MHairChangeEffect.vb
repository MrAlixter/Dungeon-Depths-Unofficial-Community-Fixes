Public Class MHairChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If

        Game.pushLblEvent("You now have a new hairstyle!")

        Dim r1 = Int(Rnd() * Portrait.imgLib.atrs("RearHair2").ndoM)
        Dim r2 = Int(Rnd() * Portrait.imgLib.atrs("FrontHair").ndoM)

        p.prt.setIAInd(1, r1, False, False)
        p.prt.setIAInd(5, r1, False, False)
        p.prt.setIAInd(15, r2, False, False)

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
