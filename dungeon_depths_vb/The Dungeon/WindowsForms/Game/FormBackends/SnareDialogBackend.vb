Public Class SnareDialogBackend

    Shared baitItemsInd As List(Of Integer) = New List(Of Integer)
    Shared Sub toPnlSnare(sender As Object, e As EventArgs, ByRef p As Player)
        Game.cboxBait.Items.Clear()
        baitItemsInd.Clear()

        baitItemsInd.Add(-1)
        Game.cboxBait.Items.Add("Nothing")
        For i = 0 To p.inv.count
            If Not p.inv.item(i) Is Nothing AndAlso p.inv.item(i).getCount > 0 Then
                Game.cboxBait.Items.Add(p.inv.item(i).getName)
                baitItemsInd.Add(p.inv.item(i).id)
            End If
        Next

        Game.cboxBait.Focus()
        Game.pnlSnare.Visible = True
    End Sub
    Shared Sub fromPnlSnare(sender As Object, e As EventArgs, ByRef p As Player)
        If Not Game.cboxBait.Text.Equals("Nothing") Then

            Dim i = (p.inv.item(baitItemsInd(Game.cboxBait.Items.IndexOf(Game.cboxBait.Text))))

            If i.getAName.Contains("Gum") And Not Game.hteach.form.Equals("Arachne") Then
                p.perks(perk.snarednpc) = 2
            ElseIf i.getAName.Contains("Curse") And Not Game.cbrok.form.Equals("Arachne") Then
                p.perks(perk.snarednpc) = 5
            ElseIf (i.getAName.Contains("Girl") Or i.getAName.Contains("Mag.")) And i.getAName.Contains("Wand") And Not Game.mgirl.form.Equals("Arachne") Then
                p.perks(perk.snarednpc) = 6
            ElseIf i.GetType.IsSubclassOf(GetType(Armor)) AndAlso CType(i, Armor).getAntiSlutInd > 0 And Not Game.swiz.form.Equals("Arachne") Then
                p.perks(perk.snarednpc) = 1
            ElseIf i.GetType.IsSubclassOf(GetType(Food)) And Not Game.fvend.form.Equals("Arachne") Then
                p.perks(perk.snarednpc) = 3
            ElseIf i.GetType.IsSubclassOf(GetType(Weapon)) And Not Game.wsmith.form.Equals("Arachne") Then
                p.perks(perk.snarednpc) = 4
            ElseIf (i.value) > 1000 And Not Game.shopkeeper.form.Equals("Arachne") Then
                p.perks(perk.snarednpc) = 0
            End If
            Game.pushLblEvent(If(p.perks(perk.snarednpc) > -1, "The previous snare you set withers away..." & DDUtils.RNRN, "") & "You expertly weave a snare, leaving the " & i.getName & " dangling by a nearly invisible thread." & DDUtils.RNRN &
                              "Getting to the next floor should allow you to reel in whatever takes the bait...")
            i.count -= 1
        End If

        Game.lblEvent.Focus()
        Game.pnlSnare.Visible = False
    End Sub
End Class
