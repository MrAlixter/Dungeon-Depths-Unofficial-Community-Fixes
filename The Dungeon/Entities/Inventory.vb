Public Class Inventory
    Dim internal_inventory As New Dictionary(Of String, Item)
    Dim armor() As Armor
    Dim weapons() As Weapon
    Dim acce() As Accessory
    Dim useable(), food(), potions(), misc() As Item
    Dim mPotions As List(Of MysteryPotion)
    Public invNeedsUDate As Boolean = False
    Public invIDorder As List(Of Integer)
    Dim sum As Integer = 0

    '|CONSTUCTOR|
    Sub New(Optional ByVal shufflePotions As Boolean = False)
        '0.1 - 0.4
        internal_inventory.Add("Compass", New Compass())                    '0
        internal_inventory.Add("Stick_of_Gum", New StickOfGum())            '1
        internal_inventory.Add("Health_Potion", New HealthPotion())         '2
        internal_inventory.Add("Vial_of_Slime", New VialOfSlime())          '3
        internal_inventory.Add("Spellbook", New Spellbook())                '4
        internal_inventory.Add("Steel_Armor", New SteelArmor())             '5
        internal_inventory.Add("Steel_Sword", New SteelSword())             '6
        internal_inventory.Add("Steel_Bikini", New SteelBikini())           '7
        internal_inventory.Add("Chicken_Suit", New ChickenSuit())           '8
        internal_inventory.Add("SoulBlade", New SoulBlade())                '9
        internal_inventory.Add("Magic_Girl_Outfit", New MagGirlOutfit())    '10
        internal_inventory.Add("Magic_Girl_Wand", New MagGirlWand())        '11
        internal_inventory.Add("Cat_Lingerie", New CatLingerie())           '12
        internal_inventory.Add("Mana_Potion", New ManaPotion())             '13
        internal_inventory.Add("Restore_Potion", New RestorationPotion())   '14
        internal_inventory.Add("Cat_Ears", New CatEars())                   '15
        internal_inventory.Add("Bunny_Suit", New BunnySuit())               '16
        internal_inventory.Add("Sorcerer's_Robes", New SorcerersRobes())    '17
        internal_inventory.Add("Witch_Cosplay", New WitchCosplay())         '18
        internal_inventory.Add("Warrior's_Cuirass", New WarriorsCuirass())  '19
        internal_inventory.Add("Brawler_Cosplay", New BrawlerCosplay())     '20
        internal_inventory.Add("Oak_Staff", New OakStaff())                 '21
        internal_inventory.Add("Wizard_Staff", New WizardStaff())           '22
        internal_inventory.Add("Bronze_Xiphos", New BronzeXiphos())         '23
        internal_inventory.Add("Sword_of_the_Brutal", New TargaxSword())    '24
        internal_inventory.Add("Breast_Growth_Potion", New BEPotion())      '25
        internal_inventory.Add("Hazardous_Potion", New HazardousPotion())   '26
        internal_inventory.Add("Gentle_Potion", New GentlePotion())         '27
        internal_inventory.Add("Sex_Swap_Potion", New GSPotion())           '28
        internal_inventory.Add("Feminine_Potion", New FemininePotion())     '29
        internal_inventory.Add("Chicken_Leg", New ChickenLeg())             '30
        internal_inventory.Add("Apple​", New PApple())                       '31
        internal_inventory.Add("Apple", New Apple())                        '32
        internal_inventory.Add("Medicinal_Tea", New Herbs())                '33
        internal_inventory.Add("Heavy_Cream", New HeavyCream())             '34
        internal_inventory.Add("Cupcake", New Cupcake())                    '35
        internal_inventory.Add("Mirror", New Mirror())                      '36
        internal_inventory.Add("Glowstick", New Glowstick())                '37
        internal_inventory.Add("Gold_Armor", New GoldArmor())               '38
        internal_inventory.Add("Gold_Adornment", New GoldAdornment())       '39
        internal_inventory.Add("Gold_Sword", New GoldSword())               '40
        internal_inventory.Add("Golden_Staff", New GoldenStaff())           '41
        internal_inventory.Add("Midas_Gauntlet", New MidasGuantlet())       '42
        internal_inventory.Add("Gold", New Gold())                          '43
        internal_inventory.Add("Angel_Food_Cake", New AngelFood())          '44
        internal_inventory.Add("Duster", New MaidDuster())                  '45
        internal_inventory.Add("Tanktop", New TankTop())                    '46
        internal_inventory.Add("Sports_Bra", New SportBra())                '47
        internal_inventory.Add("Health_Charm", New HealthCharm())           '48
        internal_inventory.Add("Mana_Charm", New ManaCharm())               '49
        internal_inventory.Add("Attack_Charm", New AttackCharm())           '50
        internal_inventory.Add("Defence_Charm", New DefenceCharm())         '51
        internal_inventory.Add("Speed_Charm", New SpeedCharm())             '52
        internal_inventory.Add("Key", New Key())                            '53
        internal_inventory.Add("Ropes", New Ropes())                        '54
        internal_inventory.Add("Living_Armor", New LiveArmor())             '55
        internal_inventory.Add("Living_Lingerie", New LiveLingerie())       '56
        internal_inventory.Add("Disarment_Kit", New RigWrench())            '57
        internal_inventory.Add("Fusion_Crystal", New FusionCrystal())       '58
        internal_inventory.Add("Mysterious_Potion", New MysPotion())        '59
        internal_inventory.Add("Breast_Shrink._Potion", New BSPotion())     '60
        internal_inventory.Add("Masculine_Potion", New MasculinePotion())   '61
        internal_inventory.Add("Ditzy_Potion", New DitzyPotion())           '62
        internal_inventory.Add("Spidersilk_Whip", New SpidersilkWhip())     '63
        internal_inventory.Add("Chitin_Armor", New ChitArmor())             '64
        '0.5
        internal_inventory.Add("Advanced_Spellbook", New ASpellbook())      '65
        '0.6
        internal_inventory.Add("Heart_Necklace", New HeartNecklace())       '66
        internal_inventory.Add("Red_Headband", New RedHeadband())           '67
        internal_inventory.Add("Ruby_Circlet", New RubyCirclet())           '68
        internal_inventory.Add("Slave_Collar", New ThrallCollar())          '69
        internal_inventory.Add("Cowbell", New Cowbell())                    '70
        internal_inventory.Add("Cow_Print_Bra", New CowBra())               '71
        '0.7
        internal_inventory.Add("Maid_Outfit", New MaidOutfit())             '72
        internal_inventory.Add("Goddess_Gown", New GoddessGown())           '73
        internal_inventory.Add("Succubus_Garb", New SuccubusGarb())         '74
        internal_inventory.Add("Regal_Gown", New PrincessGown())            '75
        internal_inventory.Add("Clear_Potion", New ClearPotion())           '76
        internal_inventory.Add("Minor_Ring_of_Regen.", New ROfMinRegen())   '77
        internal_inventory.Add("Val._Night_Lingerie", New VNightLingerie()) '78
        internal_inventory.Add("Val._Day_Suit", New VDayClothes())          '79
        internal_inventory.Add("Dissolved_Clothes", New DissolvedClothes()) '80     actually a part of 0.8
        internal_inventory.Add("Ring_of_the_L._Goddess", New ROTLGoddess()) '81
        internal_inventory.Add("Major_Health_Potion", New MajHealthPotion()) '82
        internal_inventory.Add("Bronze_Armor", New BronzeArmor())           '83
        internal_inventory.Add("Bronze_Battle_Axe", New BronzeAxe())        '84
        internal_inventory.Add("Bronze_Bikini", New BronzeBikini())         '85
        internal_inventory.Add("Portal_Chalk", New PortalChalk())           '86
        '0.8
        internal_inventory.Add("Bimbo_Lesson", New BimboLesson())           '87
        internal_inventory.Add("Combat_Manual", New CombatManual())         '88
        internal_inventory.Add("Utility_Manual", New UtilityManual())       '89
        internal_inventory.Add("Panacea", New Panacea())                    '90
        internal_inventory.Add("Vial_of_Venom", New VialOfVenom())          '91
        internal_inventory.Add("Anti_Venom", New AntiVenom())               '92
        internal_inventory.Add("Blinding_Potion", New BlindPotion())        '93
        internal_inventory.Add("Armored_Bunny_Suit", New BunnySuitA())      '94
        internal_inventory.Add("Valkyrie_Armor", New ValkyrieArmor())       '95
        internal_inventory.Add("Valkyrie_Sword", New ValkyrieSword())       '96
        internal_inventory.Add("Bowtie", New Bowtie())                      '97
        internal_inventory.Add("Cursed_Heavy_Cream", New CHeavyCream())     '98
        internal_inventory.Add("Amazonian_Attire", New AmaAttire())         '99
        internal_inventory.Add("Cherry_Stick_of_Gum", New CStickOfGum())    '100
        internal_inventory.Add("Barbarian_Armor", New BarbArmor())          '101
        internal_inventory.Add("Space_Age_Jumpsuit", New SAJumpsuit())      '102
        internal_inventory.Add("Skin_Tight_Bodysuit", New STBodysuit())     '103
        internal_inventory.Add("Photon_Armor", New PhotonArmor())           '104
        internal_inventory.Add("Photon_Bikini", New PhotonBikini())         '105
        internal_inventory.Add("Labcoat", New Labcoat())                    '106
        internal_inventory.Add("Labcoat​", New LabcoatSV())                  '107
        internal_inventory.Add("Spatial_Shroom", New SShroom())             '108
        internal_inventory.Add("Mint_Stick_of_Gum", New MStickOfGum())      '109
        internal_inventory.Add("Mobile_Powerbank", New Generator())         '110
        internal_inventory.Add("Discharge_Gauntlets", New ManaDisharge())   '111
        internal_inventory.Add("Photon_Blade", New PhotonBlade())           '112
        internal_inventory.Add("Amazon_Lesson", New AmazonLesson())         '113
        internal_inventory.Add("Barbarian_Lesson", New BarbarianLesson())   '114
        internal_inventory.Add("Warlock's_Robes", New WarlockRobe())         '115
        internal_inventory.Add("Gynoid_Uniform", New GCUniform())           '116
        internal_inventory.Add("Garden_Salad", New GardenSalad())           '117
        internal_inventory.Add("Corse_War_Axe", New CWarAxe())              '118
        internal_inventory.Add("Broken_Remote", New TFTestRemote())         '119
        internal_inventory.Add("Shrink_Ray", New ShrinkRay())               '120
        internal_inventory.Add("Name_Change", New NameChange())             '121
        internal_inventory.Add("Gorgon_Lesson", New HGorgonLesson())        '122
        internal_inventory.Add("Ring_of_Uvona", New RingOfUvona())          '123
        internal_inventory.Add("Warlock_Lesson", New WarlockLesson())       '124
        internal_inventory.Add("Berry_Stick_of_Gum", New BBStickOfGum())    '125
        internal_inventory.Add("Omni_Charm", New OmniCharm())               '126
        internal_inventory.Add("Vial_of_BIM_II", New VialOfBimbo())         '127
        internal_inventory.Add("CryoGrenade", New CryoGrenade())            '128
        internal_inventory.Add("Bunny_Suit​", New SVBunnySuit())             '129
        internal_inventory.Add("Galaxy_Dye​", New galaxyDye())             '130

        armor = {New CommonClothes, New SkimpyClothes, New Naked, New VSkimpyClothes,
                 Me.item(5), Me.item(7), Me.item(8), Me.item(10),
                 Me.item(12), Me.item(16), Me.item(17), Me.item(18),
                 Me.item(19), Me.item(20), Me.item(38), Me.item(39),
                 Me.item(46), Me.item(47), Me.item(54), Me.item(55),
                 Me.item(56), Me.item(64), Me.item(71), Me.item(72),
                 Me.item(73), Me.item(74), Me.item(75), Me.item(78),
                 Me.item(79), Me.item(83), Me.item(85), Me.item(80),
                 Me.item(94), Me.item(95), Me.item(99), Me.item(101),
                 Me.item(102), Me.item(103), Me.item(104), Me.item(105),
                 Me.item(106), Me.item(107), Me.item(115), Me.item(116),
                 Me.item(129)}

        weapons = {New BareFists(),
                   Me.item(6), Me.item(9), Me.item(11), Me.item(21),
                   Me.item(22), Me.item(23), Me.item(24), Me.item(40),
                   Me.item(41), Me.item(42), Me.item(45), Me.item(63),
                   Me.item(84), Me.item(96), Me.item(111), Me.item(112),
                   Me.item(118), Me.item(120)}

        useable = {Me.item(0), Me.item(1), Me.item(3), Me.item(4),
                   Me.item(65), Me.item(15), Me.item(36), Me.item(37),
                   Me.item(45), Me.item(48), Me.item(49), Me.item(50),
                   Me.item(51), Me.item(52), Me.item(57), Me.item(58),
                   Me.item(81), Me.item(86), Me.item(88), Me.item(89),
                   Me.item(91), Me.item(119), Me.item(126), Me.item(127),
                   Me.item(128), Me.item(130)}

        food = {Me.item(30), Me.item(31), Me.item(32), Me.item(33),
                Me.item(34), Me.item(35), Me.item(44), Me.item(90),
                Me.item(98), Me.item(100), Me.item(108), Me.item(109),
                Me.item(117), Me.item(125)}

        acce = {New noAcce(), Me.item(66), Me.item(67), Me.item(68),
                Me.item(69), Me.item(70), Me.item(77), Me.item(81),
                Me.item(97), Me.item(110), Me.item(123)}

        potions = {Me.item(2), Me.item(13), Me.item(14), Me.item(25),
                   Me.item(26), Me.item(27), Me.item(28), Me.item(29),
                   Me.item(59), Me.item(60), Me.item(61), Me.item(62),
                   Me.item(76), Me.item(80), Me.item(82), Me.item(92),
                   Me.item(93)}
        Array.Sort(potions)

        misc = {Me.item(43), Me.item(53)}

        invIDorder = New List(Of Integer)

        If shufflePotions Then setPotionNames()
    End Sub
    Sub setPotionNames()
        Dim names = New List(Of String)
        names.AddRange({"Red_Potion", "Green_Potion", "Blue_Potion", "Golden_Potion",
                      "Azure_Potion", "Rose_Potion", "Mauve_Potion", "Jet_Potion",
                      "Ruby_Potion", "Emerald_Potion", "Saphire_Potion", "Silver_Potion",
                      "Murky_Potion", "Smokey_Potion", "Pink_Potion", "Glittery_Potion",
                      "Florecent_Potion"})
        mPotions = New List(Of MysteryPotion)
        For i = 0 To UBound(potions)
            If potions(i).GetType().IsSubclassOf(GetType(MysteryPotion)) Then mPotions.Add(potions(i))
        Next
        Randomize()
        For Each p In mPotions
            Dim r = Int(Rnd() * names.Count)
            p.setFName(names(r))
            names.RemoveAt(r)
        Next
    End Sub

    '|UTILITY|
    Sub merge(ByRef inv As Inventory)
        For i = 0 To upperBound()
            item(i).add(inv.item(i).count)
        Next
    End Sub
    Sub mergeRevalue(ByRef inv As Inventory)
        For i = 0 To upperBound()
            item(i).value = inv.item(i).value
            item(i).add(inv.item(i).count)
        Next
    End Sub
    Sub add(ByVal key As String, ByVal count As Integer)
        If internal_inventory.Keys.Contains(key) Then
            internal_inventory(key).add(count)
        Else
            MsgBox("Saved inventory item not detected!  Key: " & key)
        End If
        sum += count
    End Sub
    Sub add(ByVal id As Integer, ByVal count As Integer)
        If id >= 0 And id < upperBound() Then
            Dim key = internal_inventory.Keys(id)
            internal_inventory(key).add(count)
        End If
        sum += count
    End Sub
    Sub setCount(k As String, v As Integer)
        sum -= item(k).count
        item(k).count = v
        sum += v
    End Sub
    Sub setCount(i As Integer, v As Integer)
        sum -= item(i).count
        item(i).count = v
        sum += v
    End Sub


    '|SAVE/LOAD|
    Function save() As String
        Dim out = CStr(upperBound()) & ":"
        For i = 0 To upperBound()
            out += getKeyByID(i) & "~" & item(i).count & ":"
        Next

        If Not mPotions Is Nothing Then
            out += CStr(mPotions.Count - 1) & ":"
            For i = 0 To mPotions.Count - 1
                out += mPotions(i).getName() & "~" & mPotions(i).hasBeenUsed & ":"
            Next
        Else
            out += "na:"
        End If

        out += "*"
        Return out
    End Function
    Sub load(ByVal input As String)
        Dim parse As String() = input.Split(":")

        For i As Integer = 1 To parse(0) + 1
            Dim subParse As String() = parse(i).Split("~")
            add(subParse(0), CInt(subParse(1)))
        Next
        Dim x = CInt(parse(0)) + 2
        If Not parse(x).Equals("na") Then
            For i = x + 1 To x + CInt(parse(x))
                Dim subParse As String() = parse(i).Split("~")
                mPotions(i - (x + 1)).setFName(subParse(0))
                mPotions(i - (x + 1)).hasBeenUsed = CBool(subParse(1))
                If mPotions(i - (x + 1)).hasBeenUsed Then mPotions(i - (x + 1)).reveal()
            Next
        End If
        sum = calcSum()
    End Sub

    '|GETTERS|
    Public Function item(ByVal n As String) As Item
        If internal_inventory.Keys.Contains(n) Then
            Return internal_inventory(n)
        Else
            Return Nothing
        End If
    End Function
    Public Function item(ByVal id As Integer) As Item
        If id < 0 Or id > upperBound() Then Return Nothing
        Dim key = internal_inventory.Keys(id)
        Return internal_inventory(key)
    End Function
    Public Function getKeyByID(ByVal id As Integer) As String
        Return internal_inventory.Keys(id)
    End Function
    Public Function idOfKey(ByVal n As String) As Integer
        If Not internal_inventory.Keys.Contains(n) Then Return -1
        Return item(n).id
    End Function
    Public Function getCountAt(ByVal i As Integer) As Integer
        Return item(i).getCount
    End Function
    Public Function getCountAt(ByVal n As String) As Integer
        Return item(n).getCount
    End Function
    Private Function calcSum() As Integer
        Dim totalSum As Integer = 0
        For i = 0 To upperBound()
            totalSum += getCountAt(i)
        Next
        Return totalSum
    End Function

    Function getArmors() As Tuple(Of String(), Armor())
        Dim s(UBound(armor)) As String
        For i = 0 To UBound(armor)
            s(i) = armor(i).getName
        Next
        Return New Tuple(Of String(), Armor())(s, armor)
    End Function
    Function getWeapons() As Tuple(Of String(), Weapon())
        Dim s(UBound(weapons)) As String
        For i = 0 To UBound(weapons)
            s(i) = weapons(i).getName
        Next
        Return New Tuple(Of String(), Weapon())(s, weapons)
    End Function
    Function getAccesories() As Tuple(Of String(), Accessory())
        Dim s(UBound(acce)) As String
        For i = 0 To UBound(acce)
            s(i) = acce(i).getName
        Next
        Return New Tuple(Of String(), Accessory())(s, acce)
    End Function
    Function getUseable() As Item()
        Return useable
    End Function
    Function getFood() As Item()
        Return food
    End Function
    Function getPotions() As Item()
        Return potions
    End Function
    Function getMisc() As Item()
        Return misc
    End Function
    Public Function getSum() As Integer
        Return sum
    End Function

    Function upperBound() As Integer
        Return internal_inventory.Count - 1
    End Function
    Function count() As Integer
        Return internal_inventory.Count
    End Function
End Class
