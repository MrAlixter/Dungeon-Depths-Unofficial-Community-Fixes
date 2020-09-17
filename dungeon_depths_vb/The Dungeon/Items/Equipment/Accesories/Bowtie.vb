Public Class Bowtie
    Inherits Accessory

    Sub New()
        MyBase.setName("Bowtie")
        MyBase.setDesc("A high class necktie that improves agility and speed.  While it seems ordinary enough at a glance, every once and a while it sparks suspiciously." & vbCrLf & _
                       "+5 Speed, Dodge Effect" & vbCrLf &
                       "If equipped by a Bunny Girl, +Max Mana and ATK based on equipped clothing")
        id = 97
        tier = 3
        MyBase.setUsable(False)
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 2000
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(8, False, True)
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks(perk.bowtie) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.bowtie) = -1
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If Not p.pClass.name.Equals("Bunny Girl") Then Return 0
        If Not (p.equippedArmor.getSlutVarInd = -1 And p.equippedArmor.getAntiSlutVarInd <> -1) And Not p.equippedArmor.getName.Contains("Bunny") Then Return 0

        Dim buff = p.equippedArmor.dBoost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 5 Then
            buff = 5
        End If

        buff *= 3.3

        Return buff + (p.equippedArmor.aBoost * 1.2)
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If Not p.pClass.name.Equals("Bunny Girl") Then Return 0
        If Not (p.equippedArmor.getSlutVarInd = -1 And p.equippedArmor.getAntiSlutVarInd <> -1) And Not p.equippedArmor.getName.Contains("Bunny") Then Return 0

        Dim buff = p.equippedArmor.dBoost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 5 Then
            buff = 5
        End If

        buff *= 3.3

        Return buff + (p.equippedArmor.mBoost * 1.2)
    End Function
End Class
