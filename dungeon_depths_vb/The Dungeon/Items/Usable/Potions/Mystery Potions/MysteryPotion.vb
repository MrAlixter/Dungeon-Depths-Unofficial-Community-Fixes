Public MustInherit Class MysteryPotion
    Inherits Item
    Protected effectList As List(Of PEffect)
    Protected fakeName As String
    Public hasBeenUsed As Boolean = False
    Public Shadows onBuy As Action = AddressOf reveal

    '| -- Potion names and description adjectives -- |
    'Mental_Potion				eerie
    'Ass_Growth_Potion		    odd
    'Dick_Growth_Potion		    peculiar
    'Masculine_Potion		    vexing
    'Hazardous_Potion		    strange
    'Sex_Swap_Potion			funny
    'Mysterious_Potion		    fair
    'Gentle_Potion			    curious
    'Feminine_Potion			off
    'Ditzy_Potion			    puzzling
    'Breast_Shrink._Potion	    bizzare
    'Blinding_Potion			vibrant
    'Breast_Growth_Potion	    weird
    'Chilling_Potion			freaky
    'Ass_Shrink._Potion		    spooky
    'Dick_Shrink._Potion		occult
    'Hyper_Health_Potion		unearthly
    'Hyper_Mana_Potion		    outlandish
    'Potion_of_Benediction	    wonky
    'Potion_of_Dodging          dodgy
    'Incandescent_Potion        suspicious

    Overrides Sub use(ByRef p As Player)
        If Not hasBeenUsed Then reveal()
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You drink the " & getName())

        setEffectList()

        For Each effect In effectList
            effect.apply(p)
        Next
        pushLblEventEffects(effectList)

        effectList.Clear()
        count -= 1
    End Sub

    Sub textlessApply(ByRef p As Player)
        setEffectList()

        For Each effect In effectList
            effect.apply(p)
        Next
        pushLblEventEffects(effectList)

        effectList.Clear()
    End Sub

    Sub mimicThrow(ByRef p As Player)
        If Not hasBeenUsed Then reveal()
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("The " & getName() & " shatters!")

        setEffectList()

        For Each effect In effectList
            effect.apply(p)
        Next

        pushLblEventEffects(effectList)

        effectList.Clear()
    End Sub



    Public Sub pushLblEventEffects(ByRef appliedEffects As List(Of PEffect))
        Dim e As String = "Potion Effects:" & getDisplayBar()

        For Each effect In appliedEffects
            e += vbCrLf & getEffectName(effect) & " applied."
            TextEvent.pushLog(getEffectName(effect) & " applied.")
        Next

        e += getDisplayBar()

        TextEvent.push(e)

        Game.player1.inv.invNeedsUDate = True
    End Sub
    Private Function getDisplayBar() As String
        Return If(Not Game.combat_engaged, vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", "")
    End Function
    Private Function getEffectName(ByRef pe As PEffect) As String
        Return pe.getEffectDesc
    End Function
    Public Overridable Sub setEffectList()
        effectList = New List(Of PEffect)
        If effectList.Count <> 0 Then effectList.Clear()
    End Sub
    Public Overrides Function getName() As String
        If hasBeenUsed Then
            Return MyBase.getName()
        Else
            Return fakeName
        End If
    End Function
    Public Sub setFName(ByVal n As String)
        fakeName = n
    End Sub
    Public MustOverride Function mainEffectDistribution() As Integer
    Public MustOverride Function sideEffectDistribution(ByVal i As Integer) As Integer

    Public Sub reveal()
        fakeName = getName()
        hasBeenUsed = True
        Game.lstInventory.SelectedIndex = -1
    End Sub
End Class
