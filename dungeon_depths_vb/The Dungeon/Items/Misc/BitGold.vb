Public Class BitGold
    Inherits Item

    Sub New()
        '|ID Info|
        setName("BitGold")
        MyBase.id = 229
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        count = 0
        Randomize(DateTime.Now.ToString.GetHashCode)
        value = Int(Rnd() * 20000)

        '|Description|
        setDesc("An untraceable, decenteralized alternative to gold with a value that varries from day to day.")
    End Sub
End Class
