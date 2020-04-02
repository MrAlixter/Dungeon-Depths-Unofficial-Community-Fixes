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
        MyBase.value = 9999
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = 4 * Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        End If
        If Int(Rnd() * 3) = 0 Or Not (m.GetType() Is GetType(NPC) Or m.GetType.IsSubclassOf(GetType(NPC))) Then
            Game.player1.toStatue(Color.Goldenrod, "midas")
        Else
            CType(m, NPC).toGold()
        End If
        Return 0
    End Function
End Class
