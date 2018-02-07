Public Class MidasGuantlet
    Inherits Weapon

    Sub New()
        MyBase.setName("Midas_Gauntlet")
        MyBase.setDesc("A ornate glove that allows you to turn a monster to gold.")
        id = 42
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        MyBase.count = 0
        MyBase.value = 4000
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Monster) As Integer
        Dim dmg As Integer = 4 * Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        End If
        If Int(Rnd() * 3) = 0 Then
            Game.player.toStatue(Color.Goldenrod, "midas")
        Else
            m.toGold()
        End If
        Return 0
    End Function
End Class
