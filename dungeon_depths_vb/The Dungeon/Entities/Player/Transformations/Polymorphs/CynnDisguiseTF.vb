Public NotInheritable Class CynnDisguiseTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "CynnDisguiseTF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
        tfName = "CynnDisguiseTF"
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As Player = Game.player1
        turnsTilNextStep = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        p.changeForm(p.succDisgState.pForm.name)

        Dim pinds() As pInd = {pInd.wings, pInd.horns, pInd.tail, pInd.rearhair, pInd.midhair, pInd.fronthair, pInd.ears, pInd.mouth}

        For Each pi In pinds
            p.prt.setIAInd(pi, p.succDisgState.iArrInd(pi).Item1, p.succDisgState.iArrInd(pi).Item2, p.succDisgState.iArrInd(pi).Item3)
        Next

        p.prt.haircolor = p.succDisgState.getHairColor()
        p.prt.skincolor = p.succDisgState.getSkinColor()
    End Sub
End Class
