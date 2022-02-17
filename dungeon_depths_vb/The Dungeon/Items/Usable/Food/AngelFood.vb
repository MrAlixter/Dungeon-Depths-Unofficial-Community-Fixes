Public Class AngelFood
    Inherits Food

    Public Const ITEM_NAME As String = "Angel_Food_Cake"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 44
        tier = 3

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 375
        setCalories(20)

        '|Description|
        setDesc("An divine sugary confection." & DDUtils.RNRN &
                "+20 Stamina")
    End Sub
    Public Overrides Sub effect(ByRef p As Player)
        p.ongoingTFs.add(New AngelTF())
        p.update()
    End Sub
End Class
