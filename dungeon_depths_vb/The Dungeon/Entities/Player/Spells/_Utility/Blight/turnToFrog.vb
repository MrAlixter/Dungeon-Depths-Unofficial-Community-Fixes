Public Class turnToFrog
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Turn to Frog")
        MyBase.settier(2)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        'If getTarget.getIntHealth > 70 Then MyBase.getTarget.health = 1

        'Polymorph.transform(MyBase.getTarget, "Giant Frog")
        If PolymorphedNPC.polymorph(getTarget, Game.player1, 5, "Giant Frog") Is Nothing Then Exit Sub

        TextEvent.pushAndLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a giant frog!"))
        If MyBase.getTarget.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            CType(MyBase.getTarget, ShopNPC).toFrog()
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that transforms its target into a large frog with a low chance of missing altogether."
    End Function
End Class
