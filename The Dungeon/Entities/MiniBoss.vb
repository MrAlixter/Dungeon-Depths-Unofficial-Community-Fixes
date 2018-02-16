Public Class MiniBoss
    Inherits Monster
    Sub New(ByVal mIndex As Integer)
        MyBase.New(-1)
        Select Case mIndex
            Case 1
                MyBase.name = "Marissa the Enchantress"
                MyBase.health = 150
                MyBase.maxHealth = 150
                MyBase.attack = 15
                MyBase.defence = -5
                MyBase.speed = 10  '0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15
                MyBase.inventory = {0, 0, 3, 0, 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1}
                title = ""
                pronoun = "she"
                pPronoun = "her"
                rPronoun = "her"
            Case 2
                MyBase.name = "Targax the Brutal"
                MyBase.health = 250
                MyBase.maxHealth = 250
                MyBase.attack = 60
                MyBase.defence = 10
                MyBase.speed = 5   '0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24
                MyBase.inventory = {0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}
                title = ""
                pronoun = "he"
                pPronoun = "his"
                rPronoun = "him"
            Case Else
                MyBase.name = "Explorer"
                MyBase.health = 300
                MyBase.maxHealth = 300
                MyBase.attack = 15
                MyBase.defence = 15
                MyBase.speed = 15
                ReDim MyBase.inventory(Game.player.inventorynames.Count - 1)
                Randomize()
                For i = 0 To 5
                    Dim invInd As Integer = 8
                    While invInd = 8 Or invInd = 10 Or invInd = 24 Or invInd = 53
                        invInd = Int(Rnd() * Game.player.inventorynames.Count)
                    End While
                    MyBase.inventory(invInd) = (Int(Rnd() * 2) + 1)
                Next
        End Select
        If speed = Game.player.speed Then speed -= 1
        MyBase.sName = getName()
        MyBase.pos = Game.player.pos
    End Sub
    Sub New(ByVal s As String)
        MyBase.New(-1)
        Dim playArray() As String = s.Split("*")
        MyBase.name = playArray(0) & " the " & playArray(1)
        MyBase.health = playArray(3)
        MyBase.maxHealth = playArray(4)
        MyBase.attack = playArray(5)
        MyBase.defence = playArray(6)
        MyBase.speed = playArray(7)
        ReDim MyBase.inventory(UBound(playArray) - 8)
        For i = 0 To (UBound(playArray) - 8)
            MyBase.inventory(i) = playArray(8 + i)
        Next
    End Sub
    Public Overrides Sub attackCMD(target As Player)
        Game.player.currTarget = Me
        If name.Equals("Marissa the Enchantress") Then
            Dim r As Integer = 1 ' CInt(Int(Rnd() * 10))
            If r = 1 And Game.player.perks("nekocurse") = -1 Then
                Game.lstLog.Items.Add((getName() & " casts a curse on you!"))
                Game.pushLblCombatEvent((getName() & " casts a curse on you!"))
                Game.player.perks("nekocurse") = 0
                'attack = 0
            ElseIf Game.player.perks("nekocurse") > -1 And health < 45 Then
                Game.lstLog.Items.Add((getName() & " heals herself!  +35 health!"))
                Game.pushLblCombatEvent((getName() & " heals herself for 35 health!"))
                takeDMG(-35)
                ' attack = 0
            ElseIf Game.player.health < 20 Then
                Game.lstLog.Items.Add((getName() & " waits expectantly . . ."))
                Game.pushLblCombatEvent((getName() & " waits expectantly . . ."))
            Else
                MyBase.attackCMD(target)
                'attack = 20
            End If
        Else
            MyBase.attackCMD(target)
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
