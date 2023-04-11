Public Class ArcaneCompass
    Inherits Spell

    Dim targets As Dictionary(Of String, Point)

    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Arcane Compass")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(5)
    End Sub

    Public Overrides Sub effect()
        If Game.combat_engaged Or Game.shop_npc_engaged Then
            TextEvent.pushAndLog("The spell fizzles into nothing...")
            Exit Sub
        End If

        TextEvent.fpush("Your magic forms a network of vines that dart out around you..." & DDUtils.RNRN & "...")

        targets = getTargets(Game.currFloor)

        If Game.currFloor.floorNumber = 13 Or targets.Count < 1 Then
            TextEvent.pushAndLog("Your magic forms a network of vines that dart out around you..." & DDUtils.RNRN &
                                 "...but they don't find anything.")
            Exit Sub
        End If

        Game.currFloor.cleanPaths()

        TextEvent.push("Your magic forms a network of vines that dart out around you..." & DDUtils.RNRN &
                       targets.Count & " locations found!", AddressOf askWhichTarget)
        TextEvent.pushLog("Your magic forms a network of vines that dart out around you... " & targets.Count & " locations found!")
    End Sub

    Private Sub askWhichTarget()
        Dim t_options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        For Each t In targets
            t_options.Add(New Tuple(Of String, Action)(t.Key, Sub() routeToTarget(t.Value)))
        Next

        TextEvent.pushManySelect("Route to which location?", t_options)
    End Sub

    Private Sub routeToTarget(ByRef pt As Point)
        Dim p = Game.currFloor.route(getCaster.pos, pt)

        For i = 0 To UBound(p) Step 3
            Game.currFloor.mBoard(p(i).Y, p(i).X).Tag = 2
            If Game.currFloor.mBoard(p(i).Y, p(i).X).Text = "" Then Game.currFloor.mBoard(p(i).Y, p(i).X).Text = "x"
        Next
        Game.currFloor.mBoard(p(UBound(p)).Y, p(UBound(p)).X).Tag = 2

        Game.drawBoard()
    End Sub

    Private Function getTargets(ByRef floor As mFloor) As Dictionary(Of String, Point)
        Dim results As Dictionary(Of String, Point) = New Dictionary(Of String, Point)()

        If floor.route(getCaster.pos, floor.stairs).Length > 0 Then results.Add("Stairs", floor.stairs)

        For Each s_npc In Game.shop_npc_list
            Try
                If s_npc.pos.X > 0 AndAlso floor.route(getCaster.pos, s_npc.pos).Length > 0 Then results.Add(s_npc.getName, s_npc.pos)
            Catch ex As Exception
                Console.WriteLine("Error routing path to " & If(s_npc Is Nothing, "UNKNOWN", s_npc.getName))
            End Try
        Next

        Return results
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that sends scouring vines across the dungeon.  It identifies points of intrest, and creates a glowing path to any one of them."
    End Function
End Class
