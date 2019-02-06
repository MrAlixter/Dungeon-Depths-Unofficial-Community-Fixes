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
        Dim e As String = "Potion Effects: " & vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" & vbCrLf
        For Each effect In appliedEffects
            e += getEffectName(effect) & " applied." & vbCrLf
        Next
        e += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" & vbCrLf & "Press any non-movement key to continue."
        Game.lblEvent.Text = e
        Game.lblEvent.BringToFront()
        Game.lblEvent.Location = New Point((250 * Game.Size.Width / 688) - (Game.lblEvent.Size.Width / 2), 65 * Game.Size.Width / 688)
        Game.lblEvent.Visible = True
        Game.player.inv.invNeedsUDate = True
    End Sub

    Private Function getEffectName(ByRef pe As PEffect) As String
        '__________MAIN EFFECTS___________
        If pe.GetType Is GetType(HealthEffect) Then
            Return "Health gain"
        ElseIf pe.GetType Is GetType(MinHealthEffect) Then
            Return "Minor health gain"
        ElseIf pe.GetType Is GetType(MajHealthEffect) Then
            Return "Major health gain"
        ElseIf pe.GetType Is GetType(HHealthEffect) Then
            Return "Hyper health effect"
        ElseIf pe.GetType Is GetType(HManaEffect) Then
            Return "Hyper mana effect"
        ElseIf pe.GetType Is GetType(HungerEffect) Then
            Return "Hunger reduction"
        ElseIf pe.GetType Is GetType(ManaEffect) Then
            Return "Mana gain"
        ElseIf pe.GetType Is GetType(MinManaEffect) Then
            Return "Minor mana gain"
        ElseIf pe.GetType Is GetType(MajManaEffect) Then
            Return "Major mana gain"
        ElseIf pe.GetType Is GetType(MinHungerEffect) Then
            Return "Minor hunger reduction"
        ElseIf pe.GetType Is GetType(MinPainEffect) Then
            Return "Minor pain effect"
        ElseIf pe.GetType Is GetType(MinRestEffect) Then
            Return "Minor restoration effect"
        ElseIf pe.GetType Is GetType(PainEffect) Then
            Return "Pain effect"
        ElseIf pe.GetType Is GetType(RestEffect) Then
            Return "Restoration effect"
        ElseIf pe.GetType Is GetType(WeakRestEffect) Then
            Return "Weak restoration effect"
        ElseIf pe.GetType Is GetType(WeakMinRestEffect) Then
            Return "Weak minor restoration effect"
            '__________SIDE EFFECTS____________
        ElseIf pe.GetType Is GetType(BEEffect) Then
            Return "Breast enlargement effect"
        ElseIf pe.GetType Is GetType(BimbHairEffect) Then
            Return "Bimbo hair effect"
        ElseIf pe.GetType Is GetType(BimbNameEffect) Then
            Return "Bimbo name effect"
        ElseIf pe.GetType Is GetType(BimFaceEffect) Then
            Return "Facial bimbofication effect"
        ElseIf pe.GetType Is GetType(BlondeDyeEffect) Then
            Return "Blonde dye effect"
        ElseIf pe.GetType Is GetType(BSEffect) Then
            Return "Breast shrinking effect"
        ElseIf pe.GetType Is GetType(EarChangeEffect) Then
            Return "Ear change effect"
        ElseIf pe.GetType Is GetType(FemEffect) Then
            Return "Feminine effect"
        ElseIf pe.GetType Is GetType(FHairChangeEffect) Then
            Return "Hair change effect"
        ElseIf pe.GetType Is GetType(MajBEEffect) Then
            Return "Major breast enlargement effect"
        ElseIf pe.GetType Is GetType(MajBSEffect) Then
            Return "Major breast shrinking effect"
        ElseIf pe.GetType Is GetType(MasEffect) Then
            Return "Masculine effect"
        ElseIf pe.GetType Is GetType(HairBleachEffect) Then
            Return "Hair brightening effect"
        ElseIf pe.GetType Is GetType(MHairChangeEffect) Then
            Return "Hair change effect"
        ElseIf pe.GetType Is GetType(MinBimFaceEffect) Then
            Return "Minor facial bimbofication effect"
        ElseIf pe.GetType Is GetType(MinFemEffect) Then
            Return "Minor feminine effect"
        ElseIf pe.GetType Is GetType(MinMasEffect) Then
            Return "Minor masculine effect"
        ElseIf pe.GetType Is GetType(NameChangeEffect) Then
            Return "Name change effect"
        ElseIf pe.GetType Is GetType(RandDyeEffect) Then
            Return "Random color dye effect"
        ElseIf pe.GetType Is GetType(RedDyeEffect) Then
            Return "Red dye effect"
        ElseIf pe.GetType Is GetType(RHairChangeEffect) Then
            Return "Hair change effect"
        Else
            Return "Unknown effect"
        End If
    End Function
    Public Overridable Sub setEffectList()
        effectList = New List(Of PEffect)
        If effectList.Count <> 0 Then effectList.Clear()
    End Sub

    Public MustOverride Function mainEffectDistribution() As Integer
    Public MustOverride Function sideEffectDistribution(ByVal i As Integer) As Integer
End Class
