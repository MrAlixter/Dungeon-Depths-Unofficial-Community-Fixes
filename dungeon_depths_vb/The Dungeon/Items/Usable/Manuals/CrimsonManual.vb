Public Class CrimsonManual
    Inherits Manual

    Public Const ITEM_NAME As String = "Crimson_Manual"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 227
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 666

        '|Description|
        setDesc("A smoldering leather-bound book that contains something practical written by a succubus.")
    End Sub

    Public Overrides Function specials() As String()
        Dim options As List(Of String) = New List(Of String)({"Shapeshift", "Chameleon", "Enskimpen"})
        Dim p As Player = Game.player1

        Select Case p.perks(perk.meltype)
            Case melType.dagger
                options = DDUtils.union(options, New List(Of String)({"Beelzebodkin"}))
            Case melType.spear
                options = DDUtils.union(options, New List(Of String)({"Lucifork"}))
            Case melType.whip
                options = DDUtils.union(options, New List(Of String)({"Lililash"}))
            Case melType.fist
                options = DDUtils.union(options, New List(Of String)({"Blade of Nails"}))
        End Select

        Return options.ToArray()
    End Function

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If DDDateTime.isValen Then Return 2

        Return MyBase.getTier(floor_num)
    End Function
End Class
