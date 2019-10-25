Public Class MShank
    Inherits Dagger

    Sub New()
        MyBase.setName("Mugger's_Shank")
        MyBase.setDesc("A well-worn blade small enough to be concealed and drawn at will." & vbCrLf &
                       "+7 ATK" & vbCrLf &
                       "+5 SPD" & vbCrLf &
                       "Hits twice")
        id = 165
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 7
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 235
    End Sub
End Class
