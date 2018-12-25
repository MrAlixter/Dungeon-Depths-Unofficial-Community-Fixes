Public Class Inventory
    Dim internal_inventory As New Dictionary(Of String, Item)
    Public mysteryPotionDisplayOrder As New List(Of String)
    Dim armor() As Armor
    Dim weapons() As Weapon
    Dim acce() As Accessory
    Dim useable(), food(), potions(), misc() As Item
    Public invNeedsUDate As Boolean = False

    '|CONSTUCTOR|
    Sub New()
        '0.1 - 0.4
        internal_Inventory.Add("Compass", New Compass())                    '0
        internal_Inventory.Add("Stick_of_Gum", New StickOfGum())            '1
        internal_Inventory.Add("Health_Potion", New HealthPotion())         '2
        internal_Inventory.Add("Vial_of_Slime", New VialOfSlime())          '3
        internal_Inventory.Add("Spellbook", New Spellbook())                '4
        internal_Inventory.Add("Steel_Armor", New SteelArmor())             '5
        internal_Inventory.Add("Steel_Sword", New SteelSword())             '6
        internal_Inventory.Add("Steel_Bikini", New SteelBikini())           '7
        internal_Inventory.Add("Chicken_Suit", New ChickenSuit())           '8
        internal_Inventory.Add("SoulBlade", New SoulBlade())                '9
        internal_Inventory.Add("Magic_Girl_Outfit", New MagGirlOutfit())    '10
        internal_Inventory.Add("Magic_Girl_Wand", New MagGirlWand())        '11
        internal_Inventory.Add("Cat_Lingerie", New CatLingerie())           '12
        internal_Inventory.Add("Mana_Potion", New ManaPotion())             '13
        internal_Inventory.Add("Restore_Potion", New RestorationPotion())   '14
        internal_Inventory.Add("Cat_Ears", New CatEars())                   '15
        internal_Inventory.Add("Bunny_Suit", New BunnySuit())               '16
        internal_Inventory.Add("Sorcerer's_Robes", New SorcerersRobes())    '17
        internal_Inventory.Add("Witch_Cosplay", New WitchCosplay())         '18
        internal_Inventory.Add("Warrior's_Cuirass", New WarriorsCuirass())  '19
        internal_Inventory.Add("Brawler_Cosplay", New BrawlerCosplay())     '20
        internal_Inventory.Add("Oak_Staff", New OakStaff())                 '21
        internal_Inventory.Add("Wizard_Staff", New WizardStaff())           '22
        internal_Inventory.Add("Bronze_Xiphos", New BronzeXiphos())         '23
        internal_Inventory.Add("Sword_of_the_Brutal", New TargaxSword())    '24
        internal_inventory.Add("Blonde_Dye", New BlondePotion())            '25
        internal_Inventory.Add("Random_Hair_Dye", New RandomHairPotion())   '26
        internal_Inventory.Add("Red_Hair_Dye", New RedHairPotion())         '27
        internal_Inventory.Add("Feminine_Potion", New FemininePotion())     '28
        internal_Inventory.Add("Breast_Enlarging_Potion", New BEPotion())   '29
        internal_Inventory.Add("Chicken_Leg", New ChickenLeg())             '30
        internal_Inventory.Add("Apple", New Apple())                        '31
        internal_Inventory.Add("Apple​", New PApple())                       '32
        internal_Inventory.Add("Medicinal_Tea", New Herbs())                '33
        internal_Inventory.Add("Heavy_Cream", New HeavyCream())             '34
        internal_Inventory.Add("Cupcake", New Cupcake())                    '35
        internal_Inventory.Add("Mirror", New Mirror())                      '36
        internal_Inventory.Add("Glowstick", New Glowstick())                '37
        internal_Inventory.Add("Gold_Armor", New GoldArmor())               '38
        internal_Inventory.Add("Gold_Adornment", New GoldAdornment())       '39
        internal_Inventory.Add("Gold_Sword", New GoldSword())               '40
        internal_Inventory.Add("Golden_Staff", New GoldenStaff())           '41
        internal_Inventory.Add("Midas_Gauntlet", New MidasGuantlet())       '42
        internal_Inventory.Add("Gold", New Gold())                          '43
        internal_Inventory.Add("Angel_Food_Cake", New AngelFood())          '44
        internal_Inventory.Add("Duster", New MaidDuster())                  '45
        internal_Inventory.Add("Tanktop", New TankTop())                    '46
        internal_Inventory.Add("Sports_Bra", New SportBra())                '47
        internal_Inventory.Add("Health_Charm", New HealthCharm())           '48
        internal_Inventory.Add("Mana_Charm", New ManaCharm())               '49
        internal_Inventory.Add("Attack_Charm", New AttackCharm())           '50
        internal_Inventory.Add("Defence_Charm", New DefenceCharm())         '51
        internal_Inventory.Add("Speed_Charm", New SpeedCharm())             '52
        internal_Inventory.Add("Key", New Key())                            '53
        internal_Inventory.Add("Ropes", New Ropes())                        '54
        internal_Inventory.Add("Living_Armor", New LiveArmor())             '55
        internal_Inventory.Add("Living_Lingerie", New LiveLingerie())       '56
        internal_Inventory.Add("Disarment_Kit", New RigWrench())            '57
        internal_Inventory.Add("Fusion_Crystal", New FusionCrystal())       '58
        internal_Inventory.Add("Masculine_Potion", New MasculinePotion())   '59
        internal_Inventory.Add("Breast_Shrinking_Potion", New BSPotion())   '60
        internal_Inventory.Add("HyperHeal_Potion", New HyperHealPotion())   '61
        internal_Inventory.Add("HyperMana_Potion", New HyperManaPotion())   '62
        internal_Inventory.Add("Spidersilk_Whip", New SpidersilkWhip())     '63
        internal_Inventory.Add("Chitin_Armor", New ChitArmor())             '64
        '0.5
        internal_Inventory.Add("Advanced_Spellbook", New ASpellbook())      '65
        '0.6
        internal_Inventory.Add("Heart_Necklace", New HeartNecklace())       '66
        internal_Inventory.Add("Red_Headband", New RedHeadband())           '67
        internal_Inventory.Add("Ruby_Circlet", New RubyCirclet())           '68
        internal_Inventory.Add("Slave_Collar", New ThrallCollar())          '69
        internal_Inventory.Add("Cowbell", New Cowbell())                    '70
        internal_Inventory.Add("Cow_Print_Bra", New CowBra())               '71
        '0.7
        internal_Inventory.Add("Maid_Outfit", New MaidOutfit())             '72
        internal_Inventory.Add("Goddess_Gown", New GoddessGown())           '73
        internal_Inventory.Add("Succubus_Garb", New SuccubusGarb())         '74
        internal_Inventory.Add("Regal_Gown", New PrincessGown())            '75

        armor = {New NormalClothes, New SkimpyClothes, New Naked,
                 Me.item(5), Me.item(7), Me.item(8), Me.item(10),
                 Me.item(12), Me.item(16), Me.item(17), Me.item(18),
                 Me.item(19), Me.item(20), Me.item(38), Me.item(39),
                 Me.item(46), Me.item(47), Me.item(54), Me.item(55),
                 Me.item(56), Me.item(64), Me.item(71), Me.item(72),
                 Me.item(73), Me.item(74), Me.item(75)}

        weapons = {New BareFists(),
                   Me.item(6), Me.item(9), Me.item(11), Me.item(21),
                   Me.item(22), Me.item(23), Me.item(24), Me.item(40),
                   Me.item(41), Me.item(42), Me.item(45), Me.item(63)}

        useable = {Me.item(0), Me.item(1), Me.item(3), Me.item(4),
                   Me.item(65), Me.item(15), Me.item(36), Me.item(37),
                   Me.item(45), Me.item(48), Me.item(49), Me.item(50),
                   Me.item(51), Me.item(52), Me.item(57), Me.item(58)}

        food = {Me.item(30), Me.item(31), Me.item(32), Me.item(33),
                Me.item(34), Me.item(35), Me.item(44)}

        acce = {New noAcce(), Me.item(66), Me.item(67), Me.item(68),
                Me.item(69), Me.item(70)}

        potions = {Me.item(2), Me.item(13), Me.item(14), Me.item(25),
                   Me.item(26), Me.item(27), Me.item(28), Me.item(29),
                   Me.item(59), Me.item(60), Me.item(61), Me.item(62)}
        Array.Sort(potions)

        misc = {Me.item(43), Me.item(53)}
    End Sub

    '|UTILITY|
    Sub merge(ByRef inv As Inventory)
        For i = 0 To upperBound()
            item(i).add(inv.item(i).count)
        Next
    End Sub
    Sub add(ByVal key As String, ByVal count As Integer)
        If internal_inventory.Keys.Contains(key) Then
            internal_inventory(key).add(count)
        End If
    End Sub
    Sub add(ByVal id As Integer, ByVal count As Integer)
        If id > 0 And id < upperBound() Then
            Dim key = internal_inventory.Keys(id)
            internal_inventory(key).add(count)
        End If
    End Sub

    '|SAVE/LOAD|
    Function save() As String
        Dim out = CStr(upperBound()) & ":"
        For i = 0 To upperBound()
            out += getKeyByID(i) & "~" & item(i).count & ":"
        Next
        out += "*"
        Return out
    End Function
    Sub load(ByVal input As String)
        Dim parse As String() = input.Split(":")
        For i As Integer = 1 To parse(0)
            Dim subParse As String() = parse(i).Split("~")
            add(subParse(0), CInt(subParse(1)))
        Next
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
        Return item(n).id
    End Function
    Public Function getCountAt(ByVal i As Integer) As Integer
        Return item(i).getCount
    End Function
    Public Function getCountAt(ByVal n As String) As Integer
        Return item(n).getCount
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

    Function upperBound()
        Return internal_inventory.Count - 1
    End Function
    Function count()
        Return internal_inventory.Count
    End Function
End Class
