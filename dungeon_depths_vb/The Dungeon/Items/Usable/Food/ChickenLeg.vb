Public Class ChickenLeg
    Inherits Food
    Sub New()
        MyBase.setName("Chicken_Leg")
        MyBase.setDesc("A roasted and seasoned, steaming hot chicken leg." & vbCrLf &
                       "-25 Hunger")
        id = 30
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
        setCalories(25)
    End Sub
End Class
