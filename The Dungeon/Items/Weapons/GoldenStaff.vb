Public Class GoldenStaff
    Inherits Staff

    Sub New()
        MyBase.setName("Golden_Staff")
        MyBase.setDesc("A glowing runed staff for powerful spellcasters. +50 MANA")
        id = 41
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 50
        MyBase.aBoost = 10
        count = 0
        value = 3200
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
