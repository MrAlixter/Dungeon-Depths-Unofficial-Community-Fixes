Public Class CozySweater
    Inherits Armor

    Sub New()
        MyBase.setName("Cozy_Sweater")
        MyBase.setDesc("This sweater is for the chillier parts of the year, and keeps its wearer nice and toasty out in the cold.  Well, that or it's a part of some frost demon(ess)'s elaborate scheme to freeze the dungeon solid..." & DDUtils.RNRN &
                        "That would explain the arcane runes on the collar and the suspicious boost in magical ability it offers its wearer, at least." & vbCrLf &
                        "Fits sizes -1 through 3" & vbCrLf &
                       "+10 DEF" & vbCrLf &
                       "+15 MANA") '& vbCrLf & _
        id = 175

        If DDDateTime.isHoli Then
            tier = 2
        ElseIf DDDateTime.isWinter Then
            tier = 3
        Else
            tier = Nothing
        End If

        MyBase.setUsable(False)
        MyBase.dBoost = 10
        MyBase.mBoost = 15
        MyBase.count = 0
        MyBase.value = 2450
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(237, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(69, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(70, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(71, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If Not p.knownSpells.Contains("Snowball") Then p.knownSpells.Add("Snowball")
    End Sub
    Public Overrides Sub onUnEquip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.knownSpells.Remove("Snowball")
    End Sub
End Class
