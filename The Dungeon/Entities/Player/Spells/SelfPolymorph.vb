Public Class SelfPolymorph
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Self Polymorph")
        MyBase.setUOC(True)
        MyBase.settier(4)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        Polymorph.porm = True
        Dim p As Polymorph = New Polymorph
        Dim fN = Game.player.pForm.name
        Dim cN = Game.player.pClass.name
        p.ShowDialog()
        p.Dispose()

        Dim delta As String
        If Game.player.pForm.name.Equals(fN) Then
            delta = Game.player.pClass.name
        Else
            delta = Game.player.pForm.name
        End If
        Game.pushLstLog(CStr("You turn yourself into a " & delta & "!"))
        Game.pushLblCombatEvent(CStr("You turn yourself into a " & delta & "!"))
        
    End Sub
    Public Overrides Sub backfire()
        If MyBase.getTarget Is Nothing Then
            Game.pushLblEvent("You have no target for this to backfire on!")
            Exit Sub
        End If
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
        Game.pushLstLog(CStr("You turn your opponent into a " & n & "!"))
        Game.pushLblCombatEvent(CStr("You turn your opponent into a " & n & "!"))
        
    End Sub
End Class
