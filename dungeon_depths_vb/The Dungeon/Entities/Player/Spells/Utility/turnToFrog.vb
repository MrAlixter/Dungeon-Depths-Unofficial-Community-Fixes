Public Class turnToFrog
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Turn to Frog")
        MyBase.settier(2)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()

        MyBase.getTarget.form = "Giant Frog"

        If MyBase.getTarget.getIntHealth > 70 Then MyBase.getTarget.health = 1

        Polymorph.transform(MyBase.getTarget, "Giant Frog")

        Game.pushLogAndEvent(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a giant frog!"))
        If MyBase.getTarget.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            CType(MyBase.getTarget, ShopNPC).toFrog()
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that transforms its target into a large frog with a low chance of missing altogether."
    End Function
End Class
