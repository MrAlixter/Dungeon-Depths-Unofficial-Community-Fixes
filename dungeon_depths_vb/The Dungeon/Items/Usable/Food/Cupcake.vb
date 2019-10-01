Public Class Cupcake
    Inherits Food
    Sub New()
        MyBase.setName("Cupcake")
        MyBase.setDesc("A 100% not magic totally not cursed cupcake. -50 Hunger")
        id = 35
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 250
        setCalories(50)
    End Sub

    Public Overrides Sub Effect()
        Dim p As Player = Game.player

        If p.perks("cupcake") = -1 Then
            p.perks("cupcake") = 0
        ElseIf p.perks("cupcake") > 4 Then
            p.ongoingTFs.Add(New LolitaSTF())
            p.update()
            p.perks("cupcake") = -1
        Else
            p.perks("cupcake") += 1
        End If
    End Sub
End Class
