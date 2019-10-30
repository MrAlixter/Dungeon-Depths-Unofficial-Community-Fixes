Public Class CDefenceCharm
    Inherits Item

    Sub New()
        MyBase.setName("Defence_Charm​")
        MyBase.setDesc("A charm that slightly boosts your defence.  There is a subtle red glow surrounding this charm.")
        id = 174
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base DEF!")

        Game.player.defence += 5
        Game.player.UIupdate()

        If Not Game.player.perks("coscale") > -1 And (Int(Rnd() * 2) = 0 Or Game.noRNG) Then
            Game.player.ongoingTFs.Add(New BroodmotherTF(5, 15, 2.0, True))
            Game.player.perks("coscale") = 1
            Game.pushLstLog("You've been afflicted wth the curse of scales!")
        End If

        count -= 1
    End Sub
End Class
