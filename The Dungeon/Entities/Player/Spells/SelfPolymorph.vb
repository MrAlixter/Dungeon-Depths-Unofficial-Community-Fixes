Public Class SelfPolymorph
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Self Polymorph")
        MyBase.settier(4)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        Polymorph.porm = True
        Dim p As Polymorph = New Polymorph
        p.ShowDialog()
        p.Dispose()
        Game.lstLog.Items.Add(CStr("You turn yourself into a " & Game.player.title & "!"))
        Game.pushLblCombatEvent(CStr("You turn yourself into a " & Game.player.title & "!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Overrides Sub backfire()
        Dim n As String
        Select Case Int(Rnd() * 3)
            Case 0
                n = "Slime​"
            Case 1
                n = "Succubus​"
            Case Else
                n = "Dragon​"
        End Select
        Polymorph.transform(MyBase.getTarget, n)
        Game.lstLog.Items.Add(CStr("You turn your opponent into a " & n & "!"))
        Game.pushLblCombatEvent(CStr("You turn your opponent into a " & n & "!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
