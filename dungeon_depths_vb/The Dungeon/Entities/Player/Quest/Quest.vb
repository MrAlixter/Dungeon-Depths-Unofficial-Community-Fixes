Public Enum qInds
    helpWanted
    darkPact
    dfaUpgrade
    banEgg
    outOfTime
    cContra
    sSlime
    floor4encounter
    oppositeDay
    nineLives
    enthralled
    faewoods1
End Enum

Public MustInherit Class Quest
    Dim active As Boolean = False
    Dim completed As Boolean = False
    Dim name As String
    Protected qInd As Integer

    Dim curr_step As Integer = 0

    Protected objectives As List(Of Objective)

    Public Sub New(ByVal n As String)
        name = n
        objectives = New List(Of Objective)()
    End Sub

    Public Function getProgress() As String
        Return curr_step + 1 & "/" & objectives.Count
    End Function

    Public Sub complete(ByVal objId As Integer)
        If objId > -1 And objId < objectives.Count Then
            objectives(objId).complete()
        End If

        curr_step += 1

        If curr_step >= objectives.Count Then
            completed = True
            active = False
        End If
    End Sub
    Public Overridable Sub completeEntireQuest()
        completed = True
        active = False
    End Sub
    Public Sub completeCurrOjb()
        complete(curr_step)
    End Sub
    Public Sub goToStep(ByVal i As Integer)
        curr_step = i
    End Sub
    Public Function getCurrObj() As Objective
        If curr_step > -1 And curr_step < objectives.Count Then
            Return objectives(curr_step)
        End If
        Return Nothing
    End Function
    Public Function getCurrStep() As Integer
        Return curr_step
    End Function
    Public Overridable Function getActive() As Boolean
        Return active
    End Function
    Public Overridable Function getComplete() As Boolean
        Return completed
    End Function
    Public Function getName() As String
        Return name
    End Function
    Public Function getQInd() As Integer
        Return qInd
    End Function
    Public Sub finishEarly()
        completed = True
        active = False
    End Sub

    Public Overridable Sub init()
        active = True
        curr_step = 0
        Game.player1.ongoingQuests.add(Game.player1.quests(qInd))
    End Sub
    Public Overridable Function canGet() As Boolean
        Return False
    End Function
    Public Overridable Function isHidden()
        Return False
    End Function

    Public Function save() As String
        Dim out As String = ""

        out += active & "^"
        out += completed & "^"
        out += name & "^"
        out += curr_step & "^"
        out += qInd & "^"

        Return out
    End Function
    Public Overridable Sub load(ByRef s As String)
        Dim buffer = s.Split("^")

        active = CBool(buffer(0))
        completed = CBool(buffer(1))
        name = buffer(2)
        curr_step = CInt(buffer(3))
        qInd = CInt(buffer(4))
    End Sub
End Class

Public Class Objective
    Protected description As String

    Public Sub New(ByVal d As String)
        description = d
    End Sub

    Public Overridable Sub complete()
    End Sub
    Public Overridable Function isComplete() As Boolean
        Return False
    End Function

    Public Overridable Function getDesc() As String
        Return description
    End Function

    Public Shared Sub showNPC(ByRef npcImage As Image, ByVal msg As String)
        Game.picNPC.BackgroundImage = npcImage
        Game.picNPC.Visible = True

        Game.pushNPCDialog(msg, AddressOf fromNPC)
    End Sub
    Public Shared Sub showNPC(ByRef npcImage As Image, ByVal msg As String, ByRef act As action)
        Game.picNPC.BackgroundImage = npcImage
        Game.picNPC.Visible = True

        Game.pushNPCDialog(msg, act)
    End Sub

    Public Shared Sub fromNPC()
        Game.picNPC.Visible = False
        Game.closeLblEvent()
    End Sub
End Class
