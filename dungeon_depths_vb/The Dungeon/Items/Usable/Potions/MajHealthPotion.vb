Public Class MajHealthPotion
    Inherits Item

    Sub New()
        MyBase.setName("Major_Health_Potion")
        MyBase.setDesc("A turbo-charged health potion that heals all wounds completely.")
        id = 82
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 550
    End Sub

    Overrides Sub use(ByRef p As Player)
        If p.pClass.name.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the health potion on the ground, shattering it all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & vbCrLf & vbCrLf & """Only someone who cares about their mortal vessel would bother to maintain it.")
            p.UIupdate()
            Exit Sub
        End If
        Game.pushLstLog("You drink the " & getName())
        Dim phHealth = p.health
        p.health = 1.0
        Game.pushLblEvent("You drink the " & getName() & ".  +" & CInt((p.health - phHealth) * p.getMaxHealth) & " health!")
        count -= 1
    End Sub
End Class
