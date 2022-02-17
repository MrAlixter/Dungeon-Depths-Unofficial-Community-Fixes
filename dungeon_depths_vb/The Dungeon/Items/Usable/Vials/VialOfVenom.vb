Public Class VialOfVenom
    Inherits Item

    Public Const ITEM_NAME As String = "Vial_of_Venom"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 91
        tier = 1

        '|Item Flags|
        usable = true
        droppable = True

        '|Stats|
        count = 0
        value = 100

        '|Description|
        setDesc("A small glass bottle filled with an translucent golden ichor.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You drink the " & getName())
        Dim out As String = "You drink the vial of venom!"

        If p.perks(perk.avenom) = -1 And p.perks(perk.svenom) = -1 Then
            p.perks(perk.svenom) = 1
        End If

        p.ongoingTFs.Add(New ArachneTF(p.perks(perk.svenom)))

        TextEvent.push(out, AddressOf p.update)
        count -= 1
    End Sub
End Class
