Public Class WFeast
    Inherits Food
    Sub New()
        MyBase.setName("Warrior's_Feast")
        MyBase.setDesc("A seared chunk of...some sort of meat still on the bone, served with a satisfying amount of bread." & vbCrLf &
                       "-90 Hunger" & vbCrLf &
                       "Low chance to raise ATK and DEF by 3 points each")
        id = 133
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 2100
        setCalories(90)
    End Sub

    Public Overrides Sub Effect()
        If Int(Rnd() * 5) = 0 Then
            Game.player.attack += 3
            Game.player.defence += 3

            Game.player.UIupdate()
        End If
    End Sub
End Class
