Public Class Caelia
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Caelia"
        sName = name

        '|NPC Flags|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
        title = ""
        isShop = False

        '|Stats|
        maxHealth = 9999
        attack = 99
        defense = 99
        speed = 999
        gold = 0
        xp_value = (maxHealth + attack + defense + speed) / 4
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sdefense = defense
        sWill = will
        sSpeed = speed

        '|Images|
        local_img = New Dictionary(Of ShopNPC.LocalImgInd, Image)()

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(32))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(33))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(34))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not target.GetType() Is GetType(Player) Then
            MyBase.attackCMD(target)
        Else
            Game.NPCfromCombat(Me)
            Game.leaveNPC()
            TextEvent.push("""Well, someone needs to relax...""")
            Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
            bTF.step2()
            Game.player1.inv.add(147, 1)
            EquipmentDialogBackend.armorChange(Game.player1, "Skimpy_Tube_Top")
            Game.player1.drawPort()
            pos = New Point(-1, -1)
        End If
    End Sub
    Shared Sub teleportPlayer()
        Game.leaveNPC()
        Game.mDun.jumpTo(91017)
        Game.mDun.setFloor(Game.currFloor)
        Game.player1.setPlayerImage()
        Game.drawBoard()
    End Sub
End Class
