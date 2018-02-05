Public Class SoulBlade
    Inherits Weapon

    Sub New()
        MyBase.setName("SoulBlade")
        MyBase.setDesc("A ornate sword forged from someone's soul.")
        MyBase.setUsable(False)
        MyBase.aBoost = 5
        MyBase.count = 0
        MyBase.value = 100
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub

    Public Sub Absorb(ByRef m As Monster)
        MyBase.setName("SoulBlade") ' (" & m.name.Split()(0) & ")")
        MyBase.setDesc("A ornate sword forged from " & m.name.Split()(0) & "'s soul.")
        MyBase.setUsable(False)
        MyBase.aBoost = m.attack
        MyBase.value = m.maxHealth
        m.toBlade()
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Monster) As Integer
        Dim dmg As Integer = 4 * Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getAttack) + (Me.aBoost)
        Return dmg - ((m.defence / 100) * dmg)
    End Function
End Class
