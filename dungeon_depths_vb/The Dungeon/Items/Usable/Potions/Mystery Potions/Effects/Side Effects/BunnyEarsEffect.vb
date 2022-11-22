Public Class BunnyEarsEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.prt.setIAInd(pInd.ears, 2, True, False)
        p.savePState()
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Bunny ears effect"
    End Function
End Class
