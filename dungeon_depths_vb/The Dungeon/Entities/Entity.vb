Public MustInherit Class Entity
    Implements Updatable

    Public name, sName As String
    Public health As Double = 1.0 'represents a percentage of maxhealth
    Public maxHealth, mana, maxMana, attack, defense, will, speed, gold, lust As Integer
    Public level As Integer
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
    Protected Sub followPath()
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
    Public Overridable Sub move(ByVal newX, ByVal newY)
        '|-Forced Path-|
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If

        '|-NPC Encounter Movement Freeze-|
        If Game.shop_npc_engaged Then Exit Sub

        '|-Other Movement Freezes-|
        If canMoveFlag = False Then Exit Sub

        '|-Edge of the Map-|
        If newY < 0 Or newY > Game.currFloor.mBoardHeight - 1 Or newX < 0 Or newX > Game.currFloor.mBoardWidth - 1 Then Exit Sub

        Dim board = Game.currFloor.mBoard

        '|-Other Wall-|
        If board(newY, newX).Tag = 0 Then Exit Sub

        '|-Move-|
        pos = New Point(newX, newY)
    End Sub
    Public Sub moveUp()
        move(pos.X, pos.Y - 1)
    End Sub
    Public Sub moveDown()
        move(pos.X, pos.Y + 1)
    End Sub
    Public Sub moveLeft()
        move(pos.X - 1, pos.Y)
    End Sub
    Public Sub moveRight()
        move(pos.X + 1, pos.Y)
    End Sub

    '|UPDATE|
    Public Overridable Sub update() Implements Updatable.update
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
        If dmg >= getIntHealth() Then
            die(source)
        Else
            health -= dmg / getMaxHealth()
        End If
    End Sub
    Public Overridable Sub takeCritDMG(ByVal dmg As Integer, ByRef source As Entity)
        If dmg >= getIntHealth() Then
            die(source)
        Else
            health -= dmg / getMaxHealth()
        End If
    End Sub
    Public Shared Function calcDamage(atk As Integer, def As Integer) As Integer
        If atk <= 0 Then Return 1
        If def <= 0 Then Return atk
        Return atk * (atk / (atk + def))
    End Function
    Public Overridable Function getSpellDamage(ByRef target As Entity, ByVal dmg As Integer) As Integer
        'target.takeDMG(calcDamage(dmg * (will / 10), target.getWIL), Me)
        Return calcDamage(dmg + (Math.Max(will - 10, -10)), target.getWIL)
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
        Return defense + dBuff
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
    Public Function getSName() As String
        Return sName
    End Function
    Public Function getPlayer() As Player
        Return If(Me.GetType Is GetType(Player), CType(Me, Player), Nothing)
    End Function
    Public Function getNPC() As NPC
        Return If(Me.GetType.IsSubclassOf(GetType(NPC)), CType(Me, NPC), Nothing)
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
        defense = d
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
    Public Overridable Sub addLust(ByVal i As Integer)
        lust += i
    End Sub
End Class
