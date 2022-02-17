Public Class MidasGuantlet
    Inherits Weapon

    Public Const ITEM_NAME As String = "Midas_Gauntlet"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 42
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 0
        count = 0
        value = 9999

        '|Description|
        setDesc("A ornate glove that allows you to turn a monster to gold.")
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
