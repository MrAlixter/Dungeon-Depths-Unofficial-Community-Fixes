Public Class PortalChalk
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Portal_Chalk")
        id = 86
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 2

        '|Description|
        MyBase.setDesc("A debugging item that lets one teleport/reset floors.  Use your powers for good, ok?")
    End Sub

    Overrides Sub use(ByRef p As Player)
        Dim f As Integer = CInt(InputBox("Which floor?"))
        Game.quickChangeFloor(f)
        count -= 1
    End Sub
End Class
