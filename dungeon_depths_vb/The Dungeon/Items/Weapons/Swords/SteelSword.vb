Public Class SteelSword
    Inherits Sword

    Sub New()
        MyBase.setName("Steel_Sword")
        MyBase.setDesc("A simple sword forged from steel." & vbcrlf & 
		               "+17 ATK")
        id = 6
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 17
        MyBase.count = 0
        MyBase.value = 235
    End Sub
End Class
