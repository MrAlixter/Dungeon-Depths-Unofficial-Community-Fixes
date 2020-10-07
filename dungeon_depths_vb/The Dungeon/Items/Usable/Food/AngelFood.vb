Public Class AngelFood
    Inherits Food
    'Angel Food is a food item that reduces stamina by 20 and triggers the angel transformation
    Sub New()
        '|ID Info|
        MyBase.setName("Angel_Food_Cake")
        id = 44
        tier = 3

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 375
        setCalories(20)

        '|Description|
        MyBase.setDesc("An divine sugary confection." & DDUtils.RNRN &
                       "+20 Stamina")
    End Sub
    Public Overrides Sub Effect()
        Dim p As Player = Game.player1
        p.ongoingTFs.Add(New AngelTF())
        p.update()
    End Sub
End Class
