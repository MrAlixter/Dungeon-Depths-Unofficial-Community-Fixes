Public Class turnToFrog
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Turn to Frog")
        MyBase.settier(2)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        MyBase.getTarget.tfCt = 1
        MyBase.getTarget.tfEnd = 15
        MyBase.getTarget.form = "Giant Frog"
        MyBase.getTarget.attack = 1
        MyBase.getTarget.defence = 1
        MyBase.getTarget.speed = 1
        If MyBase.getTarget.health > 70 Then MyBase.getTarget.health = 70
        MyBase.getTarget.maxHealth = 70
        Game.pushLstLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a giant frog!"))
        Game.pushLblCombatEvent(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a giant frog!"))
        
    End Sub
End Class
