Public Class KitsuneMask
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Kitsune_Mask")
        id = 198
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 777
        m_boost = 15
        s_boost = 20
        w_boost = 15


        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)

        '|Description|
        setDesc("A snazzy mask that invokes image of a guardian of a long forgotten shrine. A closer look reveals a smudged riddle inscribed in an shifting script..." & DDUtils.RNRN & _
                """The guise of the Fox" & vbCrLf &
                " Worn while in the clutch of flame" & vbCrLf &
                " Gives legends new life...""" & DDUtils.RNRN &
                getStatInformation())

    End Sub
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

    Public Overrides Function getTier() As Integer
        Try
            Select Case Game.mDun.numCurrFloor
                Case Is < 7
                    Return Nothing
                Case Else
                    Return 3
            End Select
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
