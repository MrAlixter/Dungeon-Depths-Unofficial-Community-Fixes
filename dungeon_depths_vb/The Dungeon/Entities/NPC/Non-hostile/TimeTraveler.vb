Public Class TimeTraveler
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Time Traveler"
        sName = name

        '|NPC Flags|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
        isShop = False

        '|Stats|
        maxHealth = 99
        attack = 9999
        defense = 9999
        speed = 99
        will = 99
        gold = 99999
        xp_value = (maxHealth + attack + defense + speed) / 4
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sdefense = defense
        sWill = will
        sSpeed = speed

        '|Inventory|


        '|Images|
        picNormal = ShopNPC.npcLib.atrs(0).getAt(39)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(41)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(40)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(42), ShopNPC.npcLib.atrs(0).getAt(43), ShopNPC.npcLib.atrs(0).getAt(44)})
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        Game.leaveNPC()

        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(43), """Oh, hey, it's you.  Weren't you supposed to be locked up?""" & DDUtils.RNRN &
                                                            "Press any non-movement key to continue.")

        Game.npcmode = False
    End Sub

    Public Overrides Function toFight() As String
        Return "Oh, hey, it's you.  Weren't you supposed to be locked up?"
    End Function
    Public Overrides Function hitBySpell() As String
        Return "Oh, hey, it's you.  Weren't you supposed to be locked up?"
    End Function
End Class
