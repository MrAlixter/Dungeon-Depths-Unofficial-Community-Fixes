'The Transformation class will be used to handle a (sequence of) tranformation(s) of the player from one "permenant"
'state to another.

Public Class Transformation
    Implements Updatable
    Protected currStep As Integer
    Protected numSteps As Integer
    Protected turnsTilNextStep As Integer
    Protected nextStep As Action
    Protected wilImpact As Double
    Protected canBeStopped As Boolean
    Protected tfName As String
    Protected tfDone As Boolean

    'constuctors
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        Dim p As player = game.player
        If canBeTFed(p) Then
            p.pState.save(p)
        End If
        currStep = 0
        numSteps = n
        turnsTilNextStep = tts
        wilImpact = wi
        canBeStopped = cbs
        tfDone = False
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        currStep = cs
        numSteps = n
        turnsTilNextStep = tts
        wilImpact = wi
        canBeStopped = cbs
        tfDone = tfd
    End Sub

    'shared methods
    Shared Function newTF(s() As String) As Transformation
        Select Case s(5)
            Case "Bimbo"
                Return New BimboTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "NekoTF"
                Return New NekoTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "MinoFTF"
                Return New MinoFTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "Targax"
                Return New TargaxTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "ThrallTF"
                Return New ThrallTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "Magic Girl"
                Return New MagGirlTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "DragonTF"
                Return New DragonTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "GoddessTF"
                Return New GoddessTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "SlimeTF"
                Return New SlimeTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "SuccubusTF"
                Return New SuccubusTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "TigressTF"
                Return New TigressTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "HalfSuccubusTF"
                Return New HalfSuccubusTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "MinotaurCowTF"
                Return New MinotaurCowTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "Princess​TF"
                Return New PrincessTFB(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "BunnyGirl​TF"
                Return New BunnyGirlTFB(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "SheepTF"
                Return New SheepTFB(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "VialOfSlimeTF"
                Return New VialOfSlimeTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "AngelTF"
                Return New AngelTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "MaidTF"
                Return New MaidTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "BUDollTF"
                Return New BUDollTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case "PrincessTF"
                Return New PrincessTF(CInt(s(0)), CInt(s(1)), CInt(s(2)), CDbl(s(3)), CBool(s(4)), CBool(s(6)))
            Case Else
                Return Nothing
        End Select
    End Function
    Shared Function canBeTFed(ByRef p As Player) As Boolean
        If Game.player.ongoingTFs.Count < 1 And (Not p.polymorphs.ContainsKey(p.pClass.name) And Not p.polymorphs.ContainsKey(p.pForm.name)) And Not p.pClass.name.Equals("Magic Girl") And Not p.pClass.name.Equals("Unconscious") And Not p.pForm.name.Equals("Blowup Doll") Then Return True
        Return False
    End Function

    'updateable implementation
    Overridable Sub update() Implements Updatable.update
        If turnsTilNextStep = 0 Then
            nextStep = getNextStep(currStep)
            nextStep()
            currStep += 1
            setWaitTime(currStep)
            nextStep = getNextStep(currStep)
            If currStep > numSteps Then stopTF()
        ElseIf turnsTilNextStep = -1 Then
            Dim i = 1
        Else
            turnsTilNextStep -= 1
        End If
    End Sub

    'sequential tf methods
    Overridable Sub stopTF()
        tfDone = True
    End Sub
    Overridable Sub setWaitTime(ByVal stage As Integer)
        turnsTilNextStep = 1
        turnsTilNextStep += generatWILResistance()
    End Sub
    Function generatWILResistance()
        Return CInt(turnsTilNextStep * (Game.player.getWIL() / 20)) * wilImpact
    End Function

    'toString for save / load
    Public Overrides Function ToString() As String
        Return currStep & "$" & numSteps & "$" & turnsTilNextStep & "$" & _
            wilImpact & "$" & canBeStopped & "$" & tfName & "$" & tfDone
    End Function

    'accessor methods
    Public Function getcanBeStopped() As Boolean
        Return canBeStopped
    End Function
    Public Function getturnsTilNextStep() As Integer
        Return turnsTilNextStep
    End Function
    Public Function getTFDone() As Boolean
        Return tfDone
    End Function
    Public Function getNextStep() As Action
        Return nextStep
    End Function
    Overridable Function getNextStep(ByVal stage As Integer) As action
        Return Nothing
    End Function
End Class
