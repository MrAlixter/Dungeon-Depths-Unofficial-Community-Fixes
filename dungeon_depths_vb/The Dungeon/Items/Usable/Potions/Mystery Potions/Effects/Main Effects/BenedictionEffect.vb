Public Class BenedictionEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        If p.perks(perk.copoly) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.copoly) = -1 : Game.pushLstLog("The curse of polymorph is neutralized")
        If p.perks(perk.cogreed) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.cogreed) = -1 : Game.pushLstLog("The curse of greed is neutralized")
        If p.perks(perk.corust) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.corust) = -1 : Game.pushLstLog("The curse of rust is neutralized")
        If p.perks(perk.comilk) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.comilk) = -1 : Game.pushLstLog("The curse of milk is neutralized")
        If p.perks(perk.coblind) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.coblind) = -1 : Game.pushLstLog("The curse of blindness is neutralized")
        If p.perks(perk.faecurse) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.faecurse) = -1 : Game.pushLstLog("The fae's curse is neutralized")
        If p.perks(perk.succubuscurse) > -1 Then p.perks(perk.succubuscurse) = -1 : Game.pushLstLog("The succubus's curse is neutralized")
        If p.perks(perk.coftheox) > -1 And Int(Rnd() * 2) = 0 Then p.perks(perk.coftheox) = -1 : Game.pushLstLog("The curse of the ox is neutralized")

        If p.equippedArmor.cursed Then
            Equipment.equipArmor(p, "Naked")
            Game.pushLstLog("Cursed armor removed")
        ElseIf p.equippedWeapon.cursed Then
            Equipment.equipWeapon(p, "Fists")
            Game.pushLstLog("Cursed weapon removed")
        ElseIf p.equippedAcce.cursed Then
            Equipment.equipAcce(p, "Nothing")
            Game.pushLstLog("Cursed accessory removed")
        End If

        out += "Some curses or equipped cursed items may have been removed."
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Benediction effect"
    End Function
End Class
