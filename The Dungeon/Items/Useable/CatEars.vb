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
        Form1.player.iArr(6) = CharacterGenerator1.fAttributes(6)(1)
        Form1.player.iArrInd(6) = New Tuple(Of Integer, Boolean)(1, Form1.player.sexBool)
        Form1.picPortrait.BackgroundImage = CharacterGenerator1.CreateBMP(Form1.player.iArr)
        count -= 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
