Public MustInherit Class Entity
    Implements Updatable

    Public name As String
    Public health As Double = 1.0 'represents a percentage of maxhealth
    Public maxHealth, mana, maxMana, attack, defence, will, speed, gold, lust As Integer
    Public hBuff As Integer = 0     'buffs that apply across forms (from charms, etc)
    Public mBuff As Integer = 0
    Public aBuff As Integer = 0
    Public dBuff As Integer = 0
    Public wBuff As Integer = 0
    Public sBuff As Integer = 0

    Public inv As Inventory

    Public pos As Point
    Public canMoveFlag As Boolean = True
    Public forcedPath() As Point = Nothing

    Public isDead As Boolean = False

    Public nextCombatAction As Action(Of Entity) = Nothing
    Public currTarget As Entity = Nothing

    '|MOVEMENT COMMANDS|
    MustOverride Sub reachedFPathDest()
    Private Sub followPath()
        If forcedPath.Length <= 1 Then
            reachedFPathDest()
            forcedPath = Nothing
        Else
            Dim t(UBound(forcedPath) - 1) As Point
            pos = forcedPath(0)
            For i = 1 To UBound(forcedPath)
                t(i - 1) = forcedPath(i)
            Next
            forcedPath = t
        End If
    End Sub
    Public Sub moveUp()
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If
        If (pos.Y - 1) < 0 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y - 1, pos.X).Tag = 0 Then Exit Sub
        pos.Y -= 1
    End Sub
    Public Sub moveDown()
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If
        If (pos.Y + 1) > Game.mBoardHeight - 1 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y + 1, pos.X).Tag = 0 Then Exit Sub
        pos.Y += 1
    End Sub
    Public Sub moveLeft()
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If
        If (pos.X - 1) < 0 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y, pos.X - 1).Tag = 0 Then Exit Sub
        pos.X -= 1
    End Sub
    Public Sub moveRight()
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If
        If (pos.X + 1) > Game.mBoardWidth - 1 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y, pos.X + 1).Tag = 0 Then Exit Sub
        pos.X += 1
    End Sub

    '|UPDATE|
    Public Overridable Sub update() Implements Updatable.update
        If getIntHealth() <= 0 Then die(Nothing)
        If Not nextCombatAction Is Nothing And Not currTarget Is Nothing Then
            nextCombatAction(currTarget)
            nextCombatAction = Nothing
        End If
    End Sub

    '|DEATH|
    Public MustOverride Sub die(ByRef cause As Entity)
    Public Sub die()
        die(Nothing)
    End Sub

    '|COMBAT|
    Public MustOverride Sub attackCMD(ByRef target As Entity)
    Public Overridable Sub takeDMG(ByVal dmg As Integer, ByRef source As Entity)
        If dmg >= getIntHealth() Then die(source)
        health -= dmg / getMaxHealth()
    End Sub
    Public Shared Function calcDamage(atk As Integer, def As Integer) As Integer
        If atk <= 0 Then Return 1
        If def <= 0 Then Return atk
        Return atk * (atk / (atk + def))
    End Function

    '|GETTERS|
    Public Overridable Function getName() As String
        Return name
    End Function
    Public Overridable Function getHealth() As Double
        Return health
    End Function
    Public Overridable Function getIntHealth() As Integer
        Return health * getMaxHealth()
    End Function
    Public Overridable Function getMaxHealth() As Integer
        Return maxHealth + hBuff
    End Function
    Public Overridable Function getMana() As Integer
        Return mana
    End Function
    Public Overridable Function getMaxMana() As Integer
        Return maxMana + mBuff
    End Function
    Public Overridable Function getATK() As Integer
        Return attack + aBuff
    End Function
    Public Overridable Function getDEF() As Integer
        Return defence + dBuff
    End Function
    Public Overridable Function getWIL() As Integer
        Return will + wBuff
    End Function
    Public Overridable Function getSPD() As Integer
        Return speed + sBuff
    End Function
    Public Overridable Function getGold() As Integer
        Return gold
    End Function
    Public Overridable Function getLust() As Integer
        Return lust
    End Function

    '|SETTERS|
    Public Overridable Sub setName(ByVal n As String)
        name = n
    End Sub
    Public Overridable Sub setHealth(ByVal h As Double)
        health = h
    End Sub
    Public Overridable Sub setHealth(ByVal h As Integer)
        health = h / getMaxHealth()
    End Sub
    Public Overridable Sub setMaxHealth(ByVal h As Integer)
        maxHealth = h
    End Sub
    Public Overridable Sub setMana(ByVal m As Integer)
        mana = m
    End Sub
    Public Overridable Sub setMaxMana(ByVal m As Integer)
        maxMana = m
    End Sub
    Public Overridable Sub setATK(ByVal a As Integer)
        attack = a
    End Sub
    Public Overridable Sub setDEF(ByVal d As Integer)
        defence = d
    End Sub
    Public Overridable Sub setWIL(ByVal w As Integer)
        will = w
    End Sub
    Public Overridable Sub setSPD(ByVal s As Integer)
        speed = s
    End Sub
    Public Overridable Sub setGold(ByVal g As Integer)
        gold = g
    End Sub
    Public Overridable Sub setLust(ByVal l As Integer)
        lust = l
    End Sub
End Class
