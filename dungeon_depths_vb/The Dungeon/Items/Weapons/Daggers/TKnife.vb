Public Class TKnife
    Inherits Dagger

    Sub New()
        MyBase.setName("Throwing_Knife")
        MyBase.setDesc("A small blade weighted in such a way that it tumbles end over end when hurled at a target. " & vbCrLf &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+4 ATK")
        id = 162
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.aBoost = 4
        MyBase.count = 0
        MyBase.value = 235
    End Sub

    Overridable Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            Game.pushLblEvent("You throw the knife across the dungeon at nothing in particular.")
            Game.pushLstLog("You throw the knife across the dungeon at nothing in particular.")
        Else
            Game.pushLstLog("You throw the knife!")
            Dim dmg As Integer = (p.getATK) + (10) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        durability -= 30 + Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If durability <= 0 Then break()
    End Sub

    Public Overrides Sub use()
        wThrow(Game.player, Game.player.currTarget)
    End Sub
End Class
