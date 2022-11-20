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
        setDesc("An ornate, armored glove can turn a monster to gold with a single touch.  If you were to accidentally graze yourself, though, you too would meet the same fate..." & DDUtils.RNRN &
                "On attack, 2 in 3 odds to turn the target to gold.  1 in 3 odds to turn the player to gold.")
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = 4 * Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        End If
        If Int(Rnd() * 3) = 0 Then
            Game.player1.toStatue(Color.Goldenrod, "midas")
        ElseIf Not m.getNPC Is Nothing Then
            m.getNPC.toGold()
        End If

        Return 0
    End Function
End Class
