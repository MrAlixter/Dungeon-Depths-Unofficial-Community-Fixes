Public Class SpidersilkWhip
    Inherits Whip

    Sub New()
        MyBase.setName("Spidersilk_Whip")
        MyBase.setDesc("A white silk whip that critically hits more often than a standard sword." & vbCrLf & _
                       "+25 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        isMonsterDrop = True
        id = 63
        tier = 3
        MyBase.count = 0
        MyBase.value = 900
    End Sub
End Class
