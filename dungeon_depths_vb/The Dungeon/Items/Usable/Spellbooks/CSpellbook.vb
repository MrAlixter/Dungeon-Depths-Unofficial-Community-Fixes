Public Class CSpellbook
    Inherits Spellbook

    Public Shadows Const ITEM_NAME As String = "Crimson_Spellbook"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 226
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 666

        '|Description|
        setDesc("A smoldering leather-bound book that contains something magic written by a succubus.")
    End Sub

    Public Overrides Function spells() As String()
        Dim options As List(Of String) = New List(Of String)({"Raise Lust", "Hellfireball", "Reductive Mending"})
        Dim p As Player = Game.player1

        Select Case p.perks(perk.magtype)
            Case magType.fire
                options = DDUtils.union(options, New List(Of String)({"Cynn's Braid"}))
            Case magType.blight
                options = DDUtils.union(options, New List(Of String)({"Puff Up"}))
            Case magType.flux
                options = DDUtils.union(options, New List(Of String)({"Self Polymorph", "Polymorph Enemy"}))
        End Select

        Return options.ToArray()
    End Function
    Public Overrides Function selfPolyForms() As String()
        Dim options As List(Of String) = New List(Of String)({})
        Dim p As Player = Game.player1

        Select Case p.perks(perk.magtype)
            Case magType.flux
                options = DDUtils.union(options, New List(Of String)({"Oni+"}))
        End Select

        Return options.ToArray()
    End Function
    Public Overrides Function enemPolyForms() As String()
        Dim options As List(Of String) = New List(Of String)({})
        Dim p As Player = Game.player1

        Select Case p.perks(perk.magtype)
            Case magType.flux
                options = DDUtils.union(options, New List(Of String)({"Hellhound"}))
        End Select

        Return options.ToArray()
    End Function

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If DDDateTime.isValen Then Return 2

        Return MyBase.getTier(floor_num)
    End Function
End Class
