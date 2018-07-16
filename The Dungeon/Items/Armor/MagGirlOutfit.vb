Public Class MagGirlOutfit
    Inherits Armor

    Sub New()
        MyBase.setName("Magic_Girl_Outfit")
        MyBase.setDesc("A mysterious uniform worn by a mysterious protector." & vbCrLf & _
                       "Fits magic girls" & vbCrLf & _
                       "+10 DEF" & vbCrLf & _
                       "Magical girls can not remove this uniform.")
        id = 10
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 10
        MyBase.count = 0
        MyBase.value = 100
        bsize1 = New Tuple(Of Integer, Boolean)(12, True)
        bsize3 = New Tuple(Of Integer, Boolean)(37, True)
    End Sub

    Overrides Sub discard()
        If Game.player.title.Equals("Magic Girl") Then
            Game.lstLog.Items.Add("You can't just drop your uniform!")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
            Exit Sub
        End If
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
