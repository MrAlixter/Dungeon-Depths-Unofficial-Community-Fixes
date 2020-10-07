Public Class ChickenLeg
    Inherits Food
    Sub New()
        '|ID Info|
        MyBase.setName("Chicken_Leg")
        id = 30
        tier = 1

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 150
        setCalories(25)

        '|Description|
        MyBase.setDesc("A roasted and seasoned chicken leg, served steaming hot!" & DDUtils.RNRN &
                       "+25 Stamina")
    End Sub
End Class
