Public Class CatEars
    'CatEars is a useable item that gives the player cat ears
    Inherits Item
    Sub New()
        MyBase.setName("Cat_Ears")
        MyBase.setDesc("These will give you cat ears.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 250
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.player.iArr(6) = CharacterGenerator.fAttributes(6)(1)
        Game.player.iArrInd(6) = New Tuple(Of Integer, Boolean)(1, Game.player.sexBool)
        Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(Game.player.iArr)
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
