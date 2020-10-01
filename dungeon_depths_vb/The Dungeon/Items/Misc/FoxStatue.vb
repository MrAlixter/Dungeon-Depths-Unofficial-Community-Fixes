Public Class FoxStatue
    Inherits Item

    Sub New()
        MyBase.setName("Fox_Statue")
        MyBase.setDesc("A life-like statue of a fox that contains the sealed essense of Seven-Tails.")
        id = 224
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False
        MyBase.count = 0
        MyBase.value = 0

        MyBase.isRandoTFAcceptable = False
    End Sub
End Class
