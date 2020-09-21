Public Class BunnyEars
    Inherits Accessory

    Sub New()
        MyBase.setName("Bunny_Ears")
        MyBase.setDesc("A black headband with a pair of white rabbit ears that would go well with .  While it seems ordinary enough at a glance, every once and a while it sparks suspiciously." & vbCrLf & _
                       "+22 Speed, Dodge Effect" & vbCrLf &
                       "If equipped by a Bunny Girl,  +Max HP, DEF based on equipped armor, +Max Mana based on lust")
        id = 225
        If DDDateTime.isAni Then tier = 2 Else tier = Nothing
        MyBase.setUsable(False)
        MyBase.sBoost = 22
        MyBase.count = 0
        MyBase.value = 4000
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, True)
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.prt.setIAInd(pInd.hat, 14, True, True)
        p.perks(perk.bunnyears) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.prt.checkNDefFemInd(pInd.hat, 14) Then p.prt.setIAInd(pInd.hat, 0, True, False)
        If p.className.Equals("Bunny Girl") Then p.revertToPState()
        p.perks(perk.bunnyears) = -1
    End Sub

    Public Overrides Function getHBoost(ByRef p As Player) As Integer
        If Not p.className.Equals("Bunny Girl") Then Return 0
        If Not (p.equippedArmor.getSlutVarInd = -1 And p.equippedArmor.getAntiSlutVarInd <> -1) And Not p.equippedArmor.getName.Contains("Bunny") Then Return 0

        Dim buff = p.equippedArmor.dBoost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 6 Then
            buff = 6
        End If

        buff *= 3.3

        Return buff + (p.equippedArmor.hBoost * 1.3)
    End Function
    Public Overrides Function getDBoost(ByRef p As Player) As Integer
        If Not p.className.Equals("Bunny Girl") Then Return 0
        If Not (p.equippedArmor.getSlutVarInd = -1 And p.equippedArmor.getAntiSlutVarInd <> -1) And Not p.equippedArmor.getName.Contains("Bunny") Then Return 0

        Dim buff = p.equippedArmor.dBoost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 6 Then
            buff = 6
        End If

        buff *= 3.3

        Return buff + (p.equippedArmor.dBoost * 1.3)
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        Return p.getLust * 0.33
    End Function
End Class
