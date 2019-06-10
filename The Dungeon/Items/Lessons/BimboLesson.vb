Public Class BimboLesson
    Inherits Item

    Sub New()
        MyBase.setName("Bimbo_Lesson")
        MyBase.setDesc("""So, you like bimbos, do you?  What if I told you that I could make you a bimbo in not occupation, but in mind, body, and soul?  If you are willing to give up, well, all of your mental capacity to live a more glamorous, simpler life, I have just the lesson for you...""")
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
        Game.player.be()

        Game.player.createP()

        CType(Game.hteach, HTeach).hypnotize("Alright, here you go!" & vbCrLf & "[this is a placeholder to test the concept]")
    End Sub
End Class
