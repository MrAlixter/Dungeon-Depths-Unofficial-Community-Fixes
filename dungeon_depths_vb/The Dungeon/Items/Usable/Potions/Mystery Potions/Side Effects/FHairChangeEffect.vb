Public Class FHairChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have a new hairstyle!")

        Dim r1 = Int(Rnd() * Portrait.imgLib.atrs("RearHair2").ndoF)
        Dim r2 = Int(Rnd() * Portrait.imgLib.atrs("FrontHair").ndoF)

        p.prt.setIAInd(1, r1, True, False)
        p.prt.setIAInd(5, r1, True, False)
        p.prt.setIAInd(15, r2, True, False)
    End Sub
End Class
