Public Class ChickenLeg
    Inherits Food
    Sub New()
        MyBase.setName("Chicken_Leg")
        MyBase.setDesc("A fried piece of chicken found in a box in a cave. -25 Hunger")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
        setCalories(25)
    End Sub
End Class
