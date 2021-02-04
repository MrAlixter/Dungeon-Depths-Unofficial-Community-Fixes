Public Class EnemyPolymorph
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Polymorph Enemy")
        MyBase.settier(4)
        MyBase.setcost(12)
    End Sub
    Public Overrides Sub effect()
        Polymorph.porm = False
        Dim p As Polymorph = New Polymorph
        p.target = MyBase.getTarget
        p.ShowDialog()
        p.Dispose()
        If MyBase.getTarget.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            MyBase.getTarget.update()
        End If

        Game.pushLogAndEvent(CStr("You transform" & MyBase.getTarget.title & " " & MyBase.getTarget.name & "!"))
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

        MyBase.getCaster.perks(perk.polymorphed) = 1

        Game.pushLogAndEvent(CStr("You turn yourself into a " & n & "!"))
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 4 spell that transforms its target into a form of the caster's choice with a medium chance of backfiring and a low chance of missing altogether."
    End Function
End Class
