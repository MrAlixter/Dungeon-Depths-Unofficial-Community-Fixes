Public Class HealthPotion
    Inherits Item

    Sub New()
        MyBase.setName("Health_Potion")
        MyBase.setDesc("A normal, everyday health potion. +75 Health")
        id = 2
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 125
    End Sub

    Overrides Sub use(ByRef p As Player)
        If p.pClass.name.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the health potion on the ground, shattering it all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & vbCrLf & vbCrLf & """Only someone who cares about their mortal vessel would bother to maintain it.")
            p.UIupdate()
            Exit Sub
        End If
        Game.pushLstLog("You drink the " & getName())
        Dim phHealth = p.health
        Dim heffect As HealthEffect = New HealthEffect
        heffect.apply(p)
        Game.pushLblEvent("You drink the " & getName() & ".  +" & CInt((p.health - phHealth) * p.getMaxHealth) & " health!")
        count -= 1
    End Sub
End Class
