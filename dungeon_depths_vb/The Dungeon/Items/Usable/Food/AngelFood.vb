Public Class AngelFood
    Inherits Food
    'Angel Food is a food item that reduces stamina by 20 and triggers the angel transformation
    Sub New()
        '|ID Info|
        setName("Angel_Food_Cake")
        id = 44
        tier = 3

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 375
        setCalories(20)

        '|Description|
        setDesc("An divine sugary confection." & DDUtils.RNRN &
                       "+20 Stamina")
    End Sub
    Public Overrides Sub effect(ByRef p As Player)
        p.ongoingTFs.add(New AngelTF())
        p.update()
    End Sub
End Class
