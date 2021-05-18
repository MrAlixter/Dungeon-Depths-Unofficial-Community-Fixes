Public Class SpidersilkWhip
    Inherits Whip

    Sub New()
        setName("Spidersilk_Whip")
        setDesc("A white silk whip that critically hits more often than a standard sword." & vbCrLf & _
                       "+25 ATK")
        usable = false
        MyBase.a_boost = 25
        droppable = True
        id = 63
        tier = 3
        count = 0
        value = 900
    End Sub
End Class
