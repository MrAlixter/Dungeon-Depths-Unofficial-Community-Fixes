Public Class BitGold
    Inherits Item

    Sub New()
        MyBase.setName("BitGold")
        MyBase.setDesc("An untraceable, decenteralized alternative to gold with a value that varries from day to day.")
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0

        Randomize(DateTime.Now.ToString.GetHashCode)
        MyBase.value = Int(Rnd() * 20000)

        MyBase.isRandoTFAcceptable = False
    End Sub
End Class
