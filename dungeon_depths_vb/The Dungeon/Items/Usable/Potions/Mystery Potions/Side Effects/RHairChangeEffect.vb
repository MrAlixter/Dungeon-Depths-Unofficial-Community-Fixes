Public Class RHairChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have a new hairstyle!")

        Dim r = Int(Rnd() * 2)
        Dim moF As Boolean = True
        If r = 0 Then moF = False

        If moF Then
            Dim r1 = Int(Rnd() * Portrait.imgLib.atrs(pInd.rearhair).ndoF)
            Dim r2 = Int(Rnd() * Portrait.imgLib.atrs(pInd.fronthair).ndoF)

            p.prt.setIAInd(pInd.rearhair, r1, True, False)
            p.prt.setIAInd(pInd.midhair, r1, True, False)
            p.prt.setIAInd(pInd.fronthair, r2, True, False)
        Else
            Dim r1 = Int(Rnd() * Portrait.imgLib.atrs(pInd.rearhair).ndoM)
            Dim r2 = Int(Rnd() * Portrait.imgLib.atrs(pInd.fronthair).ndoM)

            p.prt.setIAInd(pInd.rearhair, r1, False, False)
            p.prt.setIAInd(pInd.midhair, r1, False, False)
            p.prt.setIAInd(pInd.fronthair, r2, False, False)
        End If

        p.drawPort()
        p.savePState()
    End Sub
End Class
