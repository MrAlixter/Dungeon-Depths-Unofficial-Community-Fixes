Public Class Weapon
    Inherits EquipmentItem

    Overridable Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Return Player.calcDamage(p.getATK, m.getDEF)
    End Function

    Overridable Sub outOfCombatAttack(ByRef p As Player)
        TextEvent.pushAndLog("You swing your " & getName().Replace("_", " ") & " at the air.")
    End Sub

    Overridable Overloads Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
    End Sub

    Overrides Sub onUnequip(ByRef p As Player)
        onUnequip(p, Nothing)
    End Sub

    Public Overrides Sub discard()
        If cursed And Not owner Is Nothing AndAlso owner.equippedWeapon.getAName.Equals(getAName) Then
            TextEvent.push("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub
End Class
