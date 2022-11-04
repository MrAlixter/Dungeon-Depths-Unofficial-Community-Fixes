Public Class CynnOnahole
    Inherits pClass
    Sub New()
        MyBase.New(0.05, 0.05, 0.05, 0.05, 0.05, 0.05, "Cynn Onahole")
        canBeTFed = False
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()

        CynnTonicTF.blowupCynnTFAlt()
    End Sub
End Class
