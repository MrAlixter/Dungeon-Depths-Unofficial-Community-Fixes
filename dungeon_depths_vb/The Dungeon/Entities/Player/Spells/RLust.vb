Public Class RLust
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Raise Lust")
        MyBase.setUOC(True)
        MyBase.settier(4)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        If Not Game.combatmode Then backfire() : Exit Sub

        Dim t = MyBase.getTarget

        If t.isStunned Then
            If t.stunct < 2 Then t.stunct *= 2
        Else
            t.isStunned = True
            t.stunct = 1
        End If

        Game.pushLstLog("Your foe is distracted by their lust!  " & t.stunct & " turns remaining.")
        Game.pushLblEvent("Your foe is distracted by their lust!  " & t.stunct & " turns remaining.")
    End Sub

    Public Overrides Sub backfire()
        MyBase.getCaster.addLust(Math.Max(MyBase.getCaster.getLust, 15))

        Game.pushLstLog("You raise your own lust!")
        Game.pushLblEvent("You raise your own lust!")
    End Sub
End Class
