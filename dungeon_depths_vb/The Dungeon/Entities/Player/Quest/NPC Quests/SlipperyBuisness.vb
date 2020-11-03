Public Class SlipperyBuisness
    Inherits Quest

    Sub New()
        MyBase.New("Slippery Business")

        objectives.Add(New GetVial)
        objectives.Add(New AquireOoze)
    End Sub
End Class

Public Class GetVial
    Inherits Objective

    Sub New()
        MyBase.New("Aquire a vial capable of holding slime.")
    End Sub
End Class

Public Class AquireOoze
    Inherits Objective

    Sub New()
        MyBase.New("Use the vial to collect an Ooze Princess.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        'Transform H-Teach to slime variant
    End Sub
End Class
