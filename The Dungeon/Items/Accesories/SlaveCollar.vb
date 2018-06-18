Public Class SlaveCollar
    Inherits Accessory
    'The heart necklace provides no bonuses
    Sub New()
        MyBase.setName("Slave_Collar")
        MyBase.setDesc("A collar commonly placed around the necks of the thralls." & vbCrLf & _
                       "Provides no bonus.")
        id = 69
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 200
        MyBase.fInd = New Tuple(Of Integer, Boolean)(7, True)
    End Sub
    Overrides Sub onEquip()
        Dim crystalX As Integer
        Dim crystalY As Integer
        Do While (Game.mBoard(crystalY, crystalX).Tag <> 1 Or Game.mBoard(crystalY, crystalX).Text <> "")
            crystalX = CInt(Int(Rnd() * Game.mBoardWidth))
            crystalY = CInt(Int(Rnd() * Game.mBoardHeight))
        Loop
        Dim crystal = New Point(crystalX, crystalY)
        Game.mBoard(crystalY, crystalX).Tag = 2
        Game.mBoard(crystalY, crystalX).Text = "c"

        Game.player.forcedPath = Game.route(Game.player.pos, crystal, "n/a", New List(Of Point))
    End Sub
    Public Overrides Sub onUnequip()

    End Sub
End Class
