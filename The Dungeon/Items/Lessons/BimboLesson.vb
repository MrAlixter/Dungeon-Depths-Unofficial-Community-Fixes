Public Class AmazonLesson
    Inherits Item

    Sub New()
        MyBase.setName("Bimbo_Lesson")
        MyBase.setDesc("Won't do anything unless bought")
        id = 87
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
        MyBase.onBuy = AddressOf teach
    End Sub

    Sub teach()
        Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
        bTF.step2()
        Game.player.createP()

        CType(Game.hteach, HTeach).hypnotize("Alright, here you go!" & vbCrLf & "[this is a placeholder to test the concept]")
    End Sub
End Class
