Public Class PApple
    Inherits Food

    Sub New()
        MyBase.setName("Ap̵ple")
        MyBase.setDesc("An normal green apple. -15 Hunger")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
        setCalories(15)
    End Sub

    Public Overrides Sub Effect()
        Dim p As Player = Form1.player
        If Not p.perks(5) And Not p.title.Equals("Magic Girl") Then
            Form4.transform(p, "princess", 0)
        End If
    End Sub
    Shared Sub princessTF()
        Dim p As Player = Form1.player
        Form4.transform(p, "princess", 1)
    End Sub
End Class
