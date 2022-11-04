Public Class Shrunken
    Inherits pClass
    Sub New()
        MyBase.New(0.1, 0.1, 0.1, 0.1, 10, 0.5, "Shrunken")
        revertPassage = "You grow back to your original height..."
        transformPassage = "You dwindle in height..."
        canBeTFed = False
    End Sub
End Class
