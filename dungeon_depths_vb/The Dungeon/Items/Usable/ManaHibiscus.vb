Public Class ManaHibiscus
    Inherits Accessory
    Sub New()
        '|ID Info|
        setName("Mana_Hibiscus")
        id = 149
        If DDDateTime.isAni Then tier = 2 Else tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        MyBase.m_boost = 17
        count = 0
        value = 1820

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(4, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(4, True, True)

        '|Description|
        setDesc("This magenta flower is covered in runes that pulse with the glowing aura of magic.  With verdant leaves that never curl with age, there's no telling what would happen if someone were to add a little more mana to the mix...")

    End Sub

    Overrides Sub use(ByRef p As Player)
        If Game.currFloor.floorNumber = 91017 Or Game.currFloor.floorNumber = 9999 Or Game.currFloor.floorNumber = 10000 Then Exit Sub
        If Game.combat_engaged Or Game.shop_npc_engaged Then Exit Sub
        Dim cae = New Caelia
        Game.npcEncounter(cae)
        Game.hideNPCButtons()
        TextEvent.pushNPCDialog("*giggle* Hi, I'm Caelia!  The magic on that flower pulled here from another place.  It also kinda opened up a time rift, soooo have fun with that!", AddressOf Caelia.teleportPlayer)
        Equipment.accChange(p, "Nothing")

        count -= 1
    End Sub
End Class
