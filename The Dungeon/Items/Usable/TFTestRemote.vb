Public Class TFTestRemote
    Inherits item
    Sub New()
        MyBase.setName("Broken_Remote")
        MyBase.setDesc("This item is for testing individual transformations, and should not be in the base game")
        id = 119
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 375
    End Sub
    Public Overrides Sub use()
        Dim p As Player = Game.player

        Dim form = InputBox("TF to... [Half-Gorgon, Gynoid, Amazon, Mindless]:")

        Dim tfs As Dictionary(Of String, Transformation) = New Dictionary(Of String, Transformation)
        tfs.Add("Gynoid", New GynoidTF)
        tfs.Add("Half-Gorgon", New HGorgonTF)
        tfs.Add("Amazon", New AmazonTF)
        tfs.Add("Mindless", New MindlessTF)

        If Not tfs.ContainsKey(form) Then Exit Sub

        If form.Equals("Midndless") Then
            Polymorph.transform(p, form)
            Exit Sub
        End If
        p.ongoingTFs.Add(tfs(form))
        p.update()
    End Sub
End Class
