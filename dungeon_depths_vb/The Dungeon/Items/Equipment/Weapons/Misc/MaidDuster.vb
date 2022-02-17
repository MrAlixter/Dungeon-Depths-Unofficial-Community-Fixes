Public Class MaidDuster
    Inherits Weapon

    Public Const ITEM_NAME As String = "Duster"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 45
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        a_boost = 5
        count = 0
        value = 375

        '|Description|
        setDesc("A grey feather duster that looks like you could use for cleaning.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        p.ongoingTFs.Add(New MaidTF())
        p.update()
    End Sub
End Class
