Public Class EquipmentItem
    Inherits Item

    Protected Friend aBoost As Integer = 0
    Protected Friend dBoost As Integer = 0
    Protected Friend hBoost As Integer = 0
    Protected Friend mBoost As Integer = 0
    Protected Friend sBoost As Integer = 0
    Protected Friend wBoost As Integer = 0

    Public isCursed As Boolean = False

    Protected owner As Player

    Overridable Sub onEquip(ByRef p As Player)
        owner = p
    End Sub
    Overridable Sub onUnequip(ByRef p As Player)
        owner = Nothing
    End Sub

    Public Overridable Function getABoost(ByRef p As Player) As Integer
        Return aBoost
    End Function
    Public Overridable Function getDBoost(ByRef p As Player) As Integer
        Return dBoost
    End Function
    Public Overridable Function getHBoost(ByRef p As Player) As Integer
        Return hBoost
    End Function
    Public Overridable Function getMBoost(ByRef p As Player) As Integer
        Return mBoost
    End Function
    Public Overridable Function getSBoost(ByRef p As Player) As Integer
        Return sBoost
    End Function
    Public Overridable Function getWBoost(ByRef p As Player) As Integer
        Return wBoost
    End Function

    Public Function getStatInformation() As String
        Dim out As String = ""

        If getHBoost(owner) > 0 Then out += "+" & getHBoost(owner) & " Max HP" & vbCrLf
        If getMBoost(owner) > 0 Then out += "+" & getMBoost(owner) & " Max MP" & vbCrLf
        If getABoost(owner) > 0 Then out += "+" & getABoost(owner) & " ATK" & vbCrLf
        If getDBoost(owner) > 0 Then out += "+" & getDBoost(owner) & " DEF" & vbCrLf
        If getSBoost(owner) > 0 Then out += "+" & getSBoost(owner) & " SPD" & vbCrLf
        If getWBoost(owner) > 0 Then out += "+" & getWBoost(owner) & " WILL" & vbCrLf

        If Not out.Contains(vbCrLf) Then out += vbCrLf

        Return out
    End Function
End Class
