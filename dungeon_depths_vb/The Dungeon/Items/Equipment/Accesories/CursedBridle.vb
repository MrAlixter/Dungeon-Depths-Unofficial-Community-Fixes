Public Class CursedBridle
    Inherits Accessory

    Public Const ITEM_NAME As String = "Cursed_Bridle"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 344
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        hide_mouth = True
        gag = True

        '|Stats|
        h_boost = 25
        s_boost = 25
        w_boost = -25
        count = 0
        value = 335

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(33, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(22, False, True)

        '|Description|
        setDesc("An elaborate set of leather straps and steel hardware used to direct farm animals.  While it seems to have been fitted for a horse, nothing would stop you from putting it on yourself if you wanted to..." & DDUtils.RNRN &
                "Can be unequipped by using this item." & DDUtils.RNRN &
                "Requires 35 mana to unequip." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getUsable() As Boolean
        Return Not owner Is Nothing
    End Function
    Public Overrides Sub use(ByRef p As Player)
        If p.equippedAcce.getAName = ITEM_NAME And p.mana >= 35 Then
            onUnequip(p)
            Equipment.equipAcce(p, "Nothing", False)
            p.update()
        ElseIf p.mana < 35 Then
            TextEvent.pushAndLog("You don't have enough mana to remove the bridle...")
        End If
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        If Game.currFloor.floorNumber = 13 Then
            p.mana -= 35

            Game.progressTurn()

            If Game.player1.ongoingQuests.contains("Fae Woods Q2A - Simple Instructions") Then
                Game.player1.ongoingQuests.getAt("Fae Woods Q2A - Simple Instructions").completeEntireQuest()

                TextEvent.push("You focus and are able to break through the enchanted gag!  -35 Mana..." & DDUtils.RNRN &
                               """Hey, what?  Where are you going?  You're not gonna get a cut of the fare!"" exclaims the fae.")
                TextEvent.pushLog("You focus and are able to break through the enchanted gag!  -35 Mana...")
            Else
                TextEvent.pushAndLog("You focus and are able to break through the enchanted gag!  -35 Mana...")
            End If
        End If

        revertTF(p)
    End Sub
    Public Shared Sub revertTF(ByRef p As Player)
        p.revertToPState()
        EquipmentDialogBackend.accessoryChange(p, "Nothing", False)
        p.inv.add(CursedBridle.ITEM_NAME, -1)
        p.resetPerks()
    End Sub


    Public Shared Sub forceUnequip(ByRef p As Player)
        revertTF(p)

        If Game.player1.ongoingQuests.contains("Fae Woods Q2A - Simple Instructions") Then Game.player1.ongoingQuests.getAt("Fae Woods Q2A - Simple Instructions").completeEntireQuest()

        If Game.mDun.lastVisitedFloor = 13 Then
            TextEvent.push("The bridle turns to ash and falls away..." & DDUtils.RNRN &
                           """Hey, what?  Where are you going?  You're not gonna get a cut of the fare!"" exclaims the fae as the woods fade away behind you.")
            TextEvent.pushLog("The bridle turns to ash and falls away...")
        Else
            TextEvent.pushAndLog("The bridle turns to ash and falls away...")
        End If
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        Dim out = "The bridle begins glowing with a malevolent green light..."

        If p.className.Contains("Bimbo") Then
            TextEvent.push(out, AddressOf unicornTF)
        Else
            TextEvent.push(out, AddressOf horseTF)
        End If

        TextEvent.pushAndLog(out)

        Game.lstInventory.SelectedIndex = -1
    End Sub

    Public Sub unicornTF()
        Polymorph.transform(owner, "Unicorn")
    End Sub
    Public Sub horseTF()
        Polymorph.transform(owner, "Horse")
    End Sub

    Public Overrides Function getCursed(ByRef p As Player) As Boolean
        If p.getMana < 35 And Game.currFloor.floorNumber = 13 Then Return True Else Return False
    End Function
End Class
