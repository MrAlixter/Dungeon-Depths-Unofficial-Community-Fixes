Public Class Accessory
    Inherits Item
    'Accessories are equippable items that provide small passive buffs
    Protected aBoost As Integer = 0
    Protected dBoost As Integer = 0
    Protected hBoost As Integer = 0
    Protected mBoost As Integer = 0
    Protected sBoost As Integer = 0
    Protected wBoost As Integer = 0
    Public fInd As Tuple(Of Integer, Boolean, Boolean)
    Public mInd As Tuple(Of Integer, Boolean, Boolean)
    Public isCursed, underClothes As Boolean
    Overridable Sub onEquip(ByRef p As Player)
    End Sub
    Overridable Sub onUnequip(ByRef p As Player)
    End Sub

    Public Overrides Sub discard()
        If isCursed And Game.player1.equippedAcce.getAName.Equals(getAName) Then
            Game.pushLblEvent("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
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
    Public Overridable Function getWBoost() As Integer
        Return wBoost
    End Function
End Class
