Public Class ScourgeFirstSea
    Inherits TentacleCrushcannon
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("First Sea's Scourge")
        MyBase.settier(2)
        MyBase.setcost(9)
    End Sub
End Class
