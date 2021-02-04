Public Class ArmorFragments
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Armor_Fragments")
        id = 264
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 10

        '|Description|
        MyBase.setDesc("A shattered chunk of an indeterminate set of armor that seems to be made of a wide selection of different metals.  If one has a high-end furnace it might possible to smelt into something usefull, but otherwise it's basically worthless.")
    End Sub

    Public Overrides Function getTier() As Integer
        'If Game.player1.quests(qInds.dfaUpgrade).getActive Then Return 1

        Return MyBase.getTier()
    End Function
End Class
