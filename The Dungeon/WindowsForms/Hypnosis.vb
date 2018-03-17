Public Class Hypnosis
    Public target As Monster
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboxComand.Text = "-- Select --" Or (cboxForm.Visible = True And cboxForm.Text = "-- Select --") Then Exit Sub

        If cboxComand.Text = "become your ally" Then
            toAlly(target)
        ElseIf cboxComand.Text = "change their perspective" Then
            toChangeP(target)
        ElseIf cboxComand.Text = "give you a 'discount'" Then
            discount(target)
        ElseIf cboxComand.Text = "never come back" Then
            leaveForever(target)
        End If
        Game.dialogOpen = False
        Me.Close()
    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboxComand.Items.Add("become your ally")
        cboxComand.Items.Add("change their perspective")
        If target.GetType() Is GetType(NPC) Then cboxComand.Items.Add("give you a 'discount'")
        cboxComand.Items.Add("never come back")

        cboxForm.Items.Add("female")
        cboxForm.Items.Add("male")
        cboxForm.Items.Add("cat maid")
    End Sub
    Private Sub cboxComand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxComand.SelectedIndexChanged
        If cboxComand.Text = "change their perspective" Then
            cboxForm.Visible = True
            Label3.Visible = True
        Else
            cboxForm.Visible = False
            Label3.Visible = False
        End If
    End Sub

    Public Sub toAlly(ByRef t As Monster)

    End Sub
    Public Sub toChangeP(ByRef t As Monster)

    End Sub
    Public Sub discount(ByRef t As NPC)
        t.discount = True
    End Sub
    Public Sub leaveForever(ByRef t As Monster)

    End Sub

    Sub transformN(ByRef t As NPC)
        Dim title As String = cboxForm.Text
        If title = "female" Then
            t.npcIndex = 9
            t.toFemale("")
        ElseIf title = "male" Then
            t.npcIndex = 12
            t.toMale("")
        ElseIf title = "cat maid" Then
            t.health = 500
            t.maxHealth = 500
            t.attack = 75
            t.defence = 75
            t.npcIndex = 14
            t.toFemale("cat maid")
            t.form = "Cat Maid"
            Game.NPCfromCombat(t)
        End If
        Game.npcIndex = t.npcIndex
    End Sub
End Class