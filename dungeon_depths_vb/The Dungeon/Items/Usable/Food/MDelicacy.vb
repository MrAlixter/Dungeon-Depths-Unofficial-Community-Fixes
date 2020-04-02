Public Class MDelicacy
    Inherits Food
    Sub New()
        MyBase.setName("Mage's_Delicacy")
        MyBase.setDesc("Three pieces of baked haddock served with wild rice and a selection of grilled vegetables.  Some of the spices glow with a dim azure light." & vbCrLf &
                       "-90 Hunger" & vbCrLf &
                       "Low chance to raise Max Mana and WIL by 3 points each")

        id = 134
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 2100
        setCalories(90)
    End Sub

    Public Overrides Sub Effect()
        If Int(Rnd() * 5) = 0 Or Game.noRNG Then
            Game.player1.maxMana += 3
            Game.player1.mana += 3

            Game.player1.will += 3

            Game.player1.UIupdate()
        End If
    End Sub
End Class
