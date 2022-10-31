Public Class TimeTraveler
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Time Traveler"
        sName = name
        npc_index = ShopNPCInd.timetraveler

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

        '|Images|
        local_img = New Dictionary(Of ShopNPC.LocalImgInd, Image)()

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(39))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(40))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(41))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(42))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(43))
        local_img.Add(LocalImgInd.alt3, ShopNPC.gbl_img.atrs(0).getAt(44))
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        Game.leaveNPC()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(43), """Oh, hey, it's you.  Weren't you supposed to be locked up?""" & DDUtils.PAKTC)

        Game.shop_npc_engaged = False
    End Sub

    Public Overrides Function toFight() As String
        Return "Oh, hey, it's you.  Weren't you supposed to be locked up?"
    End Function
    Public Overrides Function hitBySpell() As String
        Return "Oh, hey, it's you.  Weren't you supposed to be locked up?"
    End Function
End Class
