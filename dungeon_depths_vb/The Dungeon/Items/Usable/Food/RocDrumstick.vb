Public Class RocDrumstick
    Inherits Food

    Public Const ITEM_NAME As String = "Roc_Drumstick"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 267
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 340
        setCalories(40)

        '|Description|
        setDesc("A massive roasted bird leg, served steaming hot!" & DDUtils.RNRN &
                "+40 Stamina")
    End Sub

    Public Overrides Function getTier() As Integer
        If Not Game.currFloor Is Nothing AndAlso Game.currFloor.floorNumber > 5 Then Return 2

        Return Nothing
    End Function
End Class
