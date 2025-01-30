Public Class Item
    Implements IComparable

    '| -- Constructor Layout Example -- |
    '|ID Info|


    '|Item Flags|


    '|Stats|


    '|Description|


    Dim name As String = ""
    Dim description As String
    Protected usable As Boolean = False
    Public count As Integer
    Public value As Integer
    Protected tier As Integer = Nothing
    Public id As Integer = -1

    Public npc_drop_only As Boolean = False
    Public rando_inv_allowed = True
    Public can_be_stolen As Boolean = True
    Public only_drop_one As Boolean = False
    Public list_in_shop As Boolean = True
    Public list_in_debug As Boolean = True
    Public stores_inanimate_ent As Boolean = False

    Public saleLim As Integer = 999
    Public onSell As Action = Nothing
    Public onBuy As Action = Nothing
    Public durability As Integer = 100
    Private inanimate_ent As InanimateEntity = Nothing

    '| -- Comparable -- |
    Overloads Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        If Not obj.GetType().IsSubclassOf(GetType(Item)) Or obj Is Nothing OrElse obj.getname Is Nothing OrElse Me.getName Is Nothing Then Return 0

        Return Me.getName.CompareTo(obj.getName.ToString)
    End Function

    '| -- Getters/Setters -- |
    Overridable Function getName() As String
        Return name
    End Function
    Function getAName() As String
        Return name
    End Function
    Sub setName(ByVal s As String)
        name = s
    End Sub

    Public Overridable Function getDescription()
        Return description
    End Function
    Sub setDesc(ByVal s As String)
        description = s
    End Sub

    Public Overridable Function getInanimateEnt(Optional ByVal useSessionID As Boolean = False) As InanimateEntity
        If stores_inanimate_ent And inanimate_ent Is Nothing Then
            loadInanimateEntity(useSessionID)
        End If

        Return inanimate_ent
    End Function
    Public Overridable Sub setInanimateEnt(ByRef ent As InanimateEntity, ByRef source As Entity)
        inanimate_ent = ent
    End Sub

    Public Overridable Function getTier(ByVal floor_num As Integer) As Integer
        Return tier
    End Function
    Public Overridable Function getId()
        Return id
    End Function
    Public Overridable Function getValue() As Integer
        Return value
    End Function
    Public Overridable Function getUsable() As Boolean
        Return usable
    End Function


    '| -- Inventory -- |
    Sub addOne()
        add(1)
    End Sub
    Overridable Sub add(ByVal i As Integer)
        'If stores_inanimate_ent Then If Not inanimate_ent Is Nothing Then i = 0
        count += i
    End Sub
    Overridable Sub discard()
        TextEvent.pushLog("You drop the " & getName())
        count -= 1
    End Sub
    Overridable Sub remove()
        TextEvent.pushLog("The " & getName() & " fades into non-existence")
        count -= 1

    End Sub

    '| -- Player Interaction -- |
    Overridable Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName())
    End Sub
    Overridable Function damage(ByVal i As Integer) As Boolean
        durability -= i
        If durability <= 0 Then
            break()
            Return True
        End If
        Return False
    End Function
    Overridable Sub break()
        Dim p = Game.player1

        TextEvent.pushLog("The " & getName() & " breaks!")

        p.inv.add(id, -1)
        p.inv.item(id).durability = 100

        Game.player1.UIupdate()
    End Sub

    '| -- Misc. -- |
    Public Overridable Sub examine()
        If durability > 99 Then
            TextEvent.push(getDescription())
        Else
            TextEvent.push(getDescription() & DDUtils.RNRN & "Durability: " & durability & " (Breaks at 0)")
        End If
    End Sub
    Public Overridable Sub toSavedItem(ByRef ent As Entity)
        Dim output = CStr(
            ent.name & "*" &
            getAName() & "*" &
            id & "*" &
            Game.sessionID & "*" &
            Game.currFloor.floorCode & "*" &
            ent.health & "*" &
            ent.getMaxHealth() & "*" &
            ent.getMaxMana() & "*" &
            ent.getATK() & "*" &
            ent.getDEF() & "*" &
            ent.getSPD() & "*" &
            ent.getWIL() & "*")

        Dim writer As IO.StreamWriter
        Dim filename As String = "items\" & Game.sessionID & "_" & id & ".itm"
        IO.File.Delete(filename)
        writer = IO.File.CreateText(filename)
        writer.WriteLine(output)
        writer.Flush()
        writer.Close()
    End Sub
    Public Overridable Sub loadSavedItem(ByVal sessionID As String, ByVal itmid As Integer)
        Dim filename As String = "items\" & sessionID & "_" & itmid & ".itm"

        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(filename)

        Try
            'TO DO per item

            'saved name     - 0
            'item name      - 1
            'item id        - 2
            'session id     - 3
            'floor code     - 4
            'health         - 5
            'max health     - 6
            'max mana       - 7
            'ATK            - 8
            'DEF            - 9
            'SPD            - 10
            'WIL            - 11
        Finally
            reader.Close()
        End Try
    End Sub
    Private Sub loadInanimateEntity(ByVal useSessionID As Boolean)
        If useSessionID AndAlso System.IO.File.Exists("items\" & Game.sessionID & "_" & id & ".itm") Then
            inanimate_ent = InanimateEntity.loadFromFile(id, Game.sessionID)
        ElseIf Not useSessionID AndAlso DDUtils.fileExistsWC("items\", "*_" & id & ".itm") Then
            inanimate_ent = InanimateEntity.loadFromFile(id)
        End If
    End Sub
End Class
