Public Class FHairChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have a new hairstyle!")

        Dim r1 = Int(Rnd() * Portrait.imgLib.atrs(pInd.rearhair).ndoF)
        Dim r2 = Int(Rnd() * Portrait.imgLib.atrs(pInd.fronthair).ndoF)

        p.prt.setIAInd(pInd.rearhair, r1, True, False)
        p.prt.setIAInd(pInd.midhair, r1, True, False)
        p.prt.setIAInd(pInd.fronthair, r2, True, False)
    End Sub
End Class
