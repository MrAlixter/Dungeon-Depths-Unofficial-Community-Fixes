Public Class MHairChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have a new hairstyle!")

        Dim r1 = Int(Rnd() * Game.imgLib.atrs("RearHair2").ndoM)
        Dim r2 = Int(Rnd() * Game.imgLib.atrs("FrontHair").ndoM)

        p.setIAInd(1, r1, False, False)
        p.setIAInd(5, r1, False, False)
        p.setIAInd(15, r2, False, False)

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
