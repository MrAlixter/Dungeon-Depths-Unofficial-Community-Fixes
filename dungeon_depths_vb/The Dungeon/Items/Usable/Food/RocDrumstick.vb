Public Class RocDrumstick
    Inherits Food
    Sub New()
        '|ID Info|
        MyBase.setName("Roc_Drumstick")
        id = 267
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 340
        setCalories(40)

        '|Description|
        MyBase.setDesc("A massive roasted bird leg, served steaming hot!" & DDUtils.RNRN &
                       "+40 Stamina")
    End Sub

    Public Overrides Function getTier() As Integer
        If Not Game.currFloor Is Nothing AndAlso Game.currFloor.floorNumber > 5 Then Return 2

        Return Nothing
    End Function
End Class
