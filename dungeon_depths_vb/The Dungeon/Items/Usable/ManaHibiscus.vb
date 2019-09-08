Public Class ManaHibiscus
    Inherits Accessory
    Sub New()
        MyBase.setName("Mana_Hibiscus")
        MyBase.setDesc("The runes covering this magenta flower not only keep it perpetually young, but also emit a sublte aura of mana.  Who knows what would happen if one were to try to activate them further...")
        id = 149
        If DateTime.Now.Month = 9 And DateTime.Now.Day = 10 Then tier = 2 Else tier = Nothing
        MyBase.setUsable(True)
        MyBase.mBoost = 17
        MyBase.count = 0
        MyBase.value = 1820
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(4, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(4, True, True)
    End Sub

    Overrides Sub use()
        If Game.combatmode Or Game.npcmode Then Exit Sub
        Dim cae = New Caelia
        Game.npcEncounter(cae)
        Game.hideNPCButtons()
        Game.pushNPCDialog("*giggle* Hi, I'm Caelia!  The magic on that flower pulled here from another place.  It also kinda opened up a time rift, soooo have fun with that!", AddressOf Caelia.teleportPlayer)
        Equipment.accChange("Nothing")

        count -= 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
