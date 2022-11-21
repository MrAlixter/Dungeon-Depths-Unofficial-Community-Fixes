Public Class MedusaEyePassive
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Medusa's Gaze")
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        If MyBase.getTarget.GetType().IsSubclassOf(GetType(MiniBoss)) Or MyBase.getTarget.GetType().IsSubclassOf(GetType(Boss)) Or MyBase.getTarget.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            TextEvent.push("Your gaze doesn't seem to have done anything...")
            Exit Sub
        End If

        TextEvent.pushAndLog(CStr("Your gaze washes over " & target.getNameWithTitle() & ", turning " & MyBase.getTarget.r_pronoun & " to stone."))

        Petrify.petrifyEffect(MyBase.getTarget.sSpeed / 5, MyBase.getTarget)
    End Sub

    Public Overrides Function getcost() As Integer
        Return 0
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A special spell that shouldn't be on your spells list."
    End Function

    Overrides Sub cast()
        If getCaster.mana < getcost() Then
            TextEvent.pushAndLog("You don't have enough mana! (" & name & " costs " & getcost() & " mana)")
            Exit Sub
        End If
        If Not Game.combat_engaged And Not Game.shop_npc_engaged And Not useableOutOfCombat Then
            TextEvent.pushAndLog("You don't have a target for that spell!")
            Exit Sub
        End If

        Randomize()
        getCaster.mana -= getcost()

        effect()
    End Sub
End Class
