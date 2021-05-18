Public Class Apple
    Inherits Food
    'Apple is a food item that reduces stamina by 15
    Sub New()
        setName("Apple")
        setDesc("An normal red apple. +15 Stamina")
        id = 32
        tier = 1
        usable = true
        count = 0
        value = 150
        setCalories(15)
    End Sub
End Class
