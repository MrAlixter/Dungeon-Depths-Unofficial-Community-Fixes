Public Class State
    'the State class contains all relevent data unique to a player's form at any given time

    'instance data for a state
    Dim name, sex, description As String
    Public pClass As pClass = New Classless()
    Public pForm As pForm = New Human()
    Dim health As Double
    Public maxHealth, mana, maxMana, attack, defence As Integer
    Dim will, speed, gold, lust As Integer
    Public breastSize, hunger As Integer
    Dim equippedWeapon As Weapon
    Public equippedArmor As Armor
    Dim equippedAcce As Accessory
    Public iArrInd(16) As Tuple(Of Integer, Boolean, Boolean)
    Dim perks As Dictionary(Of String, Integer)
    Dim invNeedsUDate As Boolean
    Dim haircolor, skincolor, textColor As Color
    Dim wingIndex As Integer
    Dim hornIndex As Integer
    Dim hBowIndex As Integer
    Public initFlag As Boolean = False
    Public isPetrified = False

    'constructs a state from an instance of a player
    Sub New(ByRef p As Player)
        name = p.name
        sex = p.sex
        pClass = p.classes(p.pClass.name)
        pForm = p.forms(p.pForm.name)
        description = p.description
        health = p.health
        maxHealth = p.maxHealth
        mana = p.mana
        maxMana = p.mana
        attack = p.attack
        defence = p.defence
        will = p.will
        speed = p.speed
        gold = p.gold
        lust = p.lust
        breastSize = p.breastSize
        hunger = p.hunger
        equippedWeapon = p.equippedWeapon
        equippedArmor = p.equippedArmor
        equippedAcce = p.equippedAcce
        iArrInd = p.prt.iArrInd.Clone
        perks = New Dictionary(Of String, Integer)(p.perks)
        invNeedsUDate = p.inv.invNeedsUDate
        haircolor = p.prt.haircolor
        skincolor = p.prt.skincolor
        textColor = p.TextColor
        wingIndex = p.prt.wingInd
        hornIndex = p.prt.hornInd
        hBowIndex = p.prt.hBowInd
        initFlag = True
    End Sub
    'constructs a state with placeholder values
    'this constructor is used to initialize a state
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
        defence = 0
        will = 0
        speed = 0
        gold = 0
        lust = 0
        breastSize = 0
        hunger = 0
        equippedWeapon = New BareFists
        equippedArmor = New Naked
        equippedAcce = New noAcce
        iArrInd = {New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False)}
        perks = New Dictionary(Of String, Integer)()
        invNeedsUDate = False
        haircolor = Color.Black
        skincolor = Color.Black
        textColor = Color.Black
        wingIndex = 0
        hornIndex = 0
        hBowIndex = 0
        Redim iArrInd(16)
    End Sub

    'load applies a state to a given instance of a player
    Public Sub load(ByRef p As Player, Optional overwriteStats As Boolean = True)
        p.name = name
        p.sex = sex
        p.pClass = p.classes(pClass.name)
        p.pForm = p.forms(pForm.name)
        p.description = description

        If overwriteStats Then
            p.maxHealth = maxHealth
            If p.health > 1 Then p.health = 1
            p.maxMana = maxMana
            p.attack = attack
            p.defence = defence
            p.will = will
            p.speed = speed
            p.lust = lust
        End If

        p.gold = gold
        p.breastSize = breastSize
        p.equippedWeapon = equippedWeapon
        Equipment.clothesChange(equippedArmor.getName)
        Equipment.accChange(equippedArmor.getName)
        p.equippedArmor = equippedArmor
        p.equippedAcce = equippedAcce
        p.prt.iArrInd = iArrInd.Clone
        p.perks = New Dictionary(Of String, Integer)(perks)
        p.inv.invNeedsUDate = invNeedsUDate
        p.prt.haircolor = haircolor
        p.prt.skincolor = skincolor
        p.TextColor = textColor
        p.prt.wingInd = wingIndex
        p.prt.hornInd = hornIndex
        p.prt.hBowInd = hBowIndex
        p.isPetrified = isPetrified
    End Sub
    'save applies a given instance of a player to a state
    Public Sub save(ByRef p As Player)
        name = p.name
        sex = p.sex
        pClass = p.classes(p.pClass.name)
        pForm = p.forms(p.pForm.name)
        description = p.description
        health = p.health
        maxHealth = p.maxHealth
        mana = p.mana
        maxMana = p.maxMana
        attack = p.attack
        defence = p.defence
        will = p.will
        speed = p.speed
        gold = p.gold
        lust = p.lust
        breastSize = p.breastSize
        hunger = p.hunger
        equippedWeapon = p.equippedWeapon
        equippedArmor = p.equippedArmor
        equippedAcce = p.equippedAcce
        iArrInd = p.prt.iArrInd.Clone
        perks = New Dictionary(Of String, Integer)(p.perks)
        invNeedsUDate = p.inv.invNeedsUDate
        haircolor = p.prt.haircolor
        skincolor = p.prt.skincolor
        textColor = p.TextColor
        wingIndex = p.prt.wingInd
        hornIndex = p.prt.hornInd
        hBowIndex = p.prt.hBowInd
        isPetrified = p.isPetrified
    End Sub

    'read converts a string given from a save file into a state
    Public Sub read(ByVal s As String)
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
            defence = 0
            will = 0
            speed = 0
            gold = 0
            lust = 0
            breastSize = 0
            hunger = 0
            equippedWeapon = New BareFists
            equippedArmor = New Naked
            iArrInd = {New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False), New Tuple(Of Integer, Boolean, Boolean)(2, False, False)}
            perks = New Dictionary(Of String, Integer)()
            invNeedsUDate = False
            haircolor = Color.Black
            skincolor = Color.Black
            textColor = Color.Black
            Exit Sub
        End If

        name = readArray(0)
        pClass = Game.player.classes(readArray(1).Split("~")(0))
        pForm = Game.player.forms(readArray(1).Split("~")(1))
        description = readArray(2)
        health = CDbl(readArray(3))
        maxHealth = CInt(readArray(4))
        mana = CInt(readArray(5))
        maxMana = CInt(readArray(6))
        If Not readArray(7).Equals("placehold") Then wingIndex = CInt(readArray(7)) Else wingIndex = 0
        If Not readArray(20).Equals("placeholder") Then hornIndex = CInt(readArray(20)) Else hornIndex = 0
        attack = CInt(readArray(10))
        defence = CInt(readArray(11))
        will = CInt(readArray(12))
        speed = CInt(readArray(13))
        If Not readArray(14).Equals("placeholder") Then isPetrified = CBool(readArray(14))
        hunger = CInt(readArray(15))
        gold = CInt(readArray(16))

        For Each k In Equipment.aList.Keys
            If readArray(17).Equals(k) Then
                equippedArmor = Equipment.aList(k)
                Exit For
            End If
        Next
        For Each k In Equipment.wList.Keys
            If readArray(18).Equals(k) Then
                equippedWeapon = Equipment.wList(k)
                Exit For
            End If
        Next

        sex = readArray(19)

        breastSize = CInt(readArray(21))

        Dim A = 255
        If Not readArray(8).Equals("placehold") Then A = readArray(8)
        haircolor = Color.FromArgb(A, CInt(readArray(22)), CInt(readArray(23)), CInt(readArray(24)))
        A = 255
        If Not readArray(9).Equals("placehold") Then A = readArray(9)
        skincolor = Color.FromArgb(A, CInt(readArray(25)), CInt(readArray(26)), CInt(readArray(27)))
        textColor = Color.FromArgb(255, CInt(readArray(28)), CInt(readArray(29)), CInt(readArray(30)))

        hBowIndex = CInt(readArray(31))

        Dim b1 As Integer = readArray(32)
        For i = 0 To b1 - 1
            Dim kvp = readArray(33 + i).Split("!")
            perks(kvp(0)) = CInt(kvp(1))
        Next
        For i = 0 To UBound(iArrInd)
            Dim arr() As String = readArray(33 + b1 + i).Split("%")
            iArrInd(i) = New Tuple(Of Integer, Boolean, Boolean)(CInt(arr(0)), CBool(arr(1)), CBool(arr(2)))
        Next

        For Each k In Equipment.acList.Keys
            If readArray(33 + b1 + 17) = k Then
                equippedAcce = Equipment.acList(k)
                Exit For
            End If
        Next

        initFlag = True
    End Sub
    'write converts a state into a string to be put into a save file
    Public Function write() As String
        If initFlag Then
            Dim output As String = CStr(name & "*" & pClass.name & "~" & pForm.name & "*" & description & "*" & health & "*" & maxHealth & "*" & mana & "*" & maxMana & "*" & wingIndex & "*" & haircolor.A & "*" & skincolor.A & "*" & _
               attack & "*" & defence & "*" & will & "*" & speed & "*" & isPetrified & "*" & hunger & "*" & gold & "*" & equippedArmor.getName() & "*" & equippedWeapon.getName() & "*" & _
               sex & "*" & hornIndex & "*" & breastSize & "*" & haircolor.R & "*" & haircolor.G & "*" & haircolor.B & "*" & skincolor.R & "*" & skincolor.G & "*" & skincolor.B & "*" & _
               textColor.R & "*" & textColor.G & "*" & textColor.B & "*" & hBowIndex & "*")
            output += perks.Count & "*"
            For Each kvp As KeyValuePair(Of String, Integer) In perks
                output += (kvp.Key & "!" & kvp.Value & "*")
            Next
            For i = 0 To UBound(iArrInd)
                output += (iArrInd(i).Item1 & "%" & iArrInd(i).Item2 & "%" & iArrInd(i).Item3 & "*")
            Next

            output += Game.player.equippedAcce.getName & "*"
            Return output + "#"
        Else
            Return "N/A#"
        End If
    End Function

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
End Class
