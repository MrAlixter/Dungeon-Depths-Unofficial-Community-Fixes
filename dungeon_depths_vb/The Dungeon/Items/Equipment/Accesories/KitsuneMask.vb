Public Class KitsuneMask
    Inherits Accessory

    Public Const ITEM_NAME As String = "Kitsune_Mask"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 198
        tier = 3

        '|Item Flags|
        usable = False
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 1554
        m_boost = 15
        s_boost = 20
        w_boost = 15


        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)

        '|Description|
        setDesc("A snazzy mask that invokes image of a guardian of a long forgotten shrine. A closer look reveals a smudged riddle inscribed in an shifting script..." & DDUtils.RNRN & _
                """The guise of the Fox" & vbCrLf &
                " Worn while in the clutch of flame" & vbCrLf &
                " Gives legends new life...""" & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return Nothing
            Case LootTable.bracket.f14fXX
                Return Nothing
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.blind) = 1

        If Not p.formName.Equals("Kitsune") AndAlso p.perks(perk.burn) > -1 Then
            p.ongoingTFs.Add(New KitsuneTF())
            p.perks(perk.burn) = -1
        End If

        p.update()
        Game.drawBoard()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.perks(perk.blind) = -1
        Game.drawBoard()
    End Sub
End Class
