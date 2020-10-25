Public Class BitGold
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("BitGold")
        MyBase.id = 229
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        Randomize(DateTime.Now.ToString.GetHashCode)
        MyBase.value = Int(Rnd() * 20000)

        '|Description|
        MyBase.setDesc("An untraceable, decenteralized alternative to gold with a value that varries from day to day.")
    End Sub
End Class
