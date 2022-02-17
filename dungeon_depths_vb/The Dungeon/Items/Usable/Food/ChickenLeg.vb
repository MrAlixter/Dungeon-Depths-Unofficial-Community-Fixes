Public Class ChickenLeg
    Inherits Food

    Public Const ITEM_NAME As String = "Chicken_Leg"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 30
        tier = 1

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 230
        setCalories(25)

        '|Description|
        setDesc("A roasted and seasoned chicken leg, served steaming hot!" & DDUtils.RNRN &
                       "+25 Stamina")
    End Sub
End Class
