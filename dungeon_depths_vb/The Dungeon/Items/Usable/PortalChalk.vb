Public Class PortalChalk
    Inherits Item

    Sub New()
        MyBase.setName("Portal_Chalk")
        MyBase.setDesc("A debugging item that lets one teleport/reset floors.  Use your powers for good, ok?")
        id = 86
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 2

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub use()
        Try
            Dim f As Integer = CInt(InputBox("Which floor?"))
            Game.floor = f - 1
            Game.pushLblEvent("You draw a circle on the floor, and think hard about floor " & f & ".  A portal opens to it, and you jump through, skipping every floor in between.", AddressOf Game.initializeBoard)
        Catch e As Exception
            Game.pushLblEvent("Your attempted teleportation fails in a less than spectacular fashion, the portal you created simply fizzling away to nothingness.")
        End Try

        count -= 1
    End Sub
End Class
