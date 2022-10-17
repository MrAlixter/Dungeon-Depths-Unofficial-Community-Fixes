Public Class BrokenRemote
    Inherits Item

    Public Const ITEM_NAME As String = "Broken_Remote"

    Public Shared forms = {"Half-Gorgon", "Gynoid", "Amazon", "Mindless", "Rando", "Half-Broodmother", "Broodmother", "Minotaur Cow", "Dragon", "Succubus", "Slime", "Bimbo", "Cake", "Blob", "Horse", "Oni", "Alraune", "Minotaur Bull", "Targax", "Half-Dragon (R)", "Tigress", "Succubus (Q)", "Minotaur Cow (B)", "Inversion", "Bimbo (Gold)", "Bunny Girl", "Tigress", "Apple"}
    Public Shared selectedForm = "Rando"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 119
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 375

        '|Description|
        setDesc("This item is for testing individual transformations, and should not be in the base game")
    End Sub
    Public Overrides Sub use(ByRef p As Player)
        Dim picker = New BrokenRemotePicker
        picker.ShowDialog()
        picker.Dispose()

        Dim form = selectedForm

        Dim tfs As Dictionary(Of String, Transformation) = New Dictionary(Of String, Transformation)
        Dim tf2s As Dictionary(Of String, Action) = New Dictionary(Of String, Action)
        tfs.Add("Gynoid", New GynoidTF)
        tfs.Add("Half-Gorgon", New HGorgonTF)
        tfs.Add("Amazon", New AmazonTF)
        tfs.Add("Mindless", New MindlessTF)
        tfs.Add("Rando", New RandoTF)
        tfs.Add("Half-Broodmother", Nothing)
        tfs.Add("Minotaur Cow (B)", Nothing)
        tfs.Add("Broodmother", Nothing)
        tfs.Add("Blob", Nothing)
        tfs.Add("Horse", Nothing)
        tfs.Add("Oni", Nothing)
        tfs.Add("Tigress", Nothing)

        tf2s.Add("Minotaur Cow", AddressOf New MinotaurCowTF().step1)
        tf2s.Add("Minotaur Bull", AddressOf New MinoMTF().fulltf)
        tf2s.Add("Dragon", AddressOf New DragonTF().step1)
        tf2s.Add("Half-Dragon (R)", AddressOf DragonTF.halfDragonRTF)
        tf2s.Add("Succubus", AddressOf New SuccubusTF().step1)
        tf2s.Add("Slime", AddressOf New slimetf().step1)
        tf2s.Add("Bimbo", AddressOf New BimboTF(2, 0, 0.25, True).doubleTf)
        tf2s.Add("Cake", AddressOf New TTCCBF().step1)
        tf2s.Add("Alraune", AddressOf New AlrauneTF().fullRNDTF)
        tf2s.Add("Goth GF", AddressOf New GothGFTF().step1)
        tf2s.Add("Targax", AddressOf TargaxTF.instantTF)
        tf2s.Add("Succubus (Q)", AddressOf DarkPactTF.step1alt)
        tf2s.Add("Inversion", AddressOf InversionTF.snapTF)
        tf2s.Add("Bimbo (Gold)", AddressOf GBimboTF.snapTF)
        tf2s.Add("Bunny Girl", AddressOf DancerTF.step1)
        tf2s.Add("Apple", AddressOf FaePApple.appleTF)

        If Not tfs.ContainsKey(form) And Not tf2s.ContainsKey(form) Then Exit Sub

        If tfs.ContainsKey(form) Then
            If form.Equals("Mindless") Then
                Polymorph.transform(p, form)
                Exit Sub
            End If

            If form.Equals("Half-Broodmother") Or form.Equals("Broodmother") Or
                form.Equals("Blob") Or form.Equals("Horse") Or form.Equals("Oni") Or
                form.Equals("Half-Dragon (R)") Or form.Equals("Tigress") Or form.Equals("Minotaur Cow (B)") Then
                p.changeForm(form)
                p.drawPort()
                Exit Sub
            End If
            p.ongoingTFs.add(tfs(form))
            p.update()
        ElseIf tf2s.ContainsKey(form) Then
            tf2s(form)()
            p.drawPort()
        End If
    End Sub
End Class
