Public Class Cupcake
    Inherits Food
    Sub New()
        MyBase.setName("Cupcake")
        MyBase.setDesc("A 100% not magic totally not cursed cupcake. -50 Hunger")
        id = 35
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 250
        setCalories(50)
    End Sub
End Class
