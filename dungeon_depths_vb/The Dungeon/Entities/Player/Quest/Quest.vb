Public MustInherit Class Quest
    Dim active As Boolean = False
    Dim completed As Boolean = False
    Dim name As String

    Dim currStep As Integer = 0

    Protected objectives As List(Of Objective)

    Public Sub New(ByVal n As String)
        name = n
        objectives = New List(Of Objective)()
    End Sub

    Public Function getProgress() As String
        Return currStep + 1 & "/" & objectives.Count
    End Function

    Public Sub complete(ByVal objId As Integer)
        If objId > -1 And objId < objectives.Count Then
            objectives(objId).complete()
        End If

        currStep += 1

        If currStep >= objectives.Count Then
            completed = True
            active = True
        End If
    End Sub
    Public Sub completeCurrOjb()
        complete(currStep)
        currStep += 1
    End Sub
    Public Function getCurrObj() As Objective
        Return objectives(currStep)
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

    Public Overridable Sub init()
        active = True
        currStep = 0
    End Sub
    Public Overridable Function canGet() As Boolean
        Return False
    End Function

    Public Function save() As String
        Dim out As String = ""

        out += active & "^"
        out += completed & "^"
        out += name & "^"
        out += currStep & "^"

        Return out
    End Function
    Public Overridable Sub load(ByRef s As String)
        Dim buffer = s.Split("^")

        active = CBool(buffer(0))
        completed = CBool(buffer(1))
        name = buffer(2)
        currStep = CInt(buffer(3))
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
End Class
