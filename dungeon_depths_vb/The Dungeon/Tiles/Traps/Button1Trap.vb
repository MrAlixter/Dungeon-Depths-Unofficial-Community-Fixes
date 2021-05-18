Public Class Button1Trap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.button1
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Game.pushLblEvent("You press a big glowing red button, and the nearby console alerts you that ""Security gates for the Cross-Station Interchange, Contraband Locker, Staff Quarters, and Warp Chamber have been deactivated""", AddressOf postcheck)
        'Warp Area
        Game.currFloor.mBoard(5, 43).Tag = 2
        Game.currFloor.mBoard(5, 43).Text = ""
        Game.currFloor.mBoard(5, 49).Tag = 2
        Game.currFloor.mBoard(5, 49).Text = ""
        'Contraband Locker
        Game.currFloor.mBoard(10, 26).Tag = 2
        Game.currFloor.mBoard(10, 26).Text = ""
        'Staff Area
        Game.currFloor.mBoard(17, 17).Tag = 2
        Game.currFloor.mBoard(17, 17).Text = ""
        'Interchange
        Game.currFloor.mBoard(22, 72).Tag = 2
        Game.currFloor.mBoard(22, 72).Text = ""
        Game.currFloor.mBoard(23, 72).Tag = 2
        Game.currFloor.mBoard(23, 72).Text = ""
        Game.currFloor.mBoard(24, 72).Tag = 2
        Game.currFloor.mBoard(24, 72).Text = ""
        Game.currFloor.mBoard(25, 72).Tag = 2
        Game.currFloor.mBoard(25, 72).Text = ""
    End Sub

    Sub postcheck()
        If Not Game.player1.quests(qInds.outOfTime).getComplete Or Game.currFloor.mBoard(5, 72).Text = "" Then
            OutOfTimeS3.alert(False)
        End If
    End Sub
End Class
