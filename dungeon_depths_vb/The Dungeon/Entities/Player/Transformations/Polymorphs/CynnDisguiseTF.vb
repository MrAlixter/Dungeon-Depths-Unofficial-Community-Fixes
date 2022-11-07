Public NotInheritable Class CynnDisguiseTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.cynndisguise

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As Player = Game.player1
        turns_until_next_step = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        DarkPactTF.createDisguise(p)
        p.changeForm(p.formStates(stateInd.succDisgState).pForm.name)

        Dim pinds() As pInd = {pInd.wings, pInd.horns, pInd.tail, pInd.rearhair, pInd.midhair, pInd.fronthair, pInd.ears, pInd.mouth}

        For Each pi In pinds
            p.prt.setIAInd(pi, p.formStates(stateInd.succDisgState).iArrInd(pi).Item1, p.formStates(stateInd.succDisgState).iArrInd(pi).Item2, p.formStates(stateInd.succDisgState).iArrInd(pi).Item3)
        Next

        p.prt.haircolor = p.formStates(stateInd.succDisgState).getHairColor()
        p.prt.skincolor = p.formStates(stateInd.succDisgState).getSkinColor()
    End Sub
End Class
