Public Class Benediction
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Benediction")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        'Game.pushLstLog("You cast Benediction!")
        Dim p = MyBase.getCaster

        Dim bEffect As BenedictionEffect = New BenedictionEffect

        bEffect.apply(p)

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Removes a number of curses from its caster."
    End Function
End Class
