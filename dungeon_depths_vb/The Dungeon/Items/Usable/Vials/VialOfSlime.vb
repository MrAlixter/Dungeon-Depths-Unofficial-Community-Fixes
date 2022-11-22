Public Class VialOfSlime
    Inherits Item

    Public Const ITEM_NAME As String = "Vial_of_Slime"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 3
        tier = 1

        '|Item Flags|
        usable = true
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 100

        '|Description|
        setDesc("A glass bottle filled with an aquamarine non-newtonian gel.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        TextEvent.pushLog("You apply the " & getName())

        If p.formName.Equals("Slime") Or p.formName.Equals("Goo Girl") Then
            p.health = Math.Min(1, p.health + 0.25)
            count -= 1
            Exit Sub
        End If
        If p.perks(perk.slimetf) = -1 Or p.prt.haircolor.A = 255 Then
            p.perks(perk.slimetf) = 2
        End If

        p.ongoingTFs.Add(New VialOfslimetf(p.perks(perk.slimetf)))
        p.update()
        count -= 1

    End Sub
End Class
