Public Class LanceOfDarkness
    Inherits Spear

    Public Const ITEM_NAME As String = "Lance_of_Darkness"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 238
        tier = Nothing

        '|Item Flags|
        usable = true
        cursed = True

        '|Stats|
        a_boost = 31
        s_boost = -7
        count = 0
        value = 3110
        weight = 7

        '|Description|
        setDesc("A hefty spear crafted from a jet-black alloy.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f6f9
                Return 3
            Case LootTable.bracket.f10f12
                Return 3
            Case LootTable.bracket.f14fXX
                Return 3
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Archdemoness") Then
            Dim archdemonessTF = New ArchDemonessTF(1, 0, 0, False)
            archdemonessTF.step1()
            p.drawPort()
        End If
    End Sub

    Overrides Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            TextEvent.pushAndLog("You throw the spear across the dungeon at nothing in particular.")
        Else
            If m.getNPC() Is Nothing Then
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & "!")
            Else
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & " at " & m.getNPC.getNameWithTitle & "!")
            End If

            Dim dmg As Integer = (p.getATK) + (Me.a_boost) + (Me.a_boost) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        If Not p.equippedWeapon.getName.Equals(getName) Then
            Dim w_dmg = weight + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
            durability -= w_dmg
            If durability <= 0 Then
                break()
            ElseIf Not m.isDead Then
                TextEvent.pushAndLog("The " & getName.Replace("_", " ") & " takes " & w_dmg & " damage.")
            Else
                TextEvent.pushLog("The " & getName.Replace("_", " ") & " takes " & w_dmg & " damage.")
            End If
        End If
    End Sub
End Class
