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

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.player.prt.setIAInd(6, 1, Game.player.prt.sexBool, False)
        Game.player.createP()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
