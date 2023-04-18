Public Class VialOfBimbo
    Inherits Item

    Public Const ITEM_NAME As String = "Vial_of_BIM_II"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 127
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 1230

        '|Description|
        setDesc("A glittery, glowing pink potion contained in a clear, scientific looking glass tube.  A small label on the vial states that it contains ""200ml of BIM_II,"" a ""Potentially dangerous arcanomutant,"" whatever that means...")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        TextEvent.pushAndLog("Drinking the pink contents of the vial causes a dizzy calm wash to over you...")

        If p.className.Equals("Bimbo++") Then
            p.addXP(100)
            p.addLust(20)
            TextEvent.pushLog("+100 XP, +20 Lust")
        ElseIf p.className.Contains("Bimbo") Then
            p.changeClass("Bimbo++")
            p.prt.setIAInd(pInd.eyes, 34, True, True)
            If p.inv.getCountAt("Small_Glasses") < 1 Then p.inv.add("Small_Glasses", 1)
            EquipmentDialogBackend.equipGlasses(p, "Small_Glasses")

            p.drawPort()
        Else
            p.ongoingTFs.add(New BimboPlusTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0
        End If

        count -= 1
    End Sub
End Class
