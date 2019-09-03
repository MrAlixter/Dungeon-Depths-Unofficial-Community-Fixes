Public Class GrapplingHook
    Inherits Item

    Sub New()
        MyBase.setName("Grappling_Hook")
        MyBase.setDesc("A debugging item that lets one teleport/reset floors.  Use your powers for good, ok?")
        id = 148
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 0

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub use()
        Try
            If Not Game.player.pos.Equals(Game.currFloor.stairs) Or Game.currFloor.floorNumber = 1 Then Throw New Exception
            Game.mDun.floorUp()
            Game.pushLblEvent("You toss the grappling hook up into the stairwell, keeping tension until you here a satisfying *thunk*.  After a quick test of the line, you climb up to the floor above.", AddressOf Game.initializeBoard)
        Catch e As Exception
            Game.pushLblEvent("You toss the grappling hook up, and it bounces off the roof.  If only you were below an opening to another floor...")
        End Try
    End Sub
End Class
