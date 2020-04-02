Public Class Weapon
    Inherits Item
    Public aBoost As Integer = 0
    Public dBoost As Integer = 0
    Public mBoost As Integer = 0
    Public sBoost As Integer = 0
    Public wboost As Integer = 0
    Public isCursed As Boolean = False
    Overridable Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Return Player.calcDamage(p.getATK, m.getDEF)
    End Function
    Overridable Sub onEquip()
    End Sub
    Overridable Sub onUnequip()
    End Sub

    Public Overrides Sub discard()
        If isCursed And Game.player1.equippedWeapon.getAName.Equals(getAName) Then
            Game.pushLblEvent("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub
End Class
