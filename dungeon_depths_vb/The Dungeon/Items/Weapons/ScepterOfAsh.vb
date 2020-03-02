Public Class ScepterOfAsh
    Inherits Staff

    Sub New()
        MyBase.setName("Scepter_of_Ash")
        MyBase.setDesc("A polished staff of a light wood capped off by a gistening, vaugly woman shaped red gem.  While the ""Ash"" portion of its name might refer to the type of wood that its made of, it could also refer to the immense magical power it bears." &
                       vbCrLf & vbCrLf & "+12 ATK, +42 Max Mana")
        id = 145
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 30
        MyBase.aBoost = 12
        count = 0
        value = 2567
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        MyBase.onEquip()
        Game.player.mana += 42
    End Sub
End Class
