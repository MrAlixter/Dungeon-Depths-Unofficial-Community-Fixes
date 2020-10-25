Public Class VialOfVenom
    Inherits Item
    Sub New()
        '|ID Info|
        MyBase.setName("Vial_of_Venom")
        id = 91
        tier = 1

        '|Item Flags|
        MyBase.setUsable(True)
        isMonsterDrop = True

        '|Stats|
        MyBase.count = 0
        MyBase.value = 100

        '|Description|
        MyBase.setDesc("A small glass bottle filled with an translucent golden ichor.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You drink the " & getName())
        Dim out As String = "You drink the vial of venom!"

        If p.perks(perk.avenom) = -1 And p.perks(perk.svenom) = -1 Then
            p.perks(perk.svenom) = 1
        End If

        p.ongoingTFs.Add(New ArachneTF(p.perks(perk.svenom)))

        Game.pushLblEvent(out, AddressOf p.update)
        count -= 1
    End Sub
End Class
