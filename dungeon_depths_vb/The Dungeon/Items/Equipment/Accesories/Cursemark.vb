Public Class Cursemark
    Inherits Accessory
    Sub New()
        '|ID Info|
        setName("Cursemark")
        id = 168
        tier = Nothing

        '|Item Flags|
        usable = false
        cursed = True
        under_b_clothes = True

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)

        '|Description|
        setDesc("A glowing pink tattoo that displays one's status as under the effect of demonic magic." & DDUtils.RNRN &
                "Negates attack while increasing Max MP and WILL" & vbCrLf &
                "Raises minimum lust based on availible MP" & vbCrLf &
                "Mana does not re-generate" & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub discard()
        TextEvent.push("You can't discard this!")
        TextEvent.pushLog("You can't discard this!")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.perks(perk.cmark) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        p.perks(perk.cmark) = -1
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return -1 * (((p.attack + p.aBuff) * p.pForm.a * p.pClass.a) + p.equippedArmor.getABoost(p) + p.equippedWeapon.getABoost(p))
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return (((p.attack + p.aBuff) * p.pForm.a * p.pClass.a) + p.equippedArmor.getABoost(p) + p.equippedWeapon.getABoost(p)) / 2
    End Function
    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return (((p.attack + p.aBuff) * p.pForm.a * p.pClass.a) + p.equippedArmor.getABoost(p) + p.equippedWeapon.getABoost(p)) / 2
    End Function

    Public Overrides Function getDesc() As Object
        Return "A glowing pink tattoo that displays one's status as under the effect of demonic magic." & DDUtils.RNRN &
               "Negates attack while increasing Max MP and WILL" & vbCrLf &
               "Raises minimum lust based on availible MP" & vbCrLf &
               "Mana does not re-generate" & DDUtils.RNRN &
               getStatInformation()
    End Function
    Shared Function getForm() As preferredForm
        Return New preferredForm(Color.White, Color.FromArgb(255, 255, 78, 78), True, True, 2, True, 0, 26, 6)
    End Function
End Class
