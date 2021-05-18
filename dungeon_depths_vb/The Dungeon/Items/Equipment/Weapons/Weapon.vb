Public Class Weapon
    Inherits EquipmentItem

    Overridable Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Return Player.calcDamage(p.getATK, m.getDEF)
    End Function

    Overridable Overloads Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
    End Sub
    Overrides Sub onunequip(ByRef p As Player)
        onunequip(p, Nothing)
    End Sub

    Public Overrides Sub discard()
        If cursed And Not owner Is Nothing AndAlso owner.equippedWeapon.getAName.Equals(getAName) Then
            Game.pushLblEvent("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub
End Class
