Public Class Bowtie
    Inherits Accessory

    Public Const ITEM_NAME As String = "Bowtie"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 97
        tier = 3

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.s_boost = 5
        count = 0
        value = 2000

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(8, False, True)

        '|Description|
        setDesc("A high class necktie that improves agility and speed.  While it seems ordinary enough at a glance, every once and a while it sparks suspiciously." & DDUtils.RNRN & _
                       "Medium chance to dodge oncoming attacks" & vbCrLf &
                       "Increases Max MP and ATK if equipped by a Bunny Girl" & DDUtils.RNRN &
                       getStatInformation())
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.perks(perk.bowtie) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        p.perks(perk.bowtie) = -1
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0
        If Not p.className.Equals("Bunny Girl") Then Return 0
        If Not (p.equippedArmor.getSlutVarInd = -1 And p.equippedArmor.getAntiSlutInd <> -1) And Not p.equippedArmor.getName.Contains("Bunny") Then Return 0

        Dim buff = p.equippedArmor.d_boost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 5 Then
            buff = 5
        End If

        buff *= 3.3

        Return buff + (p.equippedArmor.a_boost * 1.2)
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0
        If Not p.className.Equals("Bunny Girl") Then Return 0
        If Not (p.equippedArmor.getSlutVarInd = -1 And p.equippedArmor.getAntiSlutInd <> -1) And Not p.equippedArmor.getName.Contains("Bunny") Then Return 0

        Dim buff = p.equippedArmor.d_boost

        If buff = 0 Then
            buff = 3
        ElseIf buff < 5 Then
            buff = 5
        End If

        buff *= 3.3

        Return buff + (p.equippedArmor.m_boost * 1.2)
    End Function

    Public Overrides Function getDesc() As Object
        Return "A high class necktie that improves agility and speed.  While it seems ordinary enough at a glance, every once and a while it sparks suspiciously." & DDUtils.RNRN & _
                       "Medium chance to dodge oncoming attacks" & vbCrLf &
                       "Increases Max Mana and ATK if equipped by a Bunny Girl" & DDUtils.RNRN &
                       getStatInformation()
    End Function
End Class
