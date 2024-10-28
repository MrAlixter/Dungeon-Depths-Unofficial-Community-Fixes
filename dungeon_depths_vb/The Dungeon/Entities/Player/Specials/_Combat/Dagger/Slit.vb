Public Class Slit
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Slit")
        MyBase.setUOC(True)
        MyBase.setcost(51)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If Not p.equippedWeapon.GetType().IsSubclassOf(GetType(Dagger)) Then
            TextEvent.fpushAndLog("...but you don't have an dagger equipped.")

            p.stamina += getCost()
            Exit Sub
        End If

        If Game.combat_engaged Then
            Dim d As Integer = Math.Min(0.2 * m.getMaxHealth(), 1100)
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(m.getNameWithTitle) & " takes " & d & " major bleed damage, and gains 6 stacks of bleed!")
            m.takeDMG(d, Game.player1)

            If m.perks(npc_perk.bleed) < 0 Then m.perks(npc_perk.bleed) = 0
            m.perks(npc_perk.bleed) += 6
        Else
            If Not p.equippedArmor.getAName.Equals("Naked") Then
                TextEvent.pushYesNo("Destroy your currently equipped " & DDUtils.amrOrClth(p) & "?", AddressOf slitArmor, AddressOf slitCancel)
            Else
                TextEvent.fpush("Slit!" & DDUtils.RNRN & "...but you don't have any armor equipped.")
                p.stamina += getCost()
            End If
        End If
    End Sub

    Sub slitArmor()
        Dim out As String = "You cut through your equipped " & MyBase.getUser.equippedArmor.getAName.Replace("_", " ")

        MyBase.getUser.equippedArmor.damage(99999)

        TextEvent.fpush("Slit!" & DDUtils.RNRN & out)
        TextEvent.pushLog(out)
    End Sub

    Sub slitCancel()
        MyBase.getUser.stamina += getCost()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A quick cut that deals no damage by itself, but that instead causes bleed.  Can be used outside of combat to destroy equipped armor.  Cannot be used without a dagger."
    End Function
End Class
