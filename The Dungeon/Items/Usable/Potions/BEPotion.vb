Public Class BEPotion
    Inherits Item

    Sub New()
        MyBase.setName("BE_Potion")
        MyBase.setDesc("Turns out that removing the specific effects of mystery potions makes it a pain to test new clothing options." &
                       "  This is for that, if I add brewing this description will change.  If you're reading this, have a nice day and" &
                       " thanks for playing!" & vbCrLf & vbCrLf & "  - VHU")
        id = 80
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 0
    End Sub

    Overrides Sub use()
        Game.pushLstLog("You drink the " & getName())
        Dim beffect As BEEffect = New BEEffect
        beffect.apply(Game.player)
        Game.pushLblEvent("You drink the " & getName() & ".  +1 bust size!")
        count -= 1
    End Sub
End Class
