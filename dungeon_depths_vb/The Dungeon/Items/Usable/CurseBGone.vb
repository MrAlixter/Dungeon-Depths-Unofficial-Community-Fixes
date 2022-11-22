Public Class CurseBGone
    Inherits Item

    Public Const ITEM_NAME As String = "Curse_'B'_Gone"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 195
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 300

        '|Description|
        setDesc("A small paper tag with instructions to ""Stuck in a bind?  Slap this bad boy on any cursed clothing to 'bust' out of it!""")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If p Is Nothing Then Exit Sub

        p.breastSize = 7
        p.buttSize = 5

        If p.equippedArmor.getAName = "Naked" Then
            TextEvent.push("Peeling off the paper backing from the Curse-B-Gone tag, you stick it on your chest with a mighty slap." & DDUtils.RNRN &
                           "Your chest bursts forth into massive udders, and your ass goes through similar expasion.")
        ElseIf Not p.equippedArmor.bsize7 Is Nothing And Not p.equippedArmor.usize5 Is Nothing Then
            TextEvent.push("Peeling off the paper backing from the Curse-B-Gone tag, you stick it on your chest with a mighty slap." & DDUtils.RNRN &
                           "Your chest bursts forth into massive udders, and your ass goes through similar expasion.  Your clothes... still fit...")
        Else
            EquipmentDialogBackend.armorChange(p, "Naked")
            TextEvent.push("Peeling off the paper backing from the Curse-B-Gone tag, you stick it on your chest with a mighty slap." & DDUtils.RNRN &
                           "Your chest bursts forth into massive udders, and your ass goes through similar expasion.  Your clothes no longer fit, cursed or not!")
        End If

        p.drawPort()
        count -= 1
    End Sub
End Class
