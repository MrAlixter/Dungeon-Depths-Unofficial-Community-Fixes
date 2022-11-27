Public NotInheritable Class PlantfolkTF
    Inherits OneStepTF

    Dim summerColor As Color = Color.FromArgb(255, 55, 146, 46)
    Dim springColor As Color = Color.FromArgb(255, 204, 254, 158)
    Dim fallColor As Color = Color.FromArgb(255, 226, 121, 5)
    Dim winterColor As Color = Color.FromArgb(255, 233, 228, 228)

    Private Const TF_IND As tfind = tfind.plantfolk

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub step1()
        Dim p As player = Game.player1
        Dim out = ""

        p.changeForm("Plantfolk")

        If DDDateTime.isWinter Then
            p.changeHairColor(winterColor)
        ElseIf DDDateTime.isSpring Then
            p.changeHairColor(springColor)
        ElseIf DDDateTime.isSummer Then
            p.changeHairColor(summerColor)
        ElseIf DDDateTime.isFall Then
            p.changeHairColor(fallColor)
        End If

        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.rearhair, 6, False, True)
            p.prt.setIAInd(pInd.midhair, 6, False, True)
            p.prt.setIAInd(pInd.fronthair, 7, False, True)
        Else
            p.prt.setIAInd(pInd.rearhair, 21, True, True)
            p.prt.setIAInd(pInd.midhair, 24, True, True)
            p.prt.setIAInd(pInd.fronthair, 22, True, True)
        End If

        p.changeSkinColor(DDUtils.cShift(p.prt.skincolor, summerColor, 50))


        'transformation description push
        out += "As you chew on a particularly leafy portion of the salad, you feel the familiar flow of transformative magic flow through your body!  Expecting the worse, you are suprised to find that it seems to be providing your body with a benevolent energy.  It isn't until a leaf droops down from the top of your head that you realize something has indeed been changed.  You are now a plantfolk."
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        TextEvent.push(out)
    End Sub
End Class
