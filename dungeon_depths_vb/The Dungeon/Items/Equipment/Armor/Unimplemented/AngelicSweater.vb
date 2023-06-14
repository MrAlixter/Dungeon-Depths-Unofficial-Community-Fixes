Public Class AngelicSweater
    Inherits Armor

    Public Const ITEM_NAME As String = "Angelic_Sweater"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 199
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False
        compress_breast = True

        '|Stats|
        h_boost = 10
        d_boost = 5
        m_boost = 20
        count = 0
        value = 7777

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(280, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(281, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(282, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(283, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(178, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(179, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(180, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(181, True, True)

        '|Description|
        setDesc("A shimmering soft white sweater.  When worn by someone with wings, an enchantment becomes active and boosts all stats." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDescription() As Object
        Return "A shimmering soft white sweater.  When worn by someone with wings, an enchantment becomes active and boosts all stats." & DDUtils.RNRN &
                If(playerHasWings(owner), "You have wings!" & DDUtils.RNRN, "") &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation()
    End Function

    Private Function playerHasWings(ByRef p As Player) As Boolean
        If p Is Nothing Then Return False

        Return Not p.prt.iArrInd(pInd.wings).Item1 = 0 And Not p.prt.iArrInd(pInd.wings).Item1 = 4
    End Function

    Public Overrides Function getHBoost(ByRef p As Player) As Integer
        If playerHasWings(p) Then Return 20 Else Return h_boost
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If playerHasWings(p) Then Return 30 Else Return m_boost
    End Function
    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If playerHasWings(p) Then Return 20 Else Return a_boost
    End Function
    Public Overrides Function getDBoost(ByRef p As Player) As Integer
        If playerHasWings(p) Then Return 20 Else Return d_boost
    End Function
    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If playerHasWings(p) Then Return 30 Else Return w_boost
    End Function
    Public Overrides Function getSBoost(ByRef p As Player) As Integer
        If playerHasWings(p) Then Return 30 Else Return s_boost
    End Function
End Class
