Public Class ArmorFragments
    Inherits Item

    Public Const ITEM_NAME As String = "Armor_Fragments"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 264
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 10

        '|Description|
        setDesc("A shattered chunk of an indeterminate set of armor that seems to be made of a wide selection of different metals.  If one has a high-end furnace it might possible to smelt into something usefull, but otherwise it's basically worthless.")
    End Sub

    Public Overrides Function getTier() As Integer
        'If Game.player1.quests(qInd.dfaUpgrade).getActive Then Return 1

        Return MyBase.getTier()
    End Function
End Class
