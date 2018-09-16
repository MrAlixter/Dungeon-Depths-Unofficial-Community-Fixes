Public Class TargaxTF
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

    Shared Sub step1()
        Dim p = Game.player
        If (p.iArrInd(9).Item2 And p.iArrInd(9).Item1 <> 15) Or (Not p.iArrInd(9).Item2 And p.iArrInd(9).Item1 <> 8) Then
            If p.iArrInd(9).Item2 Then
                p.iArrInd(9) = New Tuple(Of Integer, Boolean)(15, True)
            Else
                p.iArrInd(9) = New Tuple(Of Integer, Boolean)(7, False)
            End If
            Game.pushLblEvent("As you cut down your most recent foe, you take a second to examine the sword you pulled off of Targax.  No doubt, this is one of the most powerful weapons you have seen let alone handled, and as it glints crimson you grin at the potential power you could seize with it.")
        End If
        p.createP()
    End Sub
    Shared Sub step2()
        Dim p = Game.player
        If (p.iArrInd(15).Item2 And p.iArrInd(15).Item1 <> 12) Or (Not p.iArrInd(15).Item2 And p.iArrInd(15).Item1 <> 6) Then
            If p.iArrInd(2).Item2 Then
                p.iArrInd(1) = New Tuple(Of Integer, Boolean)(13, True)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean)(15, True)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean)(12, True)
            Else
                p.iArrInd(1) = New Tuple(Of Integer, Boolean)(5, False)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean)(5, False)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean)(6, False)
            End If
            p.haircolor = Color.FromArgb(255, 128, 0, 0)
            p.pClass = p.classes("Targaxian")
            Game.pushLblEvent("As another foe meets its demise at your, no, Targax's blade, you have a brief sense of regret that you defeated him.  Who knows what you could have gained from an alliance with him. ""Oh well, back to the slaughter.""")
        End If
        p.createP()
    End Sub
    Shared Sub step3()
        Dim p = Game.player
        p.name = "Targax"
        p.pClass = p.classes("Soul-Lord")
        Game.pushLblEvent("You jolt out of the trance you've been in for a unknown period of time, and stare in awe at the ornate glyphs that you have apperantly carved in the ground.  ""What the hell did I ..."" when the voice in your head returns, asking ""Do you accept?"".  ""Do I accept what?"" you demand, to which the voice in your head simply repeats the question.  About to firmly decline whatever nonsense your mental passenger is getting at, you are cut short by a thundering ""DO YOU ACCEPT"".  Your eyes space out and you answer your master the only way you can." & vbCrLf & vbCrLf & """Yes Master.""")
        p.iArrInd(8) = New Tuple(Of Integer, Boolean)(11, True)
        p.createP()
        p.sState.save(p)
        p.pState.save(p)
    End Sub
End Class
