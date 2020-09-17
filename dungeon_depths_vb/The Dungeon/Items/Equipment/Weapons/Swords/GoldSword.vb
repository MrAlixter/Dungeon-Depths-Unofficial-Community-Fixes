Public Class GoldSword
    Inherits Sword

    Sub New()
        MyBase.setName("Gold_Sword")
        MyBase.setDesc("A shiny sword forged from a gold alloy." & vbcrlf & 
		               "+35 ATK")
        id = 40
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 35
        MyBase.count = 0
        MyBase.value = 3200
    End Sub
End Class
