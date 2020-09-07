Public NotInheritable Class MinoDTF
    Inherits MinoFTF
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "MinoDTF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "MinoDTF"
    End Sub

    Overrides Function hairColorTF(ByRef p As Player) As Integer
        Dim rose = Color.FromArgb(p.prt.haircolor.A, 255, 240, 240)
        Dim lavender = Color.FromArgb(p.prt.haircolor.A, 255, 245, 255)
        Dim white = Color.FromArgb(p.prt.haircolor.A, 255, 255, 255)

        Dim hcs = {lavender, white, rose}

        Dim i = Int(Rnd() * hcs.Length)
        p.prt.haircolor = hcs(i)

        Return i
    End Function
    Overrides Sub tfDialogStep1(ByVal hairColorInd As Integer)
        Try
            Dim hcn = {"White", "White", "White"}
            Game.pushLblEvent("You now have " & hcn(hairColorInd) & " hair!")
        Catch ex As Exception
            Game.pushLblEvent("Your hair color has changed!")
        End Try
    End Sub

    Overrides Sub tfDialogStep2()
        Game.pushLblEvent("You have a small pair of bovine horns!")
    End Sub

    Overrides Sub earTF(ByRef p As Player)
        p.prt.setIAInd(pInd.ears, 3, True, True)
        p.wBuff -= 1
    End Sub
    Overrides Sub tfDialogStep3(ByVal tfEars As Boolean, ByVal tfHair As Boolean)
        Dim out = ""

        If tfEars Then
            out += "You now have bovine ears!  Between these and the horns, you're pretty sure you're slowly turning into some sort of cow."
        End If

        If tfHair Then
            If Not out.Equals("") Then out += DDUtils.RNRN
            out += "Your hair has lengthened considerably!"
        End If

        Game.pushLblEvent(out)
    End Sub

    Overrides Sub hairTF2(ByRef p As Player)
        p.prt.setIAInd(pInd.rearhair, 37, True, True)
        p.prt.setIAInd(pInd.midhair, 43, True, True)
        p.prt.setIAInd(pInd.fronthair, 41, True, True)
    End Sub
    Overrides Sub tfDialogStep4(ByVal dropItem As Boolean)
        Dim out = "Your hair style has changed!"

        If dropItem Then
            out += "  You lose hold of your weapon, dropping it and reverting your transformation."
        End If

        Game.pushLblEvent(out)
    End Sub

    Overrides Sub growHorns(ByRef p As Player)
        p.prt.setIAInd(pInd.horns, 10, True, False)
    End Sub
    Overrides Sub tfDialogStep5()
        Game.pushLblEvent("Your horns have gotten longer, and seem to have a more extreme curl!")
    End Sub

    Overrides Sub boobTF(ByRef p As Player)
        p.breastSize += Int(Rnd() * 2)
        p.changeSkinColor(Game.cShift(p.prt.skincolor, Color.FromArgb(255, 222, 138, 172), 35))
        MyBase.boobTF(p)
    End Sub
    Overrides Sub tfDialogStep678(ByVal bsize7 As Boolean, ByVal bsizeneg1 As Boolean, ByVal be As Boolean, ByVal mtf As Boolean)
        Dim out = ""

        If bsizeneg1 Then
            out += "You have breasts now!"
        End If

        If be Then
            out += "Your breasts jiggle quite a bit, and it seems that you've gone up a cup size or two!"
        End If

        If mtf Then
            out += DDUtils.RNRN & "You now have a pussy!"
        End If

        Game.pushLblEvent(out)
    End Sub

    Overrides Sub tfClothes(ByRef p As Player)
        p.inv.add(221, 1)
        Equipment.clothesChange("Cow_Cosplay_(Demonic)")
    End Sub
    Overrides Sub tfDialogStep9()
        Game.pushLblEvent("You are now a Cow Succubus!")
    End Sub
    Overrides Sub step9()
        Dim p As Player = Game.player1

        tfDialogStep9()

        p.deLevel(p.level)

        p.prt.setIAInd(pInd.eyes, 12, True, True)
        p.prt.setIAInd(pInd.wings, 6, True, True)

        Game.player1.pForm = p.forms("Succubus")
        Game.player1.pClass = p.classes("Bimbo")

        tfClothes(p)
    End Sub
End Class
