Public Class GrapplingHook
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Grappling_Hook")
        id = 148
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("A debugging item that lets one teleport/reset floors.  Use your powers for good, ok?")

    End Sub

    Overrides Sub use(ByRef p As Player)
        Try
            If Not p.pos.Equals(Game.currFloor.stairs) Or Game.currFloor.floorNumber = 1 Then Throw New Exception
            Game.mDun.floorUp()
            Game.mDun.setFloor(Game.currFloor)
            Game.pushLblEvent("You toss the grappling hook up into the stairwell, keeping tension until you here a satisfying *thunk*.  After a quick test of the line, you climb up to the floor above.", AddressOf Game.initializeBoard)
        Catch e As Exception
            Game.pushLblEvent("You toss the grappling hook up, and it bounces off the roof.  If only you were below an opening to another floor...")
        End Try
    End Sub
End Class
