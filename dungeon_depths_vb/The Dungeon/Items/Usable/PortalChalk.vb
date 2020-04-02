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

    Overrides Sub use(ByRef p As Player)
        Dim f As Integer = CInt(InputBox("Which floor?"))
        Game.quickChangeFloor(f)
        count -= 1
    End Sub
End Class
