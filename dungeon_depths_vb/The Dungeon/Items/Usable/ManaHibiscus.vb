Public Class ManaHibiscus
    'CatEars is a useable item that gives the player cat ears
    Inherits Item
    Sub New()
        MyBase.setName("Mana_Hibiscus")
        MyBase.setDesc("Summons a Caelia.")
        id = 149
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 49
    End Sub

    Overrides Sub use()
        If Game.combatmode Or Game.npcmode Then Exit Sub
        Dim cae = New Caelia
        Game.npcEncounter(cae)
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
