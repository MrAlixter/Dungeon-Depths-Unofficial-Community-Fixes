Public Class MHairChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have a new hairstyle!")

        Dim r1 = Int(Rnd() * Portrait.imgLib.atrs("RearHair2").ndoM)
        Dim r2 = Int(Rnd() * Portrait.imgLib.atrs("FrontHair").ndoM)

        p.prt.setIAInd(pInd.rearhair, r1, False, False)
        p.prt.setIAInd(pInd.midhair, r1, False, False)
        p.prt.setIAInd(pInd.fronthair, r2, False, False)

        p.drawPort()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
