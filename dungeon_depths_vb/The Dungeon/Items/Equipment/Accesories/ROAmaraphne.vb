Public Class ROAmaraphne
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Ring_of_Amaraphne")
        id = 81
        If DDDateTime.isValen Then tier = 3 Else tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 3333

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, True)

        '|Description|
        setDesc("While on the surface, this seems to be but an ornate ring crafted from extremely precious materials, closer inspection reveals that the inside of its band is inscribed with a blessing of Amaraphne, Goddess of Love and Lust." & DDUtils.RNRN &
                       "Can be ""used"" to convert equipped armor to the corresponding slut variant" & vbCrLf &
                       "Increases DEF based on equipped armor" & vbCrLf &
                       "Increases ATK and WILL bonuses of slut variant armors" & vbCrLf &
                       "Increases SPD based on bust size" & vbCrLf &
                       "If certain conditions are met, Amaraphne may provide her aid should you fall" & DDUtils.RNRN &
                       getStatInformation())
    End Sub
    Public Overrides Sub use(ByRef p As Player)
        MyBase.use(p)
        If Not Equipment.clothingCurse1(p) Then TextEvent.push("While the ring glows a little, nothing seems to happen.")
        p.drawPort()
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        If p.perks(perk.moamarphne) > 0 Then
            EquipmentDialogBackend.equipAcce(p, "Nothing", False)
            TextEvent.pushAndLog("The ring slips off your finger...")
        End If

        p.perks(perk.rotlg) = 1
        p.UIupdate()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.rotlg) = -1
        Equipment.antiClothingCurse(p)
        p.drawPort()
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If p Is Nothing OrElse p.equippedArmor.getAntiSlutInd <> -1 Then Return 0
        If p.equippedArmor.getSlutVarInd <> -1 Then Return 0

        Return p.equippedArmor.a_boost * 1.5
    End Function
    Public Overrides Function getDBoost(ByRef p As Player) As Integer
        If p Is Nothing OrElse p.equippedArmor.getAntiSlutInd <> -1 Then Return 0
        If p.equippedArmor.getSlutVarInd <> -1 Then Return -p.equippedArmor.d_boost

        Dim buff = p.equippedArmor.d_boost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 5 Then
            buff = 5
        End If

        buff *= 4

        Return buff
    End Function
    Public Overrides Function getSBoost(ByRef p As Player) As Integer
        If p Is Nothing OrElse p.equippedArmor.getAntiSlutInd <> -1 Then Return 0
        Return CInt(2.2222 * p.breastSize)
    End Function
    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If p Is Nothing OrElse p.equippedArmor.getAntiSlutInd <> -1 Then Return 0
        If p.equippedArmor.getSlutVarInd <> -1 Then Return 0

        Return p.equippedArmor.w_boost * 1.5
    End Function

    Public Overrides Function getDesc() As Object
        Return "While on the surface, this seems to be but an ornate ring crafted from extremely precious materials, closer inspection reveals that the inside of its band is inscribed with a blessing of Amaraphne, Goddess of Love and Lust." & DDUtils.RNRN &
                       "Can be ""used"" to convert equipped armor to the corresponding slut variant" & vbCrLf &
                       "Increases DEF based on equipped armor" & vbCrLf &
                       "Increases ATK and WILL bonuses of slut variant armors" & vbCrLf &
                       "Increases SPD based on bust size" & vbCrLf &
                       If(Game.player1.getLust >= 50, "Amaraphne will come to your aid should you fall", "If certain conditions are met, Amaraphne may provide her aid should you fall") & DDUtils.RNRN &
                       getStatInformation()
    End Function
End Class
