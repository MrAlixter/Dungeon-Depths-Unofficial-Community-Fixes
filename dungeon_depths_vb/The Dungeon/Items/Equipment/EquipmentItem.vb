Public Class EquipmentItem
    Inherits Item

    Protected Friend a_boost As Integer = 0
    Protected Friend d_boost As Integer = 0
    Protected Friend h_boost As Integer = 0
    Protected Friend m_boost As Integer = 0
    Protected Friend s_boost As Integer = 0
    Protected Friend w_boost As Integer = 0

    Public cursed As Boolean = False

    Protected owner As Player

    Overridable Sub onEquip(ByRef p As Player)
        owner = p
    End Sub
    Overridable Sub onUnequip(ByRef p As Player)
        owner = Nothing
    End Sub

    Public Overridable Function getABoost(ByRef p As Player) As Integer
        Return a_boost
    End Function
    Public Overridable Function getDBoost(ByRef p As Player) As Integer
        Return d_boost
    End Function
    Public Overridable Function getHBoost(ByRef p As Player) As Integer
        Return h_boost
    End Function
    Public Overridable Function getMBoost(ByRef p As Player) As Integer
        Return m_boost
    End Function
    Public Overridable Function getSBoost(ByRef p As Player) As Integer
        Return s_boost
    End Function
    Public Overridable Function getWBoost(ByRef p As Player) As Integer
        Return w_boost
    End Function

    Public Function getStatInformation() As String
        Dim out As String = ""

        If getHBoost(owner) <> 0 Then out += If(getHBoost(owner) > 0, "+", "-") & Math.Abs(getHBoost(owner)) & " Max HP" & vbCrLf
        If getMBoost(owner) <> 0 Then out += If(getMBoost(owner) > 0, "+", "-") & Math.Abs(getMBoost(owner)) & " Max MP" & vbCrLf
        If getABoost(owner) <> 0 Then out += If(getABoost(owner) > 0, "+", "-") & Math.Abs(getABoost(owner)) & " ATK" & vbCrLf
        If getDBoost(owner) <> 0 Then out += If(getDBoost(owner) > 0, "+", "-") & Math.Abs(getDBoost(owner)) & " DEF" & vbCrLf
        If getSBoost(owner) <> 0 Then out += If(getSBoost(owner) > 0, "+", "-") & Math.Abs(getSBoost(owner)) & " SPD" & vbCrLf
        If getWBoost(owner) <> 0 Then out += If(getWBoost(owner) > 0, "+", "-") & Math.Abs(getWBoost(owner)) & " WILL" & vbCrLf

        If Not out.Contains(vbCrLf) Then out += vbCrLf

        Return out
    End Function
End Class
