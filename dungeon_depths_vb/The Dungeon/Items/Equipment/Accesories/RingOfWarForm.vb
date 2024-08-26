Public Class RingOfWarForm
    Inherits Accessory

    Public Const ITEM_NAME As String = "Ring_of_Two_Phases"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 450
        tier = 3

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 2666

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A clear crystal ring that pulses with soft light." & DDUtils.RNRN &
                "Saves the player's transformed state (including Valkyries and Magical Girls).  When the wearer enters combat, restores them to that transformed state.  When they leave combat, returns them to their untransformed state." & DDUtils.RNRN &
                "Cannot be equipped if the user's form is unstable and they are not a Valkyrie or Magical Girl.  Cannot be equipped if the user's class and form are the same as their last revert point." & DDUtils.RNRN &
                "Reverts transformations on equip, if the player is not in combat." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return 4
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If p.solFlag Then Exit Sub

        'MsgBox(Transformation.canBeTFed(p) & DDUtils.RNRN & p.className.Contains("Valkyrie") & DDUtils.RNRN & p.className.Contains("Magical Girl"))
        If (Transformation.canBeTFed(p) Or p.className.Contains("Valkyrie") Or p.className.Contains("Magical Girl")) And Not p.perks(perk.succubuscurse) > 0 And Not p.className.Contains("​") And Not (p.pState.pClass.name = p.className And p.pState.pForm.name = p.formName) Then
            p.formStates(stateInd.warformState) = New State(p)

            If Not Game.combat_engaged Then
                TextEvent.fpushAndLog("You revert from your combat form!")
                p.pState.equippedAcce = p.equippedAcce
                PerkEffects.warformSwap(p, p.pState)
            End If
        ElseIf p.pState.pClass.name = p.className And p.pState.pForm.name = p.formName Then
            If Not Game.lblEvent.Visible And Not Game.pnlEvent.Visible Then TextEvent.fpushAndLog("Your form has not gone through enough of a change since you last remember, and the ring slides off your finger.") Else TextEvent.pushLog("Your form too stable, and the ring slides off your finger.")
            EquipmentDialogBackend.accessoryChange(p, "Nothing", False)
        Else
            If Not Game.lblEvent.Visible And Not Game.pnlEvent.Visible Then TextEvent.fpushAndLog("Your form is unstable, and the ring slides off your finger.") Else TextEvent.pushLog("Your form is unstable, and the ring slides off your finger.")
            EquipmentDialogBackend.accessoryChange(p, "Nothing", False)
        End If
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        If p.solFlag Then Exit Sub

        If Game.combat_engaged Then
            TextEvent.fpushAndLog("You revert from your combat form!")
            PerkEffects.warformSwap(p, p.formStates(stateInd.preWarformState))
        End If

        p.formStates(stateInd.warformState) = New State()
        p.formStates(stateInd.preWarformState) = New State()
    End Sub
End Class
