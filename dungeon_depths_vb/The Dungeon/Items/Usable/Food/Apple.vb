Public Class Apple
    Inherits Food
    'Apple is a food item that reduces stamina by 15
    Sub New()
        MyBase.setName("Apple")
        MyBase.setDesc("An normal red apple. +15 Stamina")
        id = 32
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
        setCalories(15)
    End Sub
End Class
