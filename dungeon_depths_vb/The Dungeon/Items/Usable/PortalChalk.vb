Public Class PortalChalk
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Portal_Chalk")
        id = 86
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2

        '|Description|
        setDesc("A debugging item that allows one to teleport between floors.  Use your powers for good, ok?")
    End Sub

    Overrides Sub use(ByRef p As Player)
        Dim f As Integer = CInt(InputBox("Which floor?"))
        Game.quickChangeFloor(f)
        count -= 1
    End Sub
End Class
