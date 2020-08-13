Public Class FoxEars
    'FoxEars is a useable item that gives the player fox ears
    Inherits Item
    Sub New()
        MyBase.setName("Fox_Ears")
        MyBase.setDesc("These will give you fox ears.")
        id = 219
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 777
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        p.prt.setIAInd(pInd.ears, 13, True, True)
        p.drawPort()
        count -= 1
    End Sub
End Class
