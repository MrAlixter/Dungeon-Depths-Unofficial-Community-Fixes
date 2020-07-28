Public Class CatEars
    'CatEars is a useable item that gives the player cat ears
    Inherits Item
    Sub New()
        MyBase.setName("Cat_Ears")
        MyBase.setDesc("These will give you cat ears.")
        id = 15
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 250
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        p.prt.setIAInd(pInd.ears, 1, p.prt.sexBool, False)
        p.drawPort()
        count -= 1
    End Sub
End Class
