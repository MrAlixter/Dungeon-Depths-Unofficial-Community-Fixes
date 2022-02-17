Public Class VialOfRockJuice
    Inherits Item

    Public Const ITEM_NAME As String = "Vial_of_Rock_Juice"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 294
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        droppable = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("Tastes like eternal petrification...")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        p.petrify(Color.LightGray, 999)
    End Sub
End Class
