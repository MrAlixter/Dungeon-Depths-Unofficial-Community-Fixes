Public Class turnToFrog
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Turn to Frog")
        MyBase.settier(2)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        MyBase.getTarget.tfCt = 1
        MyBase.getTarget.tfEnd = 5
        MyBase.getTarget.form = "Giant Frog"
        MyBase.getTarget.attack = 5
        MyBase.getTarget.defense = 5
        MyBase.getTarget.speed = 1
        If MyBase.getTarget.getIntHealth > 70 Then MyBase.getTarget.health = 1
        MyBase.getTarget.maxHealth = 70
        Game.pushLstLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a giant frog!"))
        Game.pushLblCombatEvent(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a giant frog!"))
        If MyBase.getTarget.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            CType(MyBase.getTarget, ShopNPC).toFrog()
        End If
    End Sub
End Class
