Public Class EnemyPolymorph
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Polymorph Enemy")
        MyBase.settier(4)
        MyBase.setcost(12)
    End Sub
    Public Overrides Sub effect()
        Game.toPNLSelec("EnemyTF")
    End Sub
    Public Shared Sub effectP2(ByVal fN As String, ByVal cN As String)
        Dim t = Game.player1.currTarget

        If t.GetType.IsSubclassOf(GetType(ShopNPC)) Then
            t.update()
        End If
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

        TextEvent.pushAndLog(CStr("You turn yourself into a " & n & "!"))
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 4 spell that transforms its target into a form of the caster's choice with a medium chance of backfiring and a low chance of missing altogether."
    End Function
End Class
