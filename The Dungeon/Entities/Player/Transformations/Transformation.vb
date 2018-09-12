'The Transformation class will be used to handle a (sequence of) tranformation(s) of the player from one "permenant"
'state to another, as well as a template for the Polymorph class which will handle temporary changes

Public Class Transformation
    Implements Updatable
    Dim currStep As Integer
    Dim numSteps As Integer
    Dim turnsTilNextStep As Integer
    Dim nextStep As Action
    Dim wilImpact As Double
    Dim canBeStopped As Boolean

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        currStep = 0
        numSteps = n
        turnsTilNextStep = tts
        wilImpact = wi
        canBeStopped = cbs
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        currStep = cs
        numSteps = n
        turnsTilNextStep = tts
        wilImpact = wi
        canBeStopped = cbs
    End Sub

    Sub update() Implements Updatable.update
        If turnsTilNextStep = 0 Then
            nextStep()
            currStep += 1
            setWaitTime(currStep)
            If currStep > numSteps Then stopTF()
        Else
            turnsTilNextStep -= 1
        End If
    End Sub
    Overridable Sub stopTF()

    End Sub
    Overridable Sub setWaitTime(ByVal stage As Integer)
        turnsTilNextStep = 1
        turnsTilNextStep += generatWILResistance()
    End Sub
    Function generatWILResistance()
        Return CInt(turnsTilNextStep * ((Game.player.getWillpower() * wilImpact) / (50 * wilImpact)))
    End Function

    Public Overrides Function ToString() As String
        Return currStep & "#" & numSteps & "#" & turnsTilNextStep & "#" & wilImpact & "#" & canBeStopped
    End Function

    Public Function getcanBeStopped() As Boolean
        Return canBeStopped
    End Function
    Public Function getturnsTilNextStep() As Integer
        Return turnsTilNextStep
    End Function
End Class
