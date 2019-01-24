Public MustInherit Class MysteryPotion
    Inherits Item
    Protected effectList As List(Of PEffect)

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You drink the " & getName())

        setEffectList()

        For Each effect In effectList
            effect.apply(Game.player)
        Next
        pushLblEventEffects(effectList)

        effectList.Clear()
        count -= 1
    End Sub

    Public Sub pushLblEventEffects(ByRef appliedEffects As List(Of PEffect))
        Dim e As String = "Potion Effects: " & vbCrLf

        For Each effect In appliedEffects
            e += getEffectName(effect) & " applied."
        Next
        e += " " & vbCrLf & " " & vbCrLf & "Press any non-movement key to continue."
        Game.lblEvent.Text = e
        Game.lblEvent.BringToFront()
        Game.lblEvent.Location = New Point((250 * Game.Size.Width / 688) - (Game.lblEvent.Size.Width / 2), 65 * Game.Size.Width / 688)
        Game.lblEvent.Visible = True
        Game.player.inv.invNeedsUDate = True
    End Sub

    Private Function getEffectName(ByRef pe As PEffect) As String
        Select Case pe.GetType
            Case GetType(HealthEffect)
                Return "Health gain"
            Case GetType(ManaEffect)
                Return "Mana gain"
            Case GetType(HHealthEffect)
                Return "Hyper health effect"
            Case GetType(HManaEffect)
                Return "Hyper mana effect"
            Case GetType(MinHungerEffect)
                Return "Minor hunger reduction"
        End Select
        Return "Unknown effect"
    End Function

    Public Overridable Sub setEffectList()
        If effectList.Count <> 0 Then effectList.Clear()
    End Sub
End Class
