Public Class CozySweater
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Cozy_Sweater")
        id = 175
        If DDDateTime.isHoli Then
            tier = 2
        ElseIf DDDateTime.isWinter Then
            tier = 3
        Else
            tier = Nothing
        End If

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.dBoost = 25
        MyBase.mBoost = 15
        MyBase.wBoost = 15
        MyBase.count = 0
        MyBase.value = 2450

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(237, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(69, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(70, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(71, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(345, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(73, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(327, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(328, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(329, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(330, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(331, True, True)

        '|Description|
        MyBase.setDesc("This sweater is for the chillier parts of the year, and keeps its wearer nice and toasty out in the cold.  Well, that or it's a part of some frost demon(ess)'s elaborate scheme to freeze the dungeon solid..." & DDUtils.RNRN &
                        "That would explain the arcane runes on the collar and the suspicious boost in magical ability it offers its wearer, at least." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
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
