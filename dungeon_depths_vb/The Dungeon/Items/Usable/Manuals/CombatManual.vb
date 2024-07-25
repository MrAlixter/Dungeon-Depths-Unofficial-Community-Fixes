Public Class CombatManual
    Inherits Manual

    Public Const ITEM_NAME As String = "Combat_Manual"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 88
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A simple, leather-bound book that likely contains some skills specifically for combat.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f10f12
                Return 1
            Case LootTable.bracket.f13
                Return 1
            Case LootTable.bracket.f14fXX
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Shared Shadows Function getSpecials() As String()
        Return New CombatManual().specials
    End Function
    Public Overrides Function specials() As String()
        Dim options As List(Of String) = New List(Of String)({"Heavy Blow", "Aura Cannon", "Dodge"})
        Dim p As Player = Game.player1

        Select Case p.perks(perk.meltype)
            Case melType.sword
                options = DDUtils.union(options, New List(Of String)({"Zoom Step", "Draw Cut", "Fencing Flurry", "Mordhau"}))
            Case melType.axe
                options = DDUtils.union(options, New List(Of String)({"Optimal Chop", "Guillotine", "Twofold Slash", "Cleave"}))
            Case melType.dagger
                options = DDUtils.union(options, New List(Of String)({"Slit", "Stab Barrage", "Precision Incision", "Hit and Run"}))
            Case melType.spear
                options = DDUtils.union(options, New List(Of String)({"Keep Away", "Pierce And Punish", "Power Drill", "Vampiric Thrust"}))
            Case melType.whip
                'options = DDUtils.union(options, New List(Of String)({}))
                'options = New List(Of String)({})
            Case melType.bludgeon
                options = DDUtils.union(options, New List(Of String)({"Thwack Barrage"}))
            Case melType.fist
                options = DDUtils.union(options, New List(Of String)({"Rapid Fire Jabs", "Focused Roundhouse", "Focused Barrage"}))
        End Select

        Return options.ToArray()
    End Function
End Class
