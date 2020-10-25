Public Class MHairChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have a new hairstyle!")

        Dim r1 = Int(Rnd() * Portrait.imgLib.atrs(pInd.rearhair).ndoM)
        Dim r2 = Int(Rnd() * Portrait.imgLib.atrs(pInd.fronthair).ndoM)

        p.prt.setIAInd(pInd.rearhair, r1, False, False)
        p.prt.setIAInd(pInd.midhair, r1, False, False)
        p.prt.setIAInd(pInd.fronthair, r2, False, False)

        p.drawPort()
        p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Hair change effect"
    End Function
End Class
