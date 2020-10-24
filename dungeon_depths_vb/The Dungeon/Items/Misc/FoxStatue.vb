Public Class FoxStatue
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Fox_Statue")
        id = 224
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 0

        '|Description|
        MyBase.setDesc("A life-like statue of a fox that contains the sealed essense of Seven-Tails.")
    End Sub
End Class
