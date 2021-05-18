Public Class CynnsDisguise
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Cynn's Disguise")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
            getCaster.ongoingTFs.add(New CynnDisguiseTF)
            getCaster.ongoingTFs.ping()

        getCaster.drawPort()

        getCaster.addLust(Math.Max(10, getCaster.getLust * 4))
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 utility spell that diguises its user's demonic form.  This spell does not cost mana, but rather quadruples lust."
    End Function
End Class
