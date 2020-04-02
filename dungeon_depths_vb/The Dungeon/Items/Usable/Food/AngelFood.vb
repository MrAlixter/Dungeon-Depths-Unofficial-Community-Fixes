Public Class AngelFood
    Inherits Food
    'Angel Food is a food item that reduces hunger by 20 and triggers the angel transformation
    Sub New()
        MyBase.setName("Angel_Food_Cake")
        MyBase.setDesc("An divine sugary confection. -20 Hunger")
        id = 44
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 375
        setCalories(20)
    End Sub
    Public Overrides Sub Effect()
        Dim p As Player = Game.player1
        p.ongoingTFs.Add(New AngelTF())
        p.update()
    End Sub
End Class
