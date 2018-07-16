Public Class State
    'the State class contains all relevent data unique to a player's form at any given time

    'instance data for a state
    Dim name, sex, title, description As String
    Dim health, maxHealth, mana, maxMana, attack, defence As Integer
    Dim will, speed, evade, gold, lust As Integer
    Dim breastSize, hunger As Integer
    Dim equippedWeapon As Weapon
    Dim equippedArmor As Armor
    Dim equippedAcce As Accessory
    Public iArrInd(16) As Tuple(Of Integer, Boolean)
    Dim perks As Dictionary(Of String, Integer)
    Dim sexBool, invNeedsUDate As Boolean
    Dim haircolor, skincolor, textColor As Color
    Dim pImage As Image
    Dim wingIndex As Integer
    Public initFlag As Boolean = False

    'constructs a state from an instance of a player
    Sub New(ByRef p As Player)
        name = p.name
        sex = p.sex
        title = p.title
        description = p.description
        health = p.health
        maxHealth = p.maxHealth
        mana = p.mana
        maxMana = p.mana
        attack = p.attack
        defence = p.defence
        will = p.will
        speed = p.speed
        evade = p.evade
        gold = p.gold
        lust = p.lust
        breastSize = p.breastSize
        hunger = p.hunger
        equippedWeapon = p.equippedWeapon
        equippedArmor = p.equippedArmor
        equippedAcce = p.equippedAcce
        iArrInd = p.iArrInd.Clone
        perks = New Dictionary(Of String, Integer)(p.perks)
        sexBool = p.sexBool
        invNeedsUDate = p.invNeedsUDate
        haircolor = p.haircolor
        skincolor = p.skincolor
        textColor = p.TextColor
        pImage = p.pImage
        wingIndex = p.wingInd
        initFlag = True
    End Sub
    'constructs a state with placeholder values
    'this constructor is used to initialize a state
    Sub New()
        name = ""
        sex = ""
        title = ""
        description = ""
        health = 0
        maxHealth = 0
        mana = 0
        maxMana = 0
        attack = 0
        defence = 0
        will = 0
        speed = 0
        evade = 0
        gold = 0
        lust = 0
        breastSize = 0
        hunger = 0
        equippedWeapon = New BareFists
        equippedArmor = New Naked
        equippedAcce = New noAcce
        iArrInd = {New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False)}
        perks = New Dictionary(Of String, Integer)()
        sexBool = False
        invNeedsUDate = False
        haircolor = Color.Black
        skincolor = Color.Black
        textColor = Color.Black
        wingIndex = 0
        ReDim iArrInd(16)
    End Sub

    'load applies a state to a given instance of a player
    Public Sub load(ByRef p As Player)
        p.name = name
        p.sex = sex
        p.title = title
        p.description = description
        p.maxHealth = maxHealth
        If p.health > maxHealth + p.hBuff Then p.health = (maxHealth + p.hBuff)
        p.maxMana = maxMana
        If p.mana > maxMana + p.mBuff Then p.mana = maxMana + p.mBuff
        p.attack = attack
        p.defence = defence
        p.will = will
        p.speed = speed
        p.evade = evade
        p.gold = gold
        p.lust = lust
        p.breastSize = breastSize
        p.equippedWeapon = equippedWeapon
        Equipment.clothesChange(equippedArmor.getName)
        Equipment.accChange(equippedArmor.getName)
        p.equippedArmor = equippedArmor
        p.equippedAcce = equippedAcce
        p.iArrInd = iArrInd.Clone
        p.perks = New Dictionary(Of String, Integer)(perks)
        p.sexBool = sexBool
        p.invNeedsUDate = invNeedsUDate
        p.haircolor = haircolor
        p.skincolor = skincolor
        p.TextColor = textColor
        p.wingInd = wingIndex
        p.pImage = pImage
    End Sub
    'save applies a given instance of a player to a state
    Public Sub save(ByRef p As Player)
        name = p.name
        sex = p.sex
        title = p.title
        description = p.description
        health = p.health
        'health += p.hBuff
        maxHealth = p.maxHealth
        'maxHealth += p.hBuff
        mana = p.mana
        'mana += p.mBuff
        maxMana = p.maxMana
        'maxMana += p.mBuff
        attack = p.attack
        'attack += p.aBuff
        defence = p.defence
        'defence += p.dBuff
        will = p.will
        'will += p.wBuff
        speed = p.speed
        'speed += p.sBuff
        evade = p.evade
        gold = p.gold
        lust = p.lust
        breastSize = p.breastSize
        hunger = p.hunger
        equippedWeapon = p.equippedWeapon
        equippedArmor = p.equippedArmor
        equippedAcce = p.equippedAcce
        iArrInd = p.iArrInd.Clone
        perks = New Dictionary(Of String, Integer)(p.perks)
        sexBool = p.sexBool
        invNeedsUDate = p.invNeedsUDate
        haircolor = p.haircolor
        skincolor = p.skincolor
        textColor = p.TextColor
        wingIndex = p.wingInd
        pImage = p.pImage
    End Sub

    'read converts a string given from a save file into a state
    Public Sub read(ByVal s As String)
        Equipment.init()
        Dim pimg() As Image = {Game.picPlayer.BackgroundImage, Game.picPlayerB.BackgroundImage, Game.picChicken.BackgroundImage, Game.picBimbof.BackgroundImage, Game.picPlayerf.BackgroundImage}
        Dim readArray() As String = s.Split("*")
        If readArray(0) = "N/A" Then
            name = ""
            sex = ""
            title = ""
            description = ""
            health = 0
            maxHealth = 0
            mana = 0
            maxMana = 0
            attack = 0
            defence = 0
            will = 0
            speed = 0
            evade = 0
            gold = 0
            lust = 0
            breastSize = 0
            hunger = 0
            equippedWeapon = New BareFists
            equippedArmor = New Naked
            iArrInd = {New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False), New Tuple(Of Integer, Boolean)(2, False)}
            perks = New Dictionary(Of String, Integer)()
            sexBool = False
            invNeedsUDate = False
            haircolor = Color.Black
            skincolor = Color.Black
            textColor = Color.Black
            Exit Sub
        End If

        name = readArray(0)
        title = readArray(1)
        description = readArray(2)
        health = CInt(readArray(3))
        maxHealth = CInt(readArray(4))
        mana = CInt(readArray(5))
        maxMana = CInt(readArray(6))
        If Not readArray(7).Equals("placehold") Then wingIndex = CInt(readArray(7)) Else wingIndex = 0
        attack = CInt(readArray(10))
        defence = CInt(readArray(11))
        will = CInt(readArray(12))
        speed = CInt(readArray(13))
        evade = CInt(readArray(14))
        hunger = CInt(readArray(15))
        gold = CInt(readArray(16))

        For i = 0 To UBound(Equipment.aNameList)
            If readArray(17) = Equipment.aNameList(i) Then
                equippedArmor = Equipment.aList(i)
                Exit For
            End If
        Next
        For i = 0 To UBound(Equipment.wNameList)
            If readArray(18) = Equipment.wNameList(i) Then
                equippedWeapon = Equipment.wList(i)
                Exit For
            End If
        Next

        sex = readArray(19)
        If sex = "Male" Then sexBool = False Else sexBool = True

        breastSize = CInt(readArray(21))

        Dim A = 255
        If Not readArray(8).Equals("placehold") Then A = readArray(8)
        haircolor = Color.FromArgb(A, CInt(readArray(22)), CInt(readArray(23)), CInt(readArray(24)))
        A = 255
        If Not readArray(9).Equals("placehold") Then A = readArray(9)
        skincolor = Color.FromArgb(A, CInt(readArray(25)), CInt(readArray(26)), CInt(readArray(27)))
        textColor = Color.FromArgb(255, CInt(readArray(28)), CInt(readArray(29)), CInt(readArray(30)))


        Dim b1 As Integer = readArray(31)
        For i = 0 To b1 - 1
            Dim kvp = readArray(32 + i).Split("!")
            perks(kvp(0)) = CInt(kvp(1))
        Next
        For i = 0 To UBound(iArrInd)
            Dim arr() As String = readArray(32 + b1 + i).Split("%")
            iArrInd(i) = New Tuple(Of Integer, Boolean)(CInt(arr(0)), CBool(arr(1)))
        Next
        pImage = pimg(readArray(32 + b1 + 17))

        For i = 0 To UBound(Equipment.acNameList)
            If readArray(32 + b1 + 18) = Equipment.acNameList(i) Then
                equippedAcce = Equipment.acList(i)
                Exit For
            End If
        Next

        initFlag = True
    End Sub
    'write converts a state into a string to be put into a save file
    Public Function write() As String
        If initFlag Then
            Dim output As String = CStr(name & "*" & title & "*" & description & "*" & health & "*" & maxHealth & "*" & mana & "*" & maxMana & "*" & wingIndex & "*" & haircolor.A & "*" & skincolor.A & "*" & _
               attack & "*" & defence & "*" & will & "*" & speed & "*" & evade & "*" & hunger & "*" & gold & "*" & equippedArmor.getName() & "*" & equippedWeapon.getName() & "*" & _
               sex & "*" & "placeholder" & "*" & breastSize & "*" & haircolor.R & "*" & haircolor.G & "*" & haircolor.B & "*" & skincolor.R & "*" & skincolor.G & "*" & skincolor.B & "*" & _
               textColor.R & "*" & textColor.G & "*" & textColor.B & "*")
            output += perks.Count & "*"
            For Each kvp As KeyValuePair(Of String, Integer) In perks
                output += (kvp.Key & "!" & kvp.Value & "*")
            Next
            For i = 0 To UBound(iArrInd)
                output += (iArrInd(i).Item1 & "%" & iArrInd(i).Item2 & "*")
            Next
            If Not initFlag Then pImage = Game.picChicken.BackgroundImage
            output += Array.IndexOf({Game.picPlayer.BackgroundImage, Game.picPlayerB.BackgroundImage, Game.picChicken.BackgroundImage, Game.picBimbof.BackgroundImage, Game.picPlayerf.BackgroundImage}, pImage).ToString & "*"
            output += Game.player.equippedAcce.getName & "*"
            Return output + "#"
        Else
            Return "N/A#"
        End If
    End Function
End Class
