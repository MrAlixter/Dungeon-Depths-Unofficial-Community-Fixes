Public Class CozySweater
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Cozy_Sweater")
        id = 175
        If DDDateTime.isHoli Then
            tier = 2
        ElseIf DDDateTime.isWinter Then
            tier = 3
        Else
            tier = Nothing
        End If

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.droppable = False
        rando_inv_allowed = False

        '|Stats|
        MyBase.d_boost = 25
        MyBase.m_boost = 15
        w_boost = 15
        count = 0
        value = 2450

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(237, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(69, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(70, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(71, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(345, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(73, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(327, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(328, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(329, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(330, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(331, True, True)

        '|Description|
        setDesc("This sweater is for the chillier parts of the year, and keeps its wearer nice and toasty out in the cold.  Well, that or it's a part of some frost demon(ess)'s elaborate scheme to freeze the dungeon solid..." & DDUtils.RNRN &
                        "That would explain the arcane runes on the collar and the suspicious boost in magical ability it offers its wearer, at least." & DDUtils.RNRN &
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.learnSpell("Snowball")
    End Sub
    Public Overrides Sub onUnEquip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.knownSpells.Remove("Snowball")
    End Sub
End Class
