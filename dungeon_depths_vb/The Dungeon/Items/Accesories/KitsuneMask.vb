Public Class KitsuneMask
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        MyBase.setName("Kitsune_Mask")
        MyBase.setDesc("A snazzy mask that invokes image of a guardian of a long forgotten shrine. A closer look reveals a smudged riddle inscribed in an shifting script..." & vbCrLf & vbCrLf & _
                       """ " & vbCrLf & _
                       "Forest's Watcher Be Revealed""" & vbCrLf & vbCrLf & _
                       "+15 Mana" & vbCrLf & _
                       "+20 Speed" & vbCrLf & _
                       "+15 Will")
        id = 198
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 0

        mBoost = 15
        sBoost = 20
        wBoost = 15

        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks("blind") = 1
        If Not p.pForm.name.Equals("Kitsune") Then p.ongoingTFs.Add(New KitsuneTF())
        p.update()
        Game.drawBoard()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.perks("blind") = -1
        Game.drawBoard()
    End Sub

    Public Overrides Function getTier() As Integer
        Try
            Select Case Game.mDun.numCurrFloor
                Case Is < 5
                    Return Nothing
                Case 7
                    Return 1
                Case Else
                    Return 3
            End Select
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
