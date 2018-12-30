Public Class RandoSlimeTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "RandoTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "RandoTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()
        Randomize()

        'assign a pointer to the player character
        Dim p As player = game.player

        'assign a random starter class
        Dim classes = {"Warrior", "Mage", "Paladin", "Warrior", "Mage", "Bimbo"}
        p.pClass = p.classes(classes(Int(Rnd() * classes.Length)))

        'assign a random sex
        If Int(Rnd() * 2) = 0 Then
            p.sex = "Female"
            p.sexBool = True
            p.breastSize = Int(Rnd() * 3) + 1
        Else
            p.sex = "Male"
            p.sexBool = False
            p.breastSize = -1
        End If

        'assign random stats
        p.health = 1.0
        p.maxHealth = 70 + Int(Rnd() * 50)
        p.mana = Int(Rnd() * 7)
        p.maxMana = CInt(p.mana.ToString)
        p.attack = 5 + Int(Rnd() * 7)
        p.defence = 5 + Int(Rnd() * 7)
        p.will = 5 + Int(Rnd() * 7)
        p.speed = 5 + Int(Rnd() * 7)
        p.gold = 25 + Int(Rnd() * 200)
        p.lust = 0
        p.hunger = 0
        p.hBuff = 0
        p.mBuff = 0
        p.wBuff = 0
        p.aBuff = 0
        p.dBuff = 0

        'set a random hair color
        p.haircolor = Color.FromArgb(180, 5, 245, 198)
        'set a random skin color
        p.skincolor = Color.FromArgb(200, 0, 255, 255)


        'set the rest of the portrait randomly
        Dim r As Integer = Int(Rnd() * 5)
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(r, True)
        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(r, True)
        r = Int(Rnd() * 5)
        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(r, True)
        p.iArrInd(6) = New Tuple(Of Integer, Boolean)(5, True)
        p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        r = Int(Rnd() * 3)
        If r = 1 Then r = 4
        p.iArrInd(8) = New Tuple(Of Integer, Boolean)(r, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(9, True)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(11) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(12) = New Tuple(Of Integer, Boolean)(0 + (2 * Int(Rnd() * 3)), True)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(14) = New Tuple(Of Integer, Boolean)(0, True)
        r = Int(Rnd() * 4) + 1
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(r, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
        If Not p.sexBool Then
            p.idRouteFM()
        End If

        'clear all player associated lists
        Game.Potions.Clear()
        p.createInvPerks()
        Game.loadPotionList()

        'assign random equipment
        Dim armor = New Integer() {5, 7, 12, 16, 17, 18, 19, 20, 38, 39, 46, 47, 54, 54}
        Dim armorIndex = armor(Int(Rnd() * (armor.Length)))
        Dim weapon = New Integer() {6, 9, 21, 22}
        Dim weaponIndex = weapon(Int(Rnd() * (weapon.Length)))
        p.inv.add(armorIndex, 1)
        p.inv.add(weaponIndex, 1)
        p.equippedArmor = CType(p.inv.item(armorIndex), Armor)
        p.equippedWeapon = CType(p.inv.item(weaponIndex), Weapon)

        'set other player stuff
        p.TextColor = Color.FromArgb(255, 2, 249, 200)
        If Game.floor < 6 Then p.pImage = Game.picPlayer.BackgroundImage Else p.pImage = Game.picPlayerf.BackgroundImage
        p.bsizeroute()
        Dim si As Integer = p.sState.iArrInd(3).Item1
        p.currState.save(p)
        p.pState.save(p)
        p.sState.save(p)
        p.sState.iArrInd(3) = New Tuple(Of Integer, Boolean)(si, True)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
