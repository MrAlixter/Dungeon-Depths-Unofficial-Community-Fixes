Public Class State
    'the State class contains all relevent data unique to a player's form at any given time

    'instance data for a state
    public name, sex, description As String
    Public pClass As pClass = New Classless()
    Public pForm As pForm = New Human()
    Public health As Double
    Public maxHealth, mana, maxMana, attack, defense As Integer
    Public will, speed, gold, lust As Integer
    Public breastSize, stamina, dickSize, buttSize As Integer
    Public equippedWeapon As Weapon
    Public equippedArmor As Armor
    Public equippedAcce As Accessory
    Public equippedGlasses As Glasses
    Public iArrInd(Portrait.NUM_IMG_LAYERS) As Tuple(Of Integer, Boolean, Boolean)
    Public perks As Dictionary(Of perk, Integer)
    Public invNeedsUDate As Boolean
    Public haircolor, skincolor, textColor As Color
    Public initFlag As Boolean = False
    Public isPetrified = False

    'constructs a state from an instance of a player
    Sub New(ByVal p As Player)
        name = p.name
        sex = p.sex
        pClass = Player.classes(p.className)
        pForm = Player.forms(p.formName)
        description = p.description
        health = p.health
        maxHealth = p.maxHealth
        mana = p.mana
        maxMana = p.mana
        attack = p.attack
        defense = p.defense
        will = p.will
        speed = p.speed
        gold = p.gold
        lust = p.lust
        breastSize = p.breastSize
        dickSize = p.dickSize
        buttSize = p.buttSize
        stamina = p.stamina
        equippedWeapon = If(p.equippedWeapon.getAName.Equals("Fists"), New BareFists, p.inv.item(p.equippedWeapon.getId))
        equippedArmor = If(p.equippedArmor.getAName.Equals("Naked"), New Naked, p.inv.item(p.equippedArmor.getId))
        equippedAcce = If(p.equippedAcce.getAName.Equals("Nothing"), New noAcce, p.inv.item(p.equippedAcce.getId))
        equippedGlasses = If(p.equippedGlasses.getAName.Equals("Nothing"), New noGlasses, p.inv.item(p.equippedGlasses.getId))
        iArrInd = p.prt.iArrInd.Clone
        perks = DDUtils.copyDictionary(p.perks)
        invNeedsUDate = p.inv.invNeedsUDate
        haircolor = p.prt.haircolor
        skincolor = p.prt.skincolor
        textColor = p.textColor
        initFlag = True
    End Sub
    'constructs a state with placeholder values
    Sub New()
        name = ""
        sex = ""
        pClass = New Classless()
        pForm = New Human()
        description = ""
        health = 0
        maxHealth = 0
        mana = 0
        maxMana = 0
        attack = 0
        defense = 0
        will = 0
        speed = 0
        gold = 0
        lust = 0
        breastSize = 0
        dickSize = 0
        buttSize = 0
        stamina = 0
        equippedWeapon = New BareFists
        equippedArmor = New Naked
        equippedAcce = New noAcce
        equippedGlasses = New noGlasses
        ReDim iArrInd(Portrait.NUM_IMG_LAYERS)
        perks = New Dictionary(Of perk, Integer)()
        invNeedsUDate = False
        haircolor = Color.Black
        skincolor = Color.Black
        textColor = Color.Black
    End Sub

    Public Function clone(ByVal p As Player)
        load(p, True)
        Return (New State(p))
    End Function

    'load applies a state to a given instance of a player
    Public Sub load(ByRef p As Player, Optional overwriteStats As Boolean = True)
        p.name = name
        p.sex = sex

        p.description = description

        If overwriteStats Then
            p.maxHealth = maxHealth
            If p.health > 1 Then p.health = 1
            p.maxMana = maxMana
            p.attack = attack
            p.defense = defense
            p.will = will
            p.speed = speed
            p.lust = lust
            p.perks = DDUtils.copyDictionary(perks)
            p.pClass = Player.classes(pClass.name)
            p.pForm = Player.forms(pForm.name)
        Else
            p.changeClass(pClass.name)
            p.changeForm(pForm.name)
        End If

        p.gold = gold
        p.breastSize = breastSize
        p.dickSize = dickSize
        p.buttSize = buttSize
        If p.perks(perk.tfedbyweapon) < 0 And p.inv.getCountAt(equippedWeapon.getAName) > 0 And Not p.equippedWeapon.getAName.Equals(equippedWeapon.getAName) Then p.equippedWeapon = equippedWeapon
        If p.inv.getCountAt(equippedArmor.getAName) > 0 And Not p.equippedArmor.getAName.Equals(equippedArmor.getAName) Then EquipmentDialogBackend.equipArmor(p, equippedArmor.getAName)
        If p.inv.getCountAt(equippedAcce.getAName) > 0 And Not p.equippedAcce.getAName.Equals(equippedAcce.getAName) Then EquipmentDialogBackend.equipAcce(p, equippedAcce.getAName)
        If p.inv.getCountAt(equippedGlasses.getAName) > 0 And Not p.equippedGlasses.getAName.Equals(equippedGlasses.getAName) Then EquipmentDialogBackend.equipGlasses(p, equippedGlasses.getAName)
        p.prt.iArrInd = iArrInd.Clone
        p.inv.invNeedsUDate = invNeedsUDate
        p.prt.haircolor = haircolor
        p.prt.skincolor = skincolor
        p.textColor = textColor
        p.isPetrified = isPetrified
    End Sub
    'save applies a given instance of a player to a state
    Public Sub save(ByVal p As Player)
        name = p.name
        sex = p.sex
        pClass = Player.classes(p.className)
        pForm = Player.forms(p.formName)
        description = p.description
        health = p.health
        maxHealth = p.maxHealth
        mana = p.mana
        maxMana = p.maxMana
        attack = p.attack
        defense = p.defense
        will = p.will
        speed = p.speed
        gold = p.gold
        lust = p.lust
        breastSize = p.breastSize
        dickSize = p.dickSize
        buttSize = p.buttSize
        stamina = p.stamina
        equippedWeapon = If(p.equippedWeapon.getAName.Equals("Fists"), New BareFists, p.inv.item(p.equippedWeapon.getId))
        equippedArmor = If(p.equippedArmor.getAName.Equals("Naked"), New Naked, p.inv.item(p.equippedArmor.getId))
        equippedAcce = If(p.equippedAcce.getAName.Equals("Nothing"), New noAcce, p.inv.item(p.equippedAcce.getId))
        equippedGlasses = If(p.equippedGlasses.getAName.Equals("Nothing"), New noGlasses, p.inv.item(p.equippedGlasses.getId))
        iArrInd = p.prt.iArrInd.Clone
        perks = DDUtils.copyDictionary(p.perks)
        invNeedsUDate = p.inv.invNeedsUDate
        haircolor = p.prt.haircolor
        skincolor = p.prt.skincolor
        textColor = p.textColor
        isPetrified = p.isPetrified
    End Sub

    'read converts a string given from a save file into a state
    Public Sub read(ByVal s As String, ByVal version As Double)
        Equipment.init()
        Dim readArray() As String = s.Split("*")
        If readArray(0) = "N/A" Then
            name = ""
            sex = ""
            pClass = New Classless()
            pForm = New Human()
            description = ""
            health = 0
            maxHealth = 0
            mana = 0
            maxMana = 0
            attack = 0
            defense = 0
            will = 0
            speed = 0
            gold = 0
            lust = 0
            breastSize = 0
            stamina = 0
            equippedWeapon = New BareFists
            equippedArmor = New Naked
            ReDim iArrInd(Portrait.NUM_IMG_LAYERS)
            For i = 0 To Portrait.NUM_IMG_LAYERS
                iArrInd(i) = New Tuple(Of Integer, Boolean, Boolean)(Portrait.STARTING_INDEX(i), True, False)
            Next
            perks = New Dictionary(Of perk, Integer)()
            invNeedsUDate = False
            haircolor = Color.Black
            skincolor = Color.Black
            textColor = Color.Black
            Exit Sub
        End If
        name = readArray(0)
        pClass = Player.classes(readArray(1).Split("~")(0))
        pForm = Player.forms(readArray(1).Split("~")(1))
        description = readArray(2)
        health = CDbl(readArray(3))
        maxHealth = CInt(readArray(4))
        mana = CInt(readArray(5))
        maxMana = CInt(readArray(6))
        dickSize = CInt(readArray(7))

        attack = CInt(readArray(10))
        defense = CInt(readArray(11))
        will = CInt(readArray(12))
        speed = CInt(readArray(13))
        If Not readArray(14).Equals("placeholder") Then isPetrified = CBool(readArray(14))
        stamina = CInt(readArray(15))
        gold = CInt(readArray(16))

        For Each k In EquipmentDialogBackend.armor_list.Keys
            If readArray(17).Equals(k) Then
                equippedArmor = EquipmentDialogBackend.armor_list(k)
                Exit For
            End If
        Next
        For Each k In EquipmentDialogBackend.weapon_list.Keys
            If readArray(18).Equals(k) Then
                equippedWeapon = EquipmentDialogBackend.weapon_list(k)
                Exit For
            End If
        Next

        sex = readArray(19)
        buttSize = CInt(readArray(20))
        breastSize = CInt(readArray(21))

        Dim A = 255
        If Not readArray(8).Equals("placehold") Then A = readArray(8)
        haircolor = Color.FromArgb(A, CInt(readArray(22)), CInt(readArray(23)), CInt(readArray(24)))
        A = 255
        If Not readArray(9).Equals("placehold") Then A = readArray(9)
        skincolor = Color.FromArgb(A, CInt(readArray(25)), CInt(readArray(26)), CInt(readArray(27)))
        textColor = Color.FromArgb(255, CInt(readArray(28)), CInt(readArray(29)), CInt(readArray(30)))

        If Not readArray(31).Equals("placeholder") Then lust = CInt(readArray(31))

        Dim b1 As Integer = readArray(32)
        For i = 0 To b1 - 1
            Dim kvp = readArray(33 + i).Split("!")
            perks(CInt(kvp(0))) = CInt(kvp(1))
        Next

        Dim b2 As Integer = CInt(readArray(33 + b1))
        'MsgBox(b2)
        For i = 0 To b2
            Dim arr() As String = readArray(34 + b1 + i).Split("%")
            iArrInd(i) = New Tuple(Of Integer, Boolean, Boolean)(CInt(arr(0)), CBool(arr(1)), CBool(arr(2)))
        Next

        For Each k In EquipmentDialogBackend.accessory_list.Keys
            If readArray(35 + b1 + b2) = k Then
                equippedAcce = EquipmentDialogBackend.accessory_list(k)
                Exit For
            End If
        Next

        For Each k In EquipmentDialogBackend.glasses_list.Keys
            If readArray(36 + b1 + b2) = k Then
                equippedGlasses = EquipmentDialogBackend.glasses_list(k)
                Exit For
            End If
        Next

        '|Version Based Save Updating|
        If version = 0.92 Or version = 10.0 Then
            Dim t = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(21).Item1, iArrInd(21).Item2, iArrInd(21).Item3)

            For i = 20 To 14 Step -1
                iArrInd(i + 1) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(i).Item1, iArrInd(i).Item2, iArrInd(i).Item3)
            Next

            iArrInd(14) = t
        End If
        initFlag = True
    End Sub
    'write converts a state into a string to be put into a save file
    Public Function getName() As String
        Return name
    End Function
    Public Function getSkinColor() As Color
        Return skincolor
    End Function
    Public Function getHairColor() As Color
        Return haircolor
    End Function
    Public Sub saveHCSC(ByVal hc As Color, ByVal sc As Color)
        haircolor = hc
        skincolor = sc
    End Sub

    Public Sub setIArrInd(ByVal ind As pInd, ByVal i As Integer, ByVal fem As Boolean, ByVal def As Boolean)
        iArrInd(ind) = New Tuple(Of Integer, Boolean, Boolean)(i, fem, def)
    End Sub
End Class
