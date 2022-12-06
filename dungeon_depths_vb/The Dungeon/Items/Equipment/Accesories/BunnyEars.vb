Public Class BunnyEars
    Inherits Accessory

    Public Const ITEM_NAME As String = "Bunny_Ears"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 225
        If DDDateTime.isAni Then tier = 2 Else tier = Nothing

        '|Item Flags|
        usable = false
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        s_boost = 22
        count = 0
        value = 4000

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, True)

        '|Description|
        setDesc("A black headband with a pair of white rabbit ears that would go well with a skimpy outfit.  While it seems ordinary enough at a glance, every once and a while it sparks suspiciously." & DDUtils.RNRN &
                "Dodge Effect" & DDUtils.RNRN &
                "If equipped by a Bunny Girl:" & vbCrLf &
                "+Max HP based on equipped armor" & vbCrLf &
                "+Max MP based on lust" & vbCrLf &
                "+DEF based on equipped armor" & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.prt.setIAInd(pInd.hat, 14, True, True)
        p.perks(perk.bunnyears) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        If p.className.Equals("Bunny Girl") Then p.revertToPState()

        If p.prt.checkNDefFemInd(pInd.hat, 14) Then p.prt.setIAInd(pInd.hat, 0, True, False)
        p.perks(perk.bunnyears) = -1
    End Sub

    Public Overrides Function getHBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0
        If Not p.className.Equals("Bunny Girl") Then Return 0
        If Not (p.equippedArmor.getSlutVarInd = -1 And p.equippedArmor.getAntiSlutInd <> -1) And Not p.equippedArmor.getName.Contains("Bunny") Then Return 0

        Dim buff = p.equippedArmor.d_boost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 6 Then
            buff = 6
        End If

        buff *= 3.3

        Return buff + (p.equippedArmor.h_boost * 1.3)
    End Function
    Public Overrides Function getDBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0
        If Not p.className.Equals("Bunny Girl") Then Return 0
        If Not (p.equippedArmor.getSlutVarInd = -1 And p.equippedArmor.getAntiSlutInd <> -1) And Not p.equippedArmor.getName.Contains("Bunny") Then Return 0

        Dim buff = p.equippedArmor.d_boost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 6 Then
            buff = 6
        End If

        buff *= 3.3

        Return buff + (p.equippedArmor.d_boost * 1.3)
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return p.getLust * 0.33
    End Function

    Public Overrides Function getDesc() As Object
        Return "A black headband with a pair of white rabbit ears that would go well with .  While it seems ordinary enough at a glance, every once and a while it sparks suspiciously." & DDUtils.RNRN &
                "Dodge Effect" & DDUtils.RNRN &
                "If equipped by a Bunny Girl:" & vbCrLf &
                "+Max HP based on equipped armor" & vbCrLf &
                "+Max MP based on lust" & vbCrLf &
                "+DEF based on equipped armor" & DDUtils.RNRN &
                getStatInformation()
    End Function
End Class
