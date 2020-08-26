Public NotInheritable Class TargaxTF
    Inherits Transformation
    
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Targax"
        nextStep = Nothing
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Targax"
        nextStep = Nothing
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Return Nothing
    End Function
    Shared Sub step1()
        Dim p As Player = Game.player1
        If Not p.prt.checkNDefFemInd(pInd.eyes, 15) And Not p.prt.checkNDefMalInd(pInd.eyes, 7) Then
            If p.prt.iArrInd(pInd.eyes).Item2 Then
                p.prt.setIAInd(pInd.eyes, 15, True, True)
            Else
                p.prt.setIAInd(pInd.eyes, 7, False, True)
            End If
            Game.pushLblEvent("As you cut down your most recent foe, you take a second to examine the sword you pulled off of Targax.  No doubt, this is one of the most powerful weapons you have seen let alone handled, and as it glints crimson you grin at the potential power you could seize with it.")
        End If
        p.drawPort()
    End Sub
    Shared Sub step2()
        Dim p As Player = Game.player1
        If Not p.prt.checkNDefMalInd(pInd.fronthair, 6) Then
            p.prt.setIAInd(pInd.rearhair, 5, False, True)
            p.prt.setIAInd(pInd.midhair, 5, False, True)
            p.prt.setIAInd(pInd.fronthair, 6, False, True)

            p.prt.haircolor = Color.FromArgb(255, 128, 0, 0)
            p.pClass = p.classes("Targaxian")
            Game.pushLblEvent("As another foe meets its demise at your, no, Targax's blade, you have a brief sense of regret that you defeated him.  Who knows what you could have gained from an alliance with him. ""Oh well, back to the slaughter.""")
        End If
        p.drawPort()
    End Sub
    Shared Sub step3()
        Dim p As Player = Game.player1
        p.name = "Targax"
        p.pClass = p.classes("Soul-Lord")
        Game.pushLblEvent("You jolt out of the trance you've been in for a unknown period of time, and stare in awe at the ornate glyphs that you have apperantly carved in the ground.  ""What the hell did I ..."" when the voice in your head returns, asking ""Do you accept?"".  ""Do I accept what?"" you demand, to which the voice in your head simply repeats the question.  About to firmly decline whatever nonsense your mental passenger is getting at, you are cut short by a thundering ""DO YOU ACCEPT"".  Your eyes space out and you answer your master the only way you can." & vbCrLf & vbCrLf & """Yes Master.""")
        p.prt.setIAInd(pInd.mouth, 8, False, True)
        p.drawPort()
        p.sState.save(p)
        p.pState.save(p)
    End Sub


    Shared Sub instantTF()
        Dim p As Player = Game.player1
        p.name = "Targax"
        p.pClass = p.classes("Soul-Lord")

        If p.prt.iArrInd(pInd.eyes).Item2 Then
            p.prt.setIAInd(pInd.eyes, 15, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 7, False, True)
        End If
        p.prt.setIAInd(pInd.rearhair, 5, False, True)
        p.prt.setIAInd(pInd.midhair, 5, False, True)
        p.prt.setIAInd(pInd.fronthair, 6, False, True)
        p.prt.setIAInd(pInd.mouth, 8, False, True)

        p.prt.haircolor = Color.FromArgb(255, 128, 0, 0)
        p.drawPort()
    End Sub
End Class
