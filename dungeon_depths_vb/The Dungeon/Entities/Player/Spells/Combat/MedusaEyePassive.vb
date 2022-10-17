Public Class MedusaEyePassive
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Medusa's Gaze")
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        If getTarget.sName.Equals("Medusa") Then
            TextEvent.push("Your spell doesn't seem to have done anything...")
            Exit Sub
        End If

        TextEvent.pushAndLog(CStr("Your magic strikes " & target.getNameWithTitle() & " in the chest, turning " & MyBase.getTarget.r_pronoun & " to stone."))

        If MyBase.getTarget.speed / CInt(MyBase.getTarget.sSpeed / 4) > 0 Then
            TextEvent.pushAndLog(CStr(Math.Ceiling(MyBase.getTarget.speed / CInt(MyBase.getTarget.sSpeed / 4)) & " more until they become a statue!"))
        End If

        If MyBase.getTarget.speed > 0 Then
            MyBase.getTarget.speed -= CInt(MyBase.getTarget.sSpeed / 4)
        Else
            MyBase.getTarget.toStatue()
            TextEvent.pushLog(CStr("You see a statue here."))
        End If
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

        TextEvent.pushAndLog("Your gaze falls upon the " & getTarget.getName() & "!")
        effect()
    End Sub
End Class
