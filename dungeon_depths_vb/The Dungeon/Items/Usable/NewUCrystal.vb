Public Class NewUCrystal
    Inherits Item

    Public Const ITEM_NAME As String = "New-U_Crystal"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 154
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2

        '|Description|
        setDesc("A debugging item that lets one do the random transformation.  Use your powers for good, ok?")
    End Sub

    Overrides Sub use(ByRef p As Player)
        p.ongoingTFs.Add(New RandoTF())
        p.update()

        p.inv.add(154, 1)
        count -= 1
    End Sub
End Class
