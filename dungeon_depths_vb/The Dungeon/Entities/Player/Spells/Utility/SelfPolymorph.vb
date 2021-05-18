Public Class SelfPolymorph
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Self Polymorph")
        MyBase.setUOC(True)
        MyBase.settier(4)
        MyBase.setcost(12)
    End Sub
    Public Overrides Sub effect()
        Game.toPNLSelec("SelfTF")
    End Sub

    Public Shared Sub effectP2(ByVal fN As String, ByVal cN As String)
        Dim delta As String

        If Game.player1.formName.Equals(fN) Then
            delta = Game.player1.className
        ElseIf Game.player1.className.Equals(fN) Then
            delta = Game.player1.formName
        Else
            Game.player1.mana += 12
            Exit Sub
        End If

        Game.pushLogAndEvent(CStr("You turn yourself into a " & delta & "!"))
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

        Game.pushLogAndEvent(CStr("You turn your opponent into a " & n & "!"))
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 4 spell that transforms its caster into a form of their choice with a medium chance of backfiring and a low chance of missing altogether."
    End Function
End Class
