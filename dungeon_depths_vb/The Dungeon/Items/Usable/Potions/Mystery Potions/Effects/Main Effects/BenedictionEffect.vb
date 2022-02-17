Public Class BenedictionEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        If p.perks(perk.copoly) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.copoly) = -1 : TextEvent.pushLog("The curse of polymorph is neutralized")
        If p.perks(perk.cogreed) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.cogreed) = -1 : TextEvent.pushLog("The curse of greed is neutralized")
        If p.perks(perk.corust) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.corust) = -1 : TextEvent.pushLog("The curse of rust is neutralized")
        If p.perks(perk.comilk) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.comilk) = -1 : TextEvent.pushLog("The curse of milk is neutralized")
        If p.perks(perk.coblind) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.coblind) = -1 : TextEvent.pushLog("The curse of blindness is neutralized")
        If p.perks(perk.faecurse) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.faecurse) = -1 : TextEvent.pushLog("The fae's curse is neutralized")
        If p.perks(perk.succubuscurse) > -1 Then p.perks(perk.succubuscurse) = -1 : TextEvent.pushLog("The succubus's curse is neutralized")
        If p.perks(perk.coftheox) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.coftheox) = -1 : TextEvent.pushLog("The curse of the ox is neutralized")

        If p.equippedArmor.getCursed(p) Then
            EquipmentDialogBackend.equipArmor(p, "Naked", False)
            TextEvent.pushLog("Cursed armor removed")
        ElseIf p.equippedWeapon.getCursed(p) Then
            EquipmentDialogBackend.equipWeapon(p, "Fists", False)
            TextEvent.pushLog("Cursed weapon removed")
        ElseIf p.equippedAcce.getCursed(p) Then
            EquipmentDialogBackend.equipAcce(p, "Nothing", False)
            TextEvent.pushLog("Cursed accessory removed")
        End If

        out += "Some curses or equipped cursed items may have been removed."
        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Benediction effect"
    End Function
End Class
