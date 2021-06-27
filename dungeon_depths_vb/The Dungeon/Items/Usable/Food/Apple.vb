Public Class Apple
    Inherits Food
    'Apple is a food item that reduces stamina by 15
    Sub New()
        '|ID Info|
        setName("Apple")
        id = 32
        tier = 1

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 150
        setCalories(15)

        '|Description|
        setDesc("An normal red apple." & DDUtils.RNRN &
                "+15 Stamina")
    End Sub
End Class
