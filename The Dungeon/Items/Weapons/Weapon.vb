Public Class Weapon
    Inherits Item
    Public aBoost As Integer = 0
    Public dBoost As Integer = 0
    Public mBoost As Integer = 0
    Public sBoost As Integer = 0
    Public eBoost As Integer = 0
    Overridable Function attack(ByRef p As Player, ByRef m As Monster) As Integer
        Return p.attack - ((m.defence / 100) * p.attack)
    End Function
    Overridable Sub onEquip()
    End Sub
    Overridable Sub onUnequip()
    End Sub
End Class
