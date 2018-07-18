Public Class EnemyPolymorph
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Polymorph Enemy")
        MyBase.settier(4)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        Polymorph.porm = False
        Dim p As Polymorph = New Polymorph
        p.target = MyBase.getTarget
        p.ShowDialog()
        p.Dispose()
        If MyBase.getTarget.GetType() Is GetType(NPC) Then
            MyBase.getTarget.update()
        End If
        Game.lstLog.Items.Add(CStr("You transform" & MyBase.getTarget.title & " " & MyBase.getTarget.name & "!"))
        Game.pushLblCombatEvent(CStr("You transform" & MyBase.getTarget.title & " " & MyBase.getTarget.name & "!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Overrides Sub backfire()
        Dim n As String
        Select Case Int(Rnd() * 3)
            Case 0
                n = "Princess​"
            Case 1
                n = "Bunny Girl​"
            Case Else
                n = "Sheep"
        End Select
        Polymorph.transform(MyBase.getCaster, n)
        MyBase.getCaster.perks("polymorphed") = 1
        Game.lstLog.Items.Add(CStr("You turn yourself into a " & n & "!"))
        Game.pushLblCombatEvent(CStr("You turn yourself into a " & n & "!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
