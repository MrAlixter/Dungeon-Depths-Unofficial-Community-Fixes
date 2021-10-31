Public Class BimbHairEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        TextEvent.push("You now have long, straight hair!")

        p.prt.setIAInd(pInd.rearhair, 6, True, True)
        p.prt.setIAInd(pInd.midhair, 6, True, True)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)

        p.drawPort()
        p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Bimbo hair effect"
    End Function
End Class
